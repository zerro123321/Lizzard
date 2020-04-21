using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController2D : MonoBehaviour
{
    private AIPath aiEnemy;
    private Animator animEnemy;
    private bool facingRight = true;

    private void Start()
    {
        aiEnemy = GetComponent<AIPath>();
        animEnemy = GetComponent<Animator>();
    }

    void FixUpdate()
    {
        if (aiEnemy.maxSpeed >= 0.01f)
        {
            
            Debug.Log("Walking");

        }

        if (facingRight == false && aiEnemy.maxSpeed > 0)
        {
            Flip();
        }
        else if (facingRight == true && aiEnemy.maxSpeed < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
