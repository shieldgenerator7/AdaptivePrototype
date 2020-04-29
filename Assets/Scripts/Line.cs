using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void setEndPoints(int startID, int destinationID)
    {
        setEndPoints(
            MapPoint.FindByID(startID).transform.position,
            MapPoint.FindByID(destinationID).transform.position
            );
    }
    public void setEndPoints(MapPoint start, MapPoint end)
    {
        setEndPoints(
            start.transform.position,
            end.transform.position
            );
    }
    public void setEndPoints(Vector2 start, Vector2 end)
    {
        sr = GetComponent<SpriteRenderer>();
        Vector2 diff = end - start;
        transform.position = start + diff / 2;
        transform.right = diff.normalized;
        Vector2 size = sr.size;
        size.x = diff.magnitude;
        sr.size = size;
    }
}
