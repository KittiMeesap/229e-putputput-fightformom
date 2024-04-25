using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    Rigidbody2D rb2d;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField] float spd = 2f;
    [SerializeField] float jumpPower = 300;
    float horizontalVaule;
    float runSpdModifier = 2f;

    [SerializeField] bool isGrounded;
    bool isRunning;
    bool facingRight = true;
    bool jump;
    bool isDead = false;

    [SerializeField] Transform shootPoint;
    [SerializeField] Rigidbody2D bulletPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove() == false)
            return;

        //set button for move
        horizontalVaule = Input.GetAxisRaw("Horizontal");

        //enable run
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        //disble run
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        //Jump Input
        if (Input.GetButtonDown("Jump"))
            jump = true;
        else if (Input.GetButtonUp("Jump"))
            jump = false;

            if (Input.GetKeyDown(KeyCode.F))
            {
            Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, 1f);
            Rigidbody2D fireBullet = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);


            fireBullet.AddForce(projectile, ForceMode2D.Impulse);
        }
    }

        bool CanMove()
        {
            bool can = true;

            if (isDead)
                can = false;

            return can;
        }
        private void FixedUpdate()
        {
            GroundCheck();
            Move(horizontalVaule, jump);
        }

        void GroundCheck()
        {
            isGrounded = false;

            Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
            if (collider.Length > 0)
                isGrounded = true;
        }

        //Code for Move
        void Move(float dir, bool jumpFlag)
        {
            //Jump

            if (isGrounded && jumpFlag)
            {
                isGrounded = false;
                jumpFlag = false;
                rb2d.AddForce(new Vector2(0f, jumpPower));
            }

            //Move and Run
            //Set value of x using dir and speed
            float xVal = dir * spd * 100 * Time.fixedDeltaTime;

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

        public void Die()
        {
            isDead = true;
            FindObjectOfType<LevelManager>().Restart();
        }

        public void ResetPlayer()
        {
            isDead = false;
        }

    Vector2 CalculateProjectileVelocity(Vector2 startPoint, float timeToTarget)
    {
        float Vxi = startPoint.x > 0 ? -1f / timeToTarget : 1f / timeToTarget;

        float Vyi = (Physics2D.gravity.magnitude * timeToTarget) / 2f;

        Vector2 velocity = new Vector2(Vxi, Vyi);

        return velocity;
    }
}
