using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject target;


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
            // Assuming you have variables such as 'target', 'shootPoint', and 'bulletPrefabs' defined elsewhere
            if (target != null && shootPoint != null && bulletPrefabs != null)
            {
                Vector2 targetPosition = target.transform.position;
                Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, targetPosition, 1f);
                Rigidbody2D fireBullet = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                fireBullet.velocity = projectile;
            }

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

    Vector2 CalculateProjectileVelocity(Vector2 startPoint, Vector2 targetPoint, float timeToTarget)
    {
        float gravity = Physics2D.gravity.magnitude;
        Vector2 displacementY = targetPoint - startPoint;
        displacementY.y = 0;
        float y = displacementY.magnitude;
        float Vyi = (y - 0.5f * gravity * timeToTarget * timeToTarget) / timeToTarget;
        Vector2 velocityY = new Vector2(0, Vyi);
        Vector2 displacementXZ = targetPoint - startPoint;
        displacementXZ.y = 0;
        float xz = displacementXZ.magnitude;
        float Vxi = xz / timeToTarget;
        Vector2 velocityXZ = displacementXZ.normalized * Vxi;
        return velocityXZ + velocityY.normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
        }
    }

}
