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

    private int extraJumps;
    public int extraJumpsValue;


    private Animator payerAnim;
    // Start is called before the first frame update
    void Start()
    {
        CoinSpawn();
        count = 0;
        countText.text = "Player Score: " + count.ToString();
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
        //Debug.Log(rb.velocity.y);
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

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        CoinSpawn();
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

    void CoinSpawn()
    { 
        bool coinSpawn = false;
        while (coinSpawn)
        {
            Vector3 coinPosition = new Vector3(Random.Range(-7f, -7f), Random.Range(4f, 4f), 0);
            if((coinPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(coin, coinPosition, Quaternion.identity);
                coinSpawn = true;
            }
        }
    


    }

}
