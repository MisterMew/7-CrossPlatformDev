﻿using UnityEngine;
using TMPro;

public class StatisticManager : MonoBehaviour {
    PlayerCollision pc;
    public Transform player;

    /// Score Variables
    public TextMeshProUGUI scoreText;
    private int scoreMultiplier;
    private int playerScore;

    /// Distance Variables
    public TextMeshProUGUI distanceText;
    private int playerDistance;

    /// Collectible Variables
    public TextMeshProUGUI collectiblesText;
    private int flowerOrbs;

    public void Awake() {
        pc = FindObjectOfType<PlayerCollision>();
    }

     /// START
    /* Set the starting values */
    private void Start() {
        ResetStatistics();
    }

     /// UPDATE
    /* Update the GUI text to match the collectible count */
    private void Update() {
        flowerOrbs = pc.flowerOrbs;

        scoreText.text = CalculateScore().ToString();
        distanceText.text = CalculateDistance().ToString("0m");
        collectiblesText.text = flowerOrbs.ToString();
    }

     /// STAT: Reset
    /* Reset the statistics at the start of every game */
    private void ResetStatistics() {
        scoreText.text = "0";
        distanceText.text = "0m";
        collectiblesText.text = "0";

        scoreMultiplier = 0;
        playerScore = 0;
        playerDistance = 0;
        flowerOrbs = 0;
    }

     /// STAT: Score
    /* Calculate the players current */
    private int CalculateScore() {
        for (int i = 0; i < flowerOrbs; i++) {
            if (i % 5 == 0) { 
                scoreMultiplier++; 
                continue; 
            }
        }

        if (playerDistance % 100 == 0 && flowerOrbs != 0) {
            playerScore = scoreMultiplier * (playerDistance / flowerOrbs);
        }
        return playerScore;
    }

     /// STAT: Distance
    /* Calculate the players current distance travelled */
    private int CalculateDistance() {
        playerDistance = (int)Mathf.Floor(player.position.z / 0.64F);
        if (playerDistance < 0) {
            return 0;
        }
        return playerDistance;
    }
}
