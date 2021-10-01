using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    bool isGrounded;

    public float speed = 10f;
    public float regular;   

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        regular = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;
        float px = player.transform.position.x;
        float dist = ex - px;
        Vector2 velocity = rb.velocity;
        
        velocity.x = 0;


        if (dist <= 10 && dist > 0)
        {
            speed = 0f;
        }
        else
        {
            speed = regular;
        }

        if (dist <= -10 && dist > 0)
        {
            speed = 0f;
        }
        else
        {
            speed = regular;
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




}
