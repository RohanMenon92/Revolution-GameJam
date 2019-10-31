using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    float levelSpeed = 0.075f;
    GameController gameController = null;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.localPosition = transform.localPosition + new Vector3(0f, 0f, -levelSpeed);
        }
        
        if(transform.localPosition.z < -40 && gameObject.activeInHierarchy)
        {
            if(gameController.gameObject != null)
            {
                gameObject.SetActive(false);
                gameController.IncrementScore();
            }
        } 
    }
}
