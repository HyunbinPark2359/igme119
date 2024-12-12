using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 1.0f;
    private bool hit;
    protected BoxCollider2D boxCollider;
    private ScreenDetector myScreenDetector;
    protected Vector3 direction = Vector3.zero;
    private Vector3 velocity;
    protected float moveTimer = 0.0f;
    protected float time = 0.0f;
    protected bool isMoving = false;
    protected bool isResting = false;

    protected void Awake()
    {
        direction.x = Random.Range(0, 2) * 2 - 1;
        boxCollider = GetComponent<BoxCollider2D>();
        myScreenDetector = GetComponent<ScreenDetector>();
    }

    protected void Update()
    {
        if (hit)
        {
            return;
        }

        moveTimer += Time.deltaTime;

        Wander();

        if (isMoving)
        {
            BoundariesAroundTheEdges();
            direction.Normalize();
            velocity = direction * speed * Time.deltaTime;
            transform.position += velocity;
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            hit = true;
            isMoving = false;
            boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction.x)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    protected abstract void Move();

    protected abstract void Wander();

    private void BoundariesAroundTheEdges()
    {
        if (transform.position.x < myScreenDetector.screenLeft) // Left boundary
        {
            direction.x = -direction.x;
            transform.position = new Vector3(myScreenDetector.screenLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > myScreenDetector.screenRight) // Right boundary
        {
            direction.x = -direction.x;
            transform.position = new Vector3(myScreenDetector.screenRight, transform.position.y, transform.position.z);
        }

        if (transform.position.y < myScreenDetector.screenBottom) // Bottom boundary
        {
            direction.y = -direction.y;
            transform.position = new Vector3(transform.position.x, myScreenDetector.screenBottom, transform.position.z);
        }
        else if (transform.position.y > myScreenDetector.screenTop) // Top boundary
        {
            direction.y = -direction.y;
            transform.position = new Vector3(transform.position.x, myScreenDetector.screenTop, transform.position.z);
        }
    }
}
