using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Debugging
        if(other.tag == "Boundary")
        {
            return; //  Return null OR end this function at this point
        }
        Destroy(other.gameObject);
        Destroy(gameObject); // Destroy Asteroid Itself to all its children and to all its component
    }
}
