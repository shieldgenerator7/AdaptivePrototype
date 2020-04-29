using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapPoint : MonoBehaviour
{

    public string locationName;
    public MapArea mapArea;
    public int id = 0;//unique id to distinguish between other MapPoints

    public TMP_Text text;

    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    public void highlight(bool show)
    {
        text.enabled = show;
        if (show)
        {
            if (transform.localScale.x < 1)
            {
                transform.localScale *= 2;
            }
        }
        else
        {
            if (transform.localScale.x >= 1)
            {
                transform.localScale /= 2;
            }
        }
    }

    public static MapPoint FindByID(int id)
    {
        foreach(MapPoint mp in FindObjectsOfType<MapPoint>())
        {
            if (mp.id == id)
            {
                return mp;
            }
        }
        return null;
    }
}
