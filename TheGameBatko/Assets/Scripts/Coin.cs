﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            
            Destroy(this.gameObject);
             
        }
        else if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);

        }
       

    }
    

}

