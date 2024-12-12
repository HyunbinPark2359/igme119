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
}
