using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower; 

    Rigidbody2D rb;

    public float moveSpeed;

    SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            sr.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            sr.flipX = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

    }

    private void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.tag == "Platform")
        {
            transform.SetParent(c.transform);
        }
    }

    private void OnCollisionExit2D (Collision2D c)
    {
        if (c.gameObject.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }


}
