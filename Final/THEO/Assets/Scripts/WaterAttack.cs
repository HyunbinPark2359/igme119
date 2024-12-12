using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : SpiritAttack
{
    [SerializeField] private Transform firePoint;

    protected override void Attack()
    {
        cooldownTimer = 0;

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    protected override int FindBullet()
    {
        return base.FindBullet();
    }
}
