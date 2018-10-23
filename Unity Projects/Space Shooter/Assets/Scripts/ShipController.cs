using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        // To get current gameObject (Ship) RigidBody
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Declare instance of Vector3
        Vector3 movement = new Vector3 (moveHorizontal , 0.0f , moveVertical);

        // Access Rigidbody Velocity (Physics Access)
        rb.velocity = movement * speed;
    }
}