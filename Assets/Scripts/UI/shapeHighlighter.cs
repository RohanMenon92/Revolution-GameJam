using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shapeHighlighter : MonoBehaviour
{
    [Range (0,4)]
    public int currentShapeIndexToHighlight = 0;
    int previousShapeIndexToUnhighlight = 0;
    ShapeHighlightNode[] shapeList;
    int numberOfShapeIndex;
        
    // Start is called before the first frame update
    void Start()
    {
        //Get a list of the background squares of the shape images
        shapeList = GetComponentsInChildren<ShapeHighlightNode>();
        numberOfShapeIndex = shapeList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            highlightNextShape();
        }
        //if currentShapeIndexToHighlight overflows 
        if (currentShapeIndexToHighlight >= numberOfShapeIndex)
        {
            previousShapeIndexToUnhighlight = numberOfShapeIndex - 1;
            currentShapeIndexToHighlight = 0;

        }
        else
        {
            //if current index is 0, the previous index will become the last index in the array
            if (currentShapeIndexToHighlight == 0)
            {
                previousShapeIndexToUnhighlight = numberOfShapeIndex - 1;
            }
            //Otherwise previous will lag current by 1
            else
            {
                previousShapeIndexToUnhighlight = currentShapeIndexToHighlight - 1;
            }
        }
        //Unhighlight the previously selected shape
        shapeList[previousShapeIndexToUnhighlight].transform.localScale = new Vector3(1f, 1f, 1);
        shapeList[previousShapeIndexToUnhighlight].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        
        //Highlight the current selected shape
        shapeList[currentShapeIndexToHighlight].transform.localScale = new Vector3(1.2f, 1.2f, 1);
        shapeList[currentShapeIndexToHighlight].GetComponent<Image>().color = new Color(76f / 255f, 228f / 255f, 231f / 255f, 1f);
    }

    void highlightNextShape()
    {
        currentShapeIndexToHighlight++;
    }
}
