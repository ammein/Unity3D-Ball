﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    // apply input to player 
    public float speed;
    private Rigidbody rb;

    //void Update()
    //{
    //    // Update is called before rendering a frame
    //}

    void Start()
    {
        // Get Component of Rigidbody in Unity Object
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        // Just before perform any PHYSICS calculations
        // And this is our physics code will go
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create new vector 3 on instance
        // We don't want it to move up at all (y-axis)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    
}
