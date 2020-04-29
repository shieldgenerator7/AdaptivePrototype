using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : ShipController
{
    protected override Vector2 movementInput()
    {
        return Vector2.up;
    }

    protected override bool fireInput()
    {
        return false;
    }
}
