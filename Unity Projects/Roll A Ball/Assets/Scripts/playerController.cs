using UnityEngine;
using UnityEngine.UI; // Unity Namespace UI
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {
    // apply input to player 
    public float speed;
    private Rigidbody rb;
    private int count; // Declare private value
    public Text countText; // Init text variable
    public Text winText; // Init Total Text

    void Start()
    {
        // Get Component of Rigidbody in Unity Object
        rb = GetComponent<Rigidbody>();
        count = 0; // Initialize Count
        SetCountText(); // Initialize Count Text
        winText.text = ""; // Initialize Win Text
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

    void OnTriggerEnter(Collider other)
    {
        // Much more powerful to detect string value
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false); // Just like a checkbox to activate/deactivate
            count++; // Add count by 1
            SetCountText(); // Initialize Count Text
        }
    }

    // Create a new function
    void SetCountText()
    {
        countText.text = "Count : " + count.ToString(); // Initialize Count Text
        if(count >= 9)
        {
            winText.text = "You Win !"; // Set Win Text
        }
    }

}
