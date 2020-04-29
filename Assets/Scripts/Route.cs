
using System.Collections.Generic;
using UnityEngine;

public class Route
{
    public float distance;
    public List<GameObject> objectPrefabs;
    public int startID;
    public int destinationID;

    public Route(float distance, int startID, int destinationID, List<GameObject> objectPrefabs)
    {
        this.distance = distance;
        this.startID = startID;
        this.destinationID = destinationID;
        this.objectPrefabs = objectPrefabs;
    }

    public GameObject spawnObject(Bounds bounds)
    {
        int randIndex = Random.Range(0, objectPrefabs.Count);
        GameObject spawnedObject = GameObject.Instantiate(objectPrefabs[randIndex]);
        spawnedObject.transform.position =
            new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
                );
        return spawnedObject;
    }

    public static implicit operator bool(Route r)
        => r != null && !ReferenceEquals(r, null);
}
