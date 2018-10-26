using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion; // Add Reference
    public GameObject playerExplosion; // Add Reference to our PlayerShip

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
        Destroy(other.gameObject);
        Destroy(gameObject); // Destroy Asteroid Itself to all its children and to all its component
    }
}
