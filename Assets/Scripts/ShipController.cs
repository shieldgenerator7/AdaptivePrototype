using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour
{
    public float moveSpeed = 2;//how fast the ship can freely move
    public float driftSpeed = 0;//how fast the ship is floating thru space

    public int maxHP = 100;
    public int healthPoints = 0;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        healthPoints = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = movementInput();
        rb2d.velocity = (transform.up * input.y + transform.right * input.x).normalized * moveSpeed;
        rb2d.velocity += Vector2.up * driftSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShipController other = collision.gameObject.GetComponent<ShipController>();
        if (other)
        {
            healthPoints -= other.maxHP;
            if (healthPoints <= 0)
            {
                destroy();
            }
        }
    }

    /// <summary>
    /// The direction the ship wants to go
    /// Does not include drift direction
    /// </summary>
    /// <returns></returns>
    protected abstract Vector2 movementInput();
    /// <summary>
    /// Called when the ship's healthPoints reaches 0
    /// </summary>
    protected virtual void destroy()
    {
        Destroy(gameObject);
    }
}
