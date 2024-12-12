using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAttack : SpiritAttack
{
    [SerializeField] private Transform firePoint;

    private void Awake()
    {
        attackCooldown = 1.0f;
    }

    protected override void Attack()
    {
        cooldownTimer = 0;

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().PlantSeed();
    }

    protected override int FindBullet()
    {
        return base.FindBullet();
    }
}
