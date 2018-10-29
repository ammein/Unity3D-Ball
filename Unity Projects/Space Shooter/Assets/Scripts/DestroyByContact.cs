using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion; // Add Reference
    public GameObject playerExplosion; // Add Reference to our PlayerShip
    public int scoreValue; // To store a score value when hit the hazard
    private GameController gameController; // Call the instance of other script objects

    void Start()
    {
        // Find GameController tag to hold as GameObject in Start()
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        // when gameControllerObject is nothing created or similar
        if(gameControllerObject != null)
        {
            // Make gameController as new but Receive component as GameController.
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        // Print to the console if cannot find GameController script
        if (gameControllerObject == null)
        {
            Debug.LogWarning("Cannot Find 'GameController' script");
        }
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Debugging
        if(other.tag == "Boundary")
        {
            return; //  Return null OR end this function at this point
        }

        Instantiate(explosion, transform.position, transform.rotation); // Instantiate our explosions
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); // Instantiate our explosions
        }
        gameController.AddScore(scoreValue); // Add scoreValue
        Destroy(other.gameObject);
        Destroy(gameObject); // Destroy Asteroid Itself to all its children and to all its component
    }
}