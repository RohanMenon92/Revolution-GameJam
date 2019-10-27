using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaBarController : MonoBehaviour
{
    float barLength = 300;
    public float consumptionConstant = 100f;

    RectTransform currentStamina;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = GetComponent<RectTransform>();
        currentStamina.sizeDelta = new Vector2(barLength, 20);

        //GetComponent<RectTransform>().sizeDelta = new Vector2(barLength, 20);


    }

    // Update is called once per frame
    void Update()
    {

    }

    /*This function will use the boost bar reducing it over time. 
    It also returns true if it is able to consume the boost bar and false if the boost bar is empty.*/
    bool useBoost()
    {
        if (barLength > 0)
        {
            barLength -= Time.deltaTime * consumptionConstant;
            currentStamina.sizeDelta = new Vector2(barLength, 20);
            return true;
        }
        else
        {
            return false;
        }
    }

    void incrementBoost(int increaseBoostBy)
    {
        barLength += increaseBoostBy;
        barLength = Mathf.Clamp(barLength, 0, 500);
    }
}
