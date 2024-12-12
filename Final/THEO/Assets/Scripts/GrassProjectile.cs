using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassProjectile : Projectile
{
    private void Start()
    {
        speed = 3.0f;
        range = 10.0f;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //Spawn Grass Terrain On That Area
        }

        base.OnCollisionEnter2D(collision);
    }
}
