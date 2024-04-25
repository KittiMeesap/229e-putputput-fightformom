using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float spd = 1f;

    Rigidbody2D rb2d;
    float horizontalVaule;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVaule = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        Move(horizontalVaule);
    }

    //Code for Move
    void Move(float dir)
    {
        //Set value X using dir and speed
        float xVal = dir * spd * 100 *  Time.deltaTime;
        //Create Vec2 for the velocity
        Vector2 targetVelocity = new Vector2(dir,rb2d.velocity.y);
        //Player Velocity
        rb2d.velocity = targetVelocity;
    }
}
