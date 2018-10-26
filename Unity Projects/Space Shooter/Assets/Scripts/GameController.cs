using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues; // use another variable

    void Start()
    {
        SpawnWaves(); // Initialize
    }

    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3();
        Quaternion spawnRotation = new Quaternion();
        // We want to instantiate our hazards
        Instantiate(hazard, spawnPosition, spawnRotation); // These are the function that we are going to declare later on
    }
}
