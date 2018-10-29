using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // To enable UI for text

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues; // use another variable
    public int hazardCount; // To define how many hazard to spawn
    public float spawnWait; // To hold before spawning the next one
    public float startWait;
    public float waveWait;
    public Text scoreText; // Score Text Asset
    private int score; // To hold our current score
    public Text restartText;
    public Text gameOverText;

    private bool gameOver; // Flags for if else that the game is over.
    private bool restart; // Flags for if else that the restart is trigger.

    void Start()
    {
        gameOver = false; // Flag it when start of the game
        restart = false; // Flag it when start of the game
        restartText.text = ""; // Make it empty text
        gameOverText.text = ""; // Make it empty text
        score = 0;
        UpdateScore(); // Update into our starting value
        StartCoroutine(SpawnWaves()); // Initialize
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Using Application.load
                // LoadLevel / Scene File specified in parenthesis
                // Instead of using string or any reference key , we just simply load the current level
                Application.LoadLevel(Application.loadedLevel);
            }
        }
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

            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    // Public function to addScore when hazards is destroyed
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue; // To Add Score Value
        UpdateScore(); // Update Score Text
    }

    // To make available on another GameObject References
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
}