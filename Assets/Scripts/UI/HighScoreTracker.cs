using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{
    public int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "High Score = " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
