using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    
    
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField]
    public Transform target;
    private int count;
    [SerializeField] private Text countText;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        countText.text = "Enemy Score: " + count.ToString();
     
       

       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else
        {
            isGrounded = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            count = count + 1;
            countText.text = "Enemy Score: " + count.ToString();
        }
    }
   
}
