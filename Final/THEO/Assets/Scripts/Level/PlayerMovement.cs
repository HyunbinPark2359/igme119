using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpAmount = 8.0f;
    private float moveSpeed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool running;
    private ScreenDetector myScreenDetector;

    public bool IsGrounded
        { get { return grounded; } }

    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myScreenDetector = GetComponent<ScreenDetector>();

        moveSpeed = speed;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * moveSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (running)
        {
            moveSpeed = speed * 1.5f;
        }
        else
        {
            moveSpeed = speed;
        }

        // Flip player when moving left
        if(horizontalInput > 0.01f && transform.localScale.x < 0f)
        {
            Vector3 ITemp = transform.localScale;
            ITemp.x = Mathf.Abs(ITemp.x);
            transform.localScale = ITemp;
        }
        else if (horizontalInput < -0.01f && transform.localScale.x > 0f)
        {
            Vector3 ITemp = transform.localScale;
            ITemp.x *= -1;
            transform.localScale = ITemp;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("walking", horizontalInput != 0);
        anim.SetBool("running", running && horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        BoundariesAroundTheEdges();
    }

    private void Jump()
    {
        body.velocity = new Vector3(body.velocity.x, jumpAmount);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void BoundariesAroundTheEdges()
    {
        if (transform.position.x < myScreenDetector.screenLeft) // Left boundary
        {
            transform.position = new Vector3(myScreenDetector.screenLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > myScreenDetector.screenRight) // Right boundary
        {
            transform.position = new Vector3(myScreenDetector.screenRight, transform.position.y, transform.position.z);
        }

        if (transform.position.y < myScreenDetector.screenBottom) // Bottom boundary
        {
            transform.position = new Vector3(transform.position.x, myScreenDetector.screenBottom, transform.position.z);
        }
        else if (transform.position.y > myScreenDetector.screenTop) // Top boundary
        {
            transform.position = new Vector3(transform.position.x, myScreenDetector.screenTop, transform.position.z);
        }
    }
}
