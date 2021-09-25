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


    void DoFaceLeft(bool faceleft)
    {
        if (faceleft == true)
        {
            transform.localRotation = Quaternion.Euler(0, 180 , 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0 , 0);
        }
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
            m_Animation.SetBool("IsMoving", true);
        }
        
        // check for moving right
        else if (Input.GetKey("d"))
        {
            velocity.x = speed;
            m_Animation.SetBool("IsMoving", true);
        }
        else
        {
            m_Animation.SetBool("IsMoving", false);
        }




        if(velocity.x <  -0.5f)
        {
            DoFaceLeft(true);
        }
        if (velocity.x > 0.5f)
        {
            DoFaceLeft(false);

        }













        rb.velocity = velocity;

    }







}