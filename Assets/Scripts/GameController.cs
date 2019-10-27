using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int boost = 0;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game OVER MAN");
        if(PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        gameOverPanel.GetComponent<SpriteRenderer>().DOFade(1f, 1.0f).OnComplete(() => {
            // Reload the game scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        
    }
    public void IncrementScore()
    {
        // Cleared a level
        score+=10;
    }
    public void IncrementBoost()
    {
        boost+=10;
    }
}
