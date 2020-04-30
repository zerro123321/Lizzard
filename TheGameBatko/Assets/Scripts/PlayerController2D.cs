using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    private int count;

    [SerializeField] private Text countText;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int jumpsLeft;
    public int extraJumpsValue;
    public bool isBlocked;


    private Animator payerAnim;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Player Score: " + count.ToString();
        jumpsLeft = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        payerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            jumpsLeft = extraJumpsValue;
        }

        //if (!isBlocked)
        //{
        //    if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        //    {
        //        payerAnim.SetBool("IsJump", true);
        //        rb.velocity = Vector2.up * jumpForce;
        //        extraJumps--;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        //    {
        //        payerAnim.SetBool("IsJump", true);
        //        rb.velocity = Vector2.up * jumpForce;
        //    }
        //}
        //Debug.Log(rb.velocity.y);
    }

  

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround) && rb.velocity.y <= 0;

        if (isGrounded)
            jumpsLeft = extraJumpsValue;
        
        payerAnim.SetFloat("Speed", moveInput);
        if (isGrounded)
            payerAnim.SetBool("IsJump", false);

        HandleFlip();
        HandleMovement();

    }


    private void HandleMovement()
    {
        if (isBlocked)
        {
            moveInput = 0;
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (!isGrounded && jumpsLeft == 0)
                {
                    // can not jump
                    return;
                }
               
                if (!isGrounded && jumpsLeft > 0)
                {
                    jumpsLeft--;
                }
               
                payerAnim.SetBool("IsJump", true);
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void HandleFlip()
    {
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);
            Debug.Log("GAME OVER");
        }
        if (other.CompareTag("Coin"))
        {
            count = count + 1;
            countText.text = "Player Score: " + count.ToString();
        }
    }


}
