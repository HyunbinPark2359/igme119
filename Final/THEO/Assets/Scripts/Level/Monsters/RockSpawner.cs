using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RockSpawner : EnemySpawner
{
    [SerializeField] protected GameObject[] rocks;

    protected new void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++)
        {
            SetSpawnPoint();
            Spawn();
        }
    }

    protected override void SetSpawnPoint()
    {
        base.SetSpawnPoint();

        spawnPoint.y = -3.16391f;
    }

    public int FindRock()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            if (!rocks[i].activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }

    protected override void Spawn()
    {
        int i = FindRock();
        if (i == -1)
        {
            return;
        }

        rocks[i].transform.position = spawnPoint;
        rocks[i].GetComponent<Enemy>().Spawn();
    }
}
