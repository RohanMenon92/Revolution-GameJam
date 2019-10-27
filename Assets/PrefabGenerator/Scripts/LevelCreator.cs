using System.Collections;
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
        int[,] block = new int [8,20];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                block[i,j] = 10;
            }
        }

        ////////////////////////// Add code to assign blocks here
        block[1, 0] = -2;
        block[1, 5] = 0;
        block[1, 6] = 0;
        block[1, 7] = 0;
        block[2, 5] = 5;
        block[3, 0] = 1;
        block[4, 0] = 3;
        block[4, 5] = 5;
        block[5, 0] = 2;
        block[5, 1] = 2;
        block[6, 3] = 5;
        block[6, 6] = 0;
        block[6, 7] = 0;

        levelTransform.name = "Level4";
        ///////////////////////


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 20; j++)
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
        GameObject instantiatedObject = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(objectToCreate, levelTransform);
        instantiatedObject.transform.localPosition = new Vector3(i, 0, j);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
