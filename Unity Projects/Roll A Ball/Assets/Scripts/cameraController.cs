using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public GameObject player;

    // Offset is private because we can set the value HERE IN SCRIPT
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is guaranteed to run AFTER all items 
    // have been processed in update
    // Once set the camera , we will absolutely know the player that moved
    // for that frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
