using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : EnemySpawner
{
    [SerializeField] protected GameObject[] bats;

    protected new void Awake()
    {
        base.Awake();

        SetSpawnPoint();
        Spawn();
    }

    protected override void SetSpawnPoint()
    {
        base.SetSpawnPoint();

        spawnPoint.y = Random.Range(0.0f, myScreenDetector.screenTop - 1);
    }

    protected virtual int FindBat()
    {
        for (int i = 0; i < bats.Length; i++)
        {
            if (!bats[i].activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }

    protected override void Spawn()
    {
        int i = FindBat();
        if (i == -1)
        {
            return;
        }

        bats[i].transform.position = spawnPoint;
        bats[i].GetComponent<Enemy>().Spawn();
    }
}
