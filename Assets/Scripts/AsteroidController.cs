using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : ShipController
{
    protected override Vector2 movementInput()
    {
        return Vector2.zero;
    }

}
