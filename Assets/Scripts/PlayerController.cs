using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;

    Rigidbody2D rb;

    public float moveSpeed;

    public float jumpDetectOffset;

    public LayerMask jumpableObjects;

    SpriteRenderer sr;

    Vector3 startPos;

    BoxCollider2D bc;




    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        bc = gameObject.GetComponent<BoxCollider2D>();
        startPos = transform.position;
    }

        
      




    // Update is called once per frame
    void Update()
    {

       if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
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

        if (c.gameObject.tag == "Respawn")
        {
            rb.velocity = Vector3.zero;
            transform.position = startPos;
        }


    }

    private void OnCollisionExit2D (Collision2D c)
    {
        if (c.gameObject.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, jumpDetectOffset, jumpableObjects);
        Color rayColor = Color.red;
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + jumpDetectOffset), Vector2.right * bc.bounds.size.x, rayColor);
        return raycastHit.collider != null;
    }



}
