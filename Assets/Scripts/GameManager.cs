using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjectsFolder;//GameObject parent of other GameObjects that move during play

    private void Start()
    {
        activeObjectsFolder.SetActive(false);
        SceneManager.LoadScene("MapScene", LoadSceneMode.Additive);
    }

    public void startRoute(Route route)
    {
        activeObjectsFolder.SetActive(true);
        SceneManager.UnloadSceneAsync("MapScene");
    }
}
