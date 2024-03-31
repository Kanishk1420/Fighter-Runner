using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Change this line
    private float score;

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawnManager.instance != null && !PlayerManager.isGameOver) // Check if EnemySpawnManager instance exists and the game is not over
        {
            score += 5 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }

}
