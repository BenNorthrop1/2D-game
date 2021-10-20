using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isGrounded;

    public GameObject OBJ;

    Animator m_Animator;

    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 10f;
    public float regular;
    public float stoppingDist = 2f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        regular = speed;
        m_Animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }



    // Update is called once per frame
    void Update()
    {

        DoCollisons();

        float ex = transform.position.x;
        float px = player.transform.position.x;
        float dist = ex - px;
        Vector2 velocity = rb.velocity;
        
        
        if(isGrounded == false)
        {
            velocity.x = 0;
        }
        else if (isGrounded == true)
        {
            velocity.x = speed;
        }

        if (ex < px)
        {

            Helper.DoFaceLeft(gameObject, false);
        }
        else
        {

            Helper.DoFaceLeft(gameObject, true);

        }


        // move enemy towards player

        velocity.x = 0;
        if( dist < -2 )
        {
            velocity.x = speed;
            m_Animator.SetBool("IsMoving", true);
        }
        else
        {
            //attack
        }


        void DoCollisons()
        {
            float rayLength = 0.2f;


            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);
            Color hitColor = Color.white;


            isGrounded = false;

            if (hit.collider != null)
            {


                if (hit.collider.tag == "Ground")
                {
                    hitColor = Color.green;
                    isGrounded = true;
                }
                
               



                Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
            }

        }

         void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "prefab(Clone)")
            {
                TakeDamage(20);
            }
        }





        void TakeDamage(int damage )
        {
            currentHealth -= damage;

            if (currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }


        if ( dist > stoppingDist )
        {
            velocity.x = -stoppingDist;
        }


        rb.velocity = velocity;
    }

    



}