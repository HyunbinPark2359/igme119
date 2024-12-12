using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Enemy
{
    protected override void Move()
    {
        isMoving = true;
        isResting = false;

        moveTimer = 0.0f;
        time = 2.5f + Random.Range(0.0f, 0.5f) * 5.0f;

        direction.x = Random.Range(0, 2) * 2 - 1;
    }

    public void Rest()
    {
        isMoving = false;
        isResting = true;

        moveTimer = 0.0f;
        time = 1.5f + Random.Range(0.0f, 0.5f) * 5.0f;
    }

    protected override void Wander()
    {
        if (!isMoving && !isResting)
        {
            Move();
        }
        else if (isMoving && moveTimer > time)
        {
            Rest();
        }
        else if (isResting && moveTimer > time)
        {
            isResting = false;
        }
    }
}
