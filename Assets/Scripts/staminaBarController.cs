using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaBarController : MonoBehaviour
{
    float barLength = 300;
    public float tiredConstant = 100f;

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
        if (barLength > 0)
        {
            barLength -= Time.deltaTime * tiredConstant;
            currentStamina.sizeDelta = new Vector2(barLength , 20);
        }
    }
}
