using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movment : MonoBehaviour
{
    public float speed;
    private Transform enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixUpdate()
    {
        enemyPos.position = new Vector3(-1, 0, 0);
         


    }
}
