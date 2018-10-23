using System.Collections;
using UnityEngine;

[System.Serializable]
// Reusable code for Min & Max
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class ShipController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float tilt;

    // Init Instance of Boundary class
    public Boundary boundary;

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

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f, 
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            ); // Set Rigidbody's position

        // Tilt Code
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);
    }
}