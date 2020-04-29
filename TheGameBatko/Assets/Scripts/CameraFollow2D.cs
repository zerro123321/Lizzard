﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Camera start position
        Vector3 startPos = transform.position;

        //Player current position
        Vector3 endPos = startPos;
        if (player != null)
        {
            endPos = player.transform.position;
            endPos.x += posOffset.x;
            endPos.y += posOffset.y;
            endPos.z = -10;

        }
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
    }
}
