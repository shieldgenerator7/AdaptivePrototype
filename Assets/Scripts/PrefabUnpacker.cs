using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on a grouping prefab to split it into individual objects upon spawning
/// </summary>
public class PrefabUnpacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform parent = transform.parent;
        foreach(Transform t in transform)
        {
            t.parent = parent;
        }
        Destroy(gameObject);
    }
}
