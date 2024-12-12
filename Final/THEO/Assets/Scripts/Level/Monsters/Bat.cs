using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    protected new void Awake()
    {
        base.Awake();

        direction.y = Random.Range(0, 2) * 2 - 1;

        direction.Normalize();
    }

    protected override void Move()
    {
        isMoving = true;

        moveTimer = 0.0f;
        time = 0.8f + Random.Range(0.0f, 0.5f) * 0.6f;

        direction = new Vector3(Random.Range(0, 2) * 2 - 1, Random.Range(0, 2) * 2 - 1, 0).normalized;
    }

    protected override void Wander()
    {
        if (!isMoving)
        {
            Move();
        }
        else if (isMoving && moveTimer > time)
        {
            Move();
        }
    }
}