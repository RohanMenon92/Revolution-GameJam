using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public List<Vector2> shapeList1;
    [SerializeField]
    public List<Vector2> shapeList2;

    int currShapeIndex = 0;
    bool rotating = false;
    bool moving = false;


    List<List<Vector2>> shapeList;
    Sequence crowdMove;
    SpriteRenderer[] gridElements;
    CrowdController[] crowds;
    /// <summary>
    /// Will have the code for:
    /// 1.Taking input and moving left and right
    /// 2.Updating the representation and moving crowd elements TOOL: DOTween
    /// a) when rotation
    /// b) changing crowd shape happens 
    /// 3.Will recieve calls from CrowdController when a collision happens and update it's list
    /// 4.Will pick up new PlayerCrowds and add them to the list
    /// </summary>

    void Start()
    {
        // Local element declaration
        gridElements = GetComponentInChildren<PlayerGrid>().GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer gridElement in gridElements)
        {
            gridElement.color = new Color(1f, 1f, 1f, 0f);
        }

        crowds = GetComponentsInChildren<CrowdController>();


        // Defining Shapes
        currShapeIndex = 0;
        shapeList = new List<List<Vector2>>();
        shapeList.Add(shapeList1);
        shapeList.Add(shapeList2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeShape();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            RotateRight();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateLeft();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        if (!rotating)
        {
            moving = true;
            transform.DOLocalMove((transform.localPosition + new Vector3(-1f, 0, 0)), 0.25f).OnComplete(MoveComplete).SetEase(Ease.OutQuad);
        }

    }

    void MoveRight()
    {
        if (!moving)
        {
            moving = true;
            transform.DOLocalMove((transform.localPosition + new Vector3(1f, 0, 0)), 0.25f).OnComplete(MoveComplete).SetEase(Ease.OutQuad);
        }

    }
    void MoveComplete()
    {
        moving = false;
    }

    void RotateLeft()
    {
        if (!rotating)
        {
            rotating = true;
            transform.DORotate((transform.rotation.eulerAngles + new Vector3(0, 90f, 0)), 0.5f).OnComplete(RotationComplete).SetEase(Ease.OutQuad);
        }
    }

    void RotateRight()
    {
        if(!rotating)
        {
            rotating = true;
            transform.DORotate((transform.rotation.eulerAngles + new Vector3(0, -90f, 0)), 0.5f).OnComplete(RotationComplete).SetEase(Ease.OutQuad);
        }
    }

    void RotationComplete()
    {
        rotating = false;
    }

    void ChangeShape()
    {

        currShapeIndex++;
        if(currShapeIndex > shapeList.Count - 1)
        {
            currShapeIndex = 0;
        }
        List<Vector2> shapeToMake = shapeList[currShapeIndex];

        if(crowdMove != null)
        {
            crowdMove = DOTween.Sequence();
        } else
        {
            crowdMove.Kill();
            OnCrowdMoveComplete();
        }

        int gridIndex = 0;
        foreach (SpriteRenderer gridElement in gridElements)
        {
            gridElement.transform.localPosition = new Vector3(shapeToMake[gridIndex].x, 0f, shapeToMake[gridIndex].y);
            gridElement.DOColor(new Color(1f, 1f, 1f, 1f), 0.75f);
            gridIndex++;
        }


        int personIndex = 0;
        foreach(CrowdController person in crowds)
        {
            crowdMove.Insert(personIndex * 0.1f, person.transform.DOLocalMove(new Vector3(shapeToMake[personIndex].x, 0, shapeToMake[personIndex].y), 1f)).SetEase(Ease.OutBack);
            personIndex++;
        }

        crowdMove.OnComplete(OnCrowdMoveComplete);

        crowdMove.Play();
    }

    void OnCrowdMoveComplete()
    {

        foreach (SpriteRenderer gridElement in gridElements)
        {
            gridElement.DOColor(new Color(1f, 1f, 1f, 0f), 0.1f);
        }
    }
}
