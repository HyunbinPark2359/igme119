using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FireProjectile : Projectile
{
    private void Start()
    {
        speed = 6.0f;
        range = 5.0f;
    }
}
