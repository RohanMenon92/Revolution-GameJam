using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int boost = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 300 == 0)
        {
            score += 1;
        }
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
