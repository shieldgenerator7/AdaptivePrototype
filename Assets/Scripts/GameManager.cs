using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjectsFolder;//GameObject parent of other GameObjects that move during play
    public GameObject levelObjectsFolder;//GameObject parent of other GameObjects that are part of the level

    private Route currentRoute = null;
    public float spawnDelay = 1;
    private float lastSpawnTime = 0;

    public Collider2D spawnBounds;

    public Camera mainCamera;

    private void Start()
    {
        activeObjectsFolder.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        Scene mapScene = SceneManager.GetSceneByName("MapScene");
        if (!mapScene.isLoaded)
        {
            SceneManager.LoadScene("MapScene", LoadSceneMode.Additive);
        }
        currentRoute = null;
    }

    public void startRoute(Route route)
    {
        activeObjectsFolder.SetActive(true);
        SceneManager.UnloadSceneAsync("MapScene");
        //Destroy current level objects
        //2010-04-28: copied from http://answers.unity.com/answers/717490/view.html
        int childs = levelObjectsFolder.transform.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            Destroy(levelObjectsFolder.transform.GetChild(i).gameObject);
        }
        lastSpawnTime = Time.time;
        mainCamera.gameObject.SetActive(true);
        currentRoute = route;
    }

    private void Update()
    {
        if (currentRoute)
        {
            if (Time.time > lastSpawnTime + spawnDelay)
            {
                lastSpawnTime += spawnDelay;
                currentRoute.spawnObject(spawnBounds.bounds);
            }
        }
    }
}
