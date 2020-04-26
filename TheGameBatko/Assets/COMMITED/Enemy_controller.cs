using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    private int count;
    [SerializeField] private Text countText;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Enemy Score: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
