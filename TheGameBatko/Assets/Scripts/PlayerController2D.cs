using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int _score;

    private int extraJumps;
    public int extraJumpsValue;


    private Animator payerAnim;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        payerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
         
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            payerAnim.SetBool("IsJump", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            payerAnim.SetBool("IsJump", true);
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround) && rb.velocity.y <= 0;

        if (isGrounded)
        {
            payerAnim.SetBool("IsJump", false);
        }

        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        payerAnim.SetFloat("Speed", moveInput);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Coin":
                GetCoin(collision.gameObject);
                break;
            default:
                break;
        }
    }

    private void GetCoin(GameObject gameObject)
    {
        _score++;
        Debug.Log(gameObject.name);
        GameObject.Destroy(gameObject);
        var textComponent = GameObject.Find("Score").GetComponent<Text>();
        textComponent.text = $"Score: {_score}";


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }




}
