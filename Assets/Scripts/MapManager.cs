using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapPoint currentMapPoint;//the map point where the ship is currently at
    public MapPoint highlightMapPoint;//the map point the player is looking at
    public MapPoint targetMapPoint;//the map point the player has selected to travel to next

    public GameObject shipMarker;
    public float markerBuffer = 0.5f;//distance between current map point and ship marker
    public GameObject travelPath;

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
        if (mouseOverPoint != highlightMapPoint)
        {
            highlightMapPoint?.highlight(false);
            highlightMapPoint = mouseOverPoint;
            highlightMapPoint?.highlight(true);
            targetMapPoint?.highlight(true);
        }

        //Update ship marker
        Vector2 targetPos = mousePos;
        if (currentMapPoint == targetMapPoint || currentMapPoint == highlightMapPoint)
        {
            targetPos = (Vector2)currentMapPoint.transform.position + Vector2.up;
            shipMarker.transform.up = Vector2.up;
            shipMarker.transform.position = currentMapPoint.transform.position;
        }
        else
        {
            if (targetMapPoint)
            {
                targetPos = (Vector2)targetMapPoint.transform.position;
            }
            else if (highlightMapPoint)
            {
                targetPos = (Vector2)highlightMapPoint.transform.position;
            }
            Vector2 dir = (targetPos - (Vector2)currentMapPoint.transform.position).normalized;
            shipMarker.transform.up = dir;
            shipMarker.transform.position = (Vector2)currentMapPoint.transform.position + (dir * markerBuffer);
        }

        //Update target map point
        if (Input.GetMouseButtonDown(0))
        {
            targetMapPoint?.highlight(false);
            if (highlightMapPoint != currentMapPoint)
            {
                targetMapPoint = highlightMapPoint;
            }
            else
            {
                targetMapPoint = null;
            }
            if (targetMapPoint)
            {
                travelPath.SetActive(true);
                Vector2 diff = targetMapPoint.transform.position - currentMapPoint.transform.position;
                travelPath.transform.position = (Vector2)currentMapPoint.transform.position + diff / 2;
                travelPath.transform.right = diff.normalized;
                Vector2 size = travelPath.GetComponent<SpriteRenderer>().size;
                size.x = diff.magnitude;
                travelPath.GetComponent<SpriteRenderer>().size = size;
            }
            else
            {
                travelPath.SetActive(false);
            }
        }
    }
}
