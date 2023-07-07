using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Animator anim;
    private float inputX, inputY;
    private float stopX, stopY;



    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
        
    }

    void run() {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Vector2 input = (transform.right*inputX+transform.up*inputY).normalized;
        rigid.velocity = speed * input;

        if (input != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        anim.SetFloat("InputX", stopX);
        anim.SetFloat("InputY", stopY);
    }
}
