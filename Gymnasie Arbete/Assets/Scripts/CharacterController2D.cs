using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // movement variables
    public float speed = 10f;
    public float walkAcceleration = 1f;
    public float groundDeceleration = 1f;
    public float moveInput;
    public Vector2 velocity;

    // collider variables
    Collider2D[] colliderHits;
    BoxCollider2D boxCollider;

    // gravity and jumping variables
    private bool grounded;
    public float jumpHeight = 3f;
    public float airAcceleration = 1f;

    public 

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;
        moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }
        

        transform.Translate(velocity * Time.deltaTime);

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        colliderHits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        

        grounded = false;
        foreach (Collider2D hit in colliderHits)
        {
            if (hit == boxCollider)
            {
                continue;
            }
            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }

        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

    }
}
