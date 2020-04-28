using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapPoint currentMapPoint;//the map point where the ship is currently at
    public MapPoint highlightPoint;//the map point the player is looking at
    public MapPoint targetPoint;//the map point the player has selected to travel to next

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MapPoint mouseOverPoint = null;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (MapPoint mp in FindObjectsOfType<MapPoint>())
        {
            if (mp.GetComponent<SpriteRenderer>().bounds.Contains(mousePos))
            {
                mouseOverPoint = mp;
                break;
            }
        }
        if (mouseOverPoint == null)
        {
            foreach (MapPoint mp in FindObjectsOfType<MapPoint>())
            {
                if (mp.GetComponent<Collider2D>().OverlapPoint(mousePos))
                {
                    mouseOverPoint = mp;
                    break;
                }
            }
        }
        if (mouseOverPoint != highlightPoint)
        {
            highlightPoint?.highlight(false);
            highlightPoint = mouseOverPoint;
            highlightPoint?.highlight(true);
        }
    }
}
