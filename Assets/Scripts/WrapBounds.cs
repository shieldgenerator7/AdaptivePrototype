using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBounds : MonoBehaviour
{
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Vector2 diff = other.transform.position - transform.position;
        if (Mathf.Abs(diff.x) > coll.bounds.size.x/2)
        {
            Vector2 pos = other.transform.position;
            pos.x = transform.position.x - diff.x;
            other.transform.position = pos;
        }
    }
}
