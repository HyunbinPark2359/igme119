using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class WaterProjectile : Projectile
{
    private void Start()
    {
        speed = 8.0f;
        range = 20.0f;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Enemy")
        {
            hit = true;
            boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
