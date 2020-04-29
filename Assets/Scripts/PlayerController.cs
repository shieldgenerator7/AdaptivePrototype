using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ShipController
{
    protected override Vector2 movementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }

    protected override bool fireInput()
    {
        return Input.GetButton("Fire");
    }

    protected override void destroy()
    {
        FindObjectOfType<GameManager>().cancelRoute();
    }
}
