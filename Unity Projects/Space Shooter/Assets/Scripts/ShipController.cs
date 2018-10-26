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
    public GameObject shots;
    public Transform shotSpawn; // we want it to write as : shotSpawn.transform.position
    public float fireRate;
    public float nextFire;

    // Init Instance of Boundary class
    public Boundary boundary;
    private AudioSource sound; // Make it private variable

    void Start()
    {
        // To get current gameObject (Ship) RigidBody
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>(); // Accessing/Get the Component audio source on Start()
    }

    void Update()
    {
        // Check if button pressed and current time is bigger than nextFire
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            sound.Play(); // PLay the audio
            Debug.Log("Normal time : " + Time.time);
            // Update NextFire as our Current Time
            nextFire = Time.time + fireRate;
            // Clone Object
            Instantiate(shots, shotSpawn.position, shotSpawn.rotation);
        }
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