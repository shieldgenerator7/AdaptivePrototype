
using System.Collections.Generic;
using UnityEngine;

public class Route
{
    public float distance;
    public List<MapArea> areas;

    public Route(float distance, List<MapArea> areas)
    {
        this.distance = distance;
        this.areas = areas;
    }
}
