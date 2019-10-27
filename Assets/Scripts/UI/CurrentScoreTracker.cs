using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentScoreTracker : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;
    GameController game;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameController>();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Current Score = " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score = game.score;
        scoreText.text = "Current Score = " + score;
    }
}
