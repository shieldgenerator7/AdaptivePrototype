using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject focusObject;
    public float proceedSpeed = 4;//the rate at which it moves through the level

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = transform.position - focusObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = focusObject.transform.position + offset;
    }
}
