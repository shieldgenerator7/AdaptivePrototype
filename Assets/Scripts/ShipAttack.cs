using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : ShipAbility
{
    public float fireDelay = 0.1f;
    public Vector2 fireDirection = Vector2.up;//direction relative to ship's forward direction
    public Vector2 firePosition = Vector2.up;//position relative to ship's position and forward direction
    public GameObject firePrefab;

    private float lastFireTime = 0;

    public override void activate(bool active)
    {
        if (active)
        {
            if (Time.time > lastFireTime + fireDelay)
            {
                lastFireTime = Time.time;
                GameObject fire = Instantiate(firePrefab);
                //TODO: 2020-04-29: make up direction relative to ship's forward direction
                fire.transform.up = fireDirection;
                fire.transform.position = (Vector2)transform.position + firePosition;
                fire.GetComponent<ShotController>().driftSpeed = this.GetComponent<Rigidbody2D>().velocity.y;
            }
        }
    }
}
