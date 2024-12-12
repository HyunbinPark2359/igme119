using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5.0f;
    protected Vector3 spawnPoint = Vector3.zero;
    private float spawnTimer = 0;

    protected ScreenDetector myScreenDetector;

    protected void Awake()
    {
        myScreenDetector = GetComponent<ScreenDetector>();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer > spawnInterval)
        {
            spawnTimer = 0;
            SetSpawnPoint();
            Spawn();
        }
    }

    protected virtual void SetSpawnPoint()
    {
        spawnPoint.x = Random.Range(myScreenDetector.screenLeft + 1, myScreenDetector.screenRight - 1);
    }

    protected abstract void Spawn();
}
