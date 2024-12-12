using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpiritAttack : MonoBehaviour
{
    [SerializeField] protected float attackCooldown = 1.0f;
    [SerializeField] protected GameObject[] bullets;
    protected float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    protected abstract void Attack();

    protected virtual int FindBullet()
    {
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
