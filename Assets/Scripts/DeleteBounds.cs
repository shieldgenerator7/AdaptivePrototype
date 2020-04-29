using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBounds : MonoBehaviour
{
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (other.transform.position.y < coll.bounds.min.y)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
