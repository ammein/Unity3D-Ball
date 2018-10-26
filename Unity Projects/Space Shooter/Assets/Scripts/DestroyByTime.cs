using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float lifetime; // To make a wait

	// Use this for initialization
	void Start () {
        // Simple code when initiate , immediatly destroy the gameObject
        Destroy(gameObject , lifetime);
	}
}
