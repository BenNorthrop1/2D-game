using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PLAYERMOVEMENT : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectile;
    bool isGrounded;

    Animator m_Animation;

    public float speed = 10f;
    public float jumpheight = 10f;
    public float sprint = 12f;
    public float regular;
    public float stoneSpeed = 1f;

     
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        regular = speed;
    }

    // Update is called once per frame
    void Update()
    {
        m_Animation = gameObject.GetComponent<Animator>();


        DoJump();
        DoMove();
        DoFight();

        

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
                m_Animation.SetTrigger("Jumping");
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

        if (Input.GetButton("Sprint"))
        {
            speed = sprint;
        }
        else
        {
            speed = regular;
        }


        if (velocity.x < -0.5f)
        {
            Helper.DoFaceLeft(gameObject , true);
        }
        if (velocity.x > 0.5f)
        {
            Helper.DoFaceLeft(gameObject , false);
        }



        rb.velocity = velocity;

    }



    void CreateRock()
    {

            int dir = Helper.GetObjectDir( gameObject );
            print("dir = " + dir);
            
            if(dir==Right)       // get the player direction
            {
                Helper.MakeBullet(projectile, transform.position.x , transform.position.y+1 , 16 , 5);
            }
            else
            {
                Helper.MakeBullet(projectile, transform.position.x + 1f , transform.position.y + 1 , -16 , 5);
            }
    }





    void DoFight()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_Animation.SetTrigger("Fight");
        }

    }

}