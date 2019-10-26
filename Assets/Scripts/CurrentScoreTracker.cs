using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentScoreTracker : MonoBehaviour
{
    int score = 0;
    public int scoreToAdd = 0;
    TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Current Score = " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score += scoreToAdd;
        scoreText.text = "Current Score = " + score;
    }
}
