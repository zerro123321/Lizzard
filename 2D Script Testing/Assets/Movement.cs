using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField]
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h, 0, 0);
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime; 
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        { 
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }
}
