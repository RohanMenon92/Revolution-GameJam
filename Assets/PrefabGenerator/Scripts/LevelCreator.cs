﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Transform levelTransform;

    public GameObject object0;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject objectn1;
    public GameObject objectn2;
    public GameObject objectn3;

    // Start is called before the first frame update
    void Start()
    {
        int[,] block = new int [8,8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                block[i,j] = 100;
            }
        }

        ////////////////////////// Add code to assign blocks here


        block[0, 3] = 1;
        block[1, 3] = 4;
        block[4, 4] = 3;
        block[5, 1] = 2;
        block[5, 4] = 3;

        levelTransform.name = "Level13";
        ///////////////////////


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch(block[i, j])
                {
                    case 0:
                        CreatePrefab(object0, i + 0.5f, j + 0.5f);
                        break;
                    case 1:
                        CreatePrefab(object1, i + 0.5f, j + 0.5f);
                        break;
                    case 2:
                        CreatePrefab(object2, i + 1f, j + 0.5f);
                        break;
                    case 3:
                        CreatePrefab(object3, i + 0.5f, j + 1f);
                        break;
                    case 4:
                        CreatePrefab(object4, i + 1f, j + 1f);
                        break;
                    case 5:
                        CreatePrefab(object5, i + 1f, j + 1.5f);
                        break;
                    case -2:
                        CreatePrefab(objectn2, i + 0.5f, j + 0.5f);
                        break;
                    case -1:
                        CreatePrefab(objectn1, i + 0.5f, j + 0.5f);
                        break;
                    case -3:
                        CreatePrefab(objectn3, i + 0.5f, j + 0.5f);
                        break;
                }
            }
        }
    }

    void CreatePrefab(GameObject objectToCreate, float i, float j)
    {
#if UNITY_EDITOR
        GameObject instantiatedObject = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(objectToCreate, levelTransform);

        instantiatedObject.transform.localPosition = new Vector3(i, 0, j);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
