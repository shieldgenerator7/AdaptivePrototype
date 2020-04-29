using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjectsFolder;//GameObject parent of other GameObjects that move during play
    public GameObject levelObjectsFolder;//GameObject parent of other GameObjects that are part of the level

    public Route currentRoute { get; private set; } = null;
    public Route finishedRoute { get; private set; } = null;
    public float spawnDelay = 1;
    private float lastSpawnTime = 0;

    public Collider2D spawnBounds;

    public GameObject prototype;
    public TMP_Text milesLeftText;

    public Camera mainCamera;

    private void Start()
    {
        showMap(true);
        currentRoute = null;
    }

    public void startRoute(Route route)
    {
        showMap(false);
        //Destroy current level objects
        //2010-04-28: copied from http://answers.unity.com/answers/717490/view.html
        int childs = levelObjectsFolder.transform.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            Destroy(levelObjectsFolder.transform.GetChild(i).gameObject);
        }
        lastSpawnTime = Time.time;
        prototype.transform.position = Vector2.zero;
        currentRoute = route;
    }

    private void Update()
    {
        if (currentRoute)
        {
            if (Time.time > lastSpawnTime + spawnDelay)
            {
                lastSpawnTime += spawnDelay;
                GameObject spawnedObject = currentRoute.spawnObject(spawnBounds.bounds);
                spawnedObject.transform.parent = levelObjectsFolder.transform;

            }
            milesLeftText.text = "" + Mathf.Max(0, currentRoute.distance - prototype.transform.position.y);
            if (prototype.transform.position.y >= currentRoute.distance)
            {
                showMap(true);
                finishedRoute = currentRoute;
                currentRoute = null;
            }
        }
    }

    public void showMap(bool show)
    {
        if (show)
        {
            activeObjectsFolder.SetActive(false);
            mainCamera.gameObject.SetActive(false);
            Scene mapScene = SceneManager.GetSceneByName("MapScene");
            if (!mapScene.isLoaded)
            {
                SceneManager.LoadScene("MapScene", LoadSceneMode.Additive);
            }
            milesLeftText.enabled = false;
        }
        else
        {
            activeObjectsFolder.SetActive(true);
            SceneManager.UnloadSceneAsync("MapScene");
            //Destroy current level objects
            //2010-04-28: copied from http://answers.unity.com/answers/717490/view.html
            mainCamera.gameObject.SetActive(true);
            milesLeftText.enabled = true;
        }
    }
}
