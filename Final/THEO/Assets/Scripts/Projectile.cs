using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed = 6.0f;
    [SerializeField] protected float range = 5.0f;
    private Vector3 direction = Vector3.right;
    protected bool hit;
    protected BoxCollider2D boxCollider;
    private float lifetime;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit)
        {
            return;
        }

        Vector3 velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;

        lifetime += Time.deltaTime;
        if (lifetime > range / speed)
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            hit = true;
            boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player")
        {
            return;
        }
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction.x = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

        transform.rotation = Quaternion.identity;
    }

    public void PlantSeed()
    {
        lifetime = 0;
        direction = Vector3.down;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        transform.rotation = Quaternion.identity;
    }
}
