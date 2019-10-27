using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] levelObjects;

    public float startZValue;
    public Transform worldSpace;
    public float spacingInLevel = 11f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject levelPrefab in levelObjects)
        {
            GameObject instantiatedLevel = GameObject.Instantiate(levelPrefab, worldSpace);
            instantiatedLevel.transform.rotation = Quaternion.Euler(0, 90f, 0);
            instantiatedLevel.transform.localPosition = new Vector3(-4.5f, 0, startZValue);

            startZValue += spacingInLevel;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
