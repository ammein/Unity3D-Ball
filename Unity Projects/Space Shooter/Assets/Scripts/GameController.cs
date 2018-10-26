﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues; // use another variable
    public int hazardCount; // To define how many hazard to spawn
    public float spawnWait; // To hold before spawning the next one
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves()); // Initialize
    }

    // To make enable for WaitForSeconds
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait); // To start wait before initialize for loop
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; // Just read the rotation value
                                                                // We want to instantiate our hazards
                Instantiate(hazard, spawnPosition, spawnRotation); // These are the function that we are going to declare later on
                yield return new WaitForSeconds(spawnWait); // To wait before initialize the next loop
            }

            yield return new WaitForSeconds(waveWait);
        }
    }
}