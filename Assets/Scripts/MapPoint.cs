using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{

    public string locationName;
    public MapArea mapArea;

    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
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
}
