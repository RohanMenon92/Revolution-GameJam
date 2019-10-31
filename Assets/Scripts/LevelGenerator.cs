using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] levelObjects;

    [SerializeField]
    public GameObject[] sceneryObjects;

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
            instantiatedLevel.transform.localPosition = new Vector3(-4.5f, 0.3f, startZValue);

            startZValue += spacingInLevel;

            int sceneryCounter = Random.Range(0, sceneryObjects.Length);
            GameObject instantiatedScenery = GameObject.Instantiate(sceneryObjects[sceneryCounter], worldSpace);
            instantiatedScenery.transform.localPosition = new Vector3(-9f, 0.3f, startZValue);
            instantiatedScenery.transform.SetParent(instantiatedLevel.transform);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
