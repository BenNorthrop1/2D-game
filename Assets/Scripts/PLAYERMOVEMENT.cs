using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isGrounded;

    Animator m_Animation;

    public float speed = 10f;
    public float jumpheight = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Animation = gameObject.GetComponent<Animator>();


        DoJump();
        DoMove();

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("space")&& isGrounded)
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = jumpheight;   
                m_Animation.SetTrigger("Jump");

            }
        }

        rb.velocity = velocity;




    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }





    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -speed;
            m_Animation.SetTrigger("RUN");
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = speed;
            m_Animation.SetTrigger("RUN");
        }

        rb.velocity = velocity;

    }







}