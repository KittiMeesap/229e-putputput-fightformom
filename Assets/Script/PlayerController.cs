using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float spd = 1f;

    Rigidbody2D rb2d;
    Animator animator;
    float horizontalVaule;
    float runSpdModifier = 2f;
    bool isRunning = false;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //set button for move
        horizontalVaule = Input.GetAxisRaw("Horizontal");

        //enable run
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        //disble run
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;
        
    }
    private void FixedUpdate()
    {
        Move(horizontalVaule);
    }

    //Code for Move
    void Move(float dir)
    {
        //Set value of x using dir and speed
        float xVal = dir * spd * 100 * Time.deltaTime;

        if (isRunning)
            xVal *= runSpdModifier;

        //Create Vec2 for the Velocity
        Vector2 targetVelocity = new Vector2(xVal, rb2d.velocity.y);

        //Set the players Velocity
        rb2d.velocity = targetVelocity;

        //If looking right and press left, turn left
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //If looking left and press right, turn to the right
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb2d.velocity.x));
    }
}
