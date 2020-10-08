using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1000f;
    public float jumpForce;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        
        // Go left or right
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right.normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left.normalized * speed * Time.deltaTime);
        }

        // JUMP
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }



    }
}
