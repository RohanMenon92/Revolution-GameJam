using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int movementRange;
    [SerializeField]
    public List<Vector2> shapeList1;
    [SerializeField]
    public List<Vector2> shapeList2;
    [SerializeField]
    public List<Vector2> shapeList3;
    [SerializeField]
    public List<Vector2> shapeList4;
    [SerializeField]
    public List<Vector2> shapeList5;

    public GameController gameController;

    int currShapeIndex = 0;
    bool rotating = false;
    bool moving = false;


    float xMax = 0;
    float xMin = 0;
    float yMax = 0;
    float yMin = 0;

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
        // Defining Shapes
        currShapeIndex = 0;
        shapeList = new List<List<Vector2>>();
        shapeList.Add(shapeList1);
        shapeList.Add(shapeList2);
        shapeList.Add(shapeList3);
        shapeList.Add(shapeList4);
        shapeList.Add(shapeList5);


        transform.position = new Vector3(0f,0f,0f);
        // Local element declaration
        initializeCrowd();
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

    void initializeCrowd()
    {
        gridElements = GetComponentInChildren<PlayerGrid>().GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer gridElement in gridElements)
        {
            gridElement.color = new Color(1f, 1f, 1f, 0f);
        }

        crowds = GetComponentsInChildren<CrowdController>();

        foreach (CrowdController person in crowds)
        {
            if (xMax < person.transform.position.x)
            {
                xMax = person.transform.position.x;
            }
            if (xMin > person.transform.position.x)
            {
                xMin = person.transform.position.x;
            }
            if (yMax < person.transform.position.z)
            {
                yMax = person.transform.position.z;
            }
            if (yMin > person.transform.position.z)
            {
                yMin = person.transform.position.z;
            }
        }
    }

    void MoveLeft(float amount = 1f)
    {
        if (!moving)
        {
            float limit = transform.localPosition.x + xMin;
            if (limit > -movementRange/2)
            {
                moving = true;
                transform.DOLocalMove((transform.localPosition + new Vector3(-amount, 0, 0)), 0.25f).SetEase(Ease.OutQuad).OnComplete(MoveComplete);
            }
        }
    }

    void MoveRight(float amount = 1f)
    {
        if (!moving)
        {
            float limit = transform.localPosition.x + xMax;
            Debug.Log("Limit " + limit);
            Debug.Log("Range " + ((movementRange / 2) - 1));

            if (limit < (movementRange / 2) - 1)
            {
                moving = true;
                transform.DOLocalMove((transform.localPosition + new Vector3(amount, 0, 0)), 0.25f).SetEase(Ease.OutQuad).OnComplete(MoveComplete);
            }
        }
    }
    void MoveComplete()
    {
        moving = false;
    }

    void RotateLeft()
    {
        if(rotating)
        {
            return;
        }

        Debug.Log("Rotate Left xMax / yMax");

        var temp = xMax;
        xMax = yMax;
        yMax = temp;
        temp = xMin;
        xMin = yMin;
        yMin = temp;
        rotating = true;
        transform.DORotate((transform.rotation.eulerAngles + new Vector3(0, 90f, 0)), 0.5f).OnComplete(RotationComplete).SetEase(Ease.OutQuad);
        if (xMax > movementRange / 2 - 1 - transform.localPosition.x)
        {
            MoveLeft(xMax);
        }

        if (xMin < -movementRange / 2 - transform.localPosition.x)
        {
            MoveRight(-xMin);
        }
    }

    void RotateRight()
    {
        if(rotating)
        {
            return;
        }
        Debug.Log("Rotate Right xMax / yMax");

        rotating = true;
        var temp = xMax;
        xMax = yMax;
        yMax = temp;
        temp = xMin;
        xMin = yMin;
        yMin = temp;
        transform.DORotate((transform.rotation.eulerAngles + new Vector3(0, -90f, 0)), 0.5f).OnComplete(RotationComplete).SetEase(Ease.OutQuad);
        if (xMax > movementRange / 2 - 1 - transform.localPosition.x)
        {
            MoveLeft(xMax);
        }

        if (xMin < -movementRange / 2 - transform.localPosition.x)
        {
            MoveRight(-xMin);
        }
    }

    void RotationComplete()
    {
        rotating = false;
    }

    void ChangeShape()
    {
        if (rotating)
        {
            return;
        }

        currShapeIndex++;
        if(currShapeIndex > shapeList.Count - 1)
        {
            currShapeIndex = 0;
        }
        List<Vector2> shapeToMake = shapeList[currShapeIndex];

        if(crowdMove != null)
        {
            crowdMove.Kill();
        }
        crowdMove = DOTween.Sequence();

        int gridIndex = 0;
        foreach (SpriteRenderer gridElement in gridElements)
        {
            gridElement.transform.localPosition = new Vector3(shapeToMake[gridIndex].x, 0f, shapeToMake[gridIndex].y);
            gridElement.DOColor(new Color(1f, 1f, 1f, 1f), 0.75f);
            gridIndex++;
        }


        int personIndex = 0;
        xMax = 0;
        xMin = 0;
        yMax = 0;
        yMin = 0;
        foreach (CrowdController person in crowds)
        {
            if (xMax < shapeToMake[personIndex].x)
            {
                xMax = shapeToMake[personIndex].x;
            }
            if (xMin > shapeToMake[personIndex].x)
            {
                xMin = shapeToMake[personIndex].x;
            }
            if (yMax < shapeToMake[personIndex].y)
            {
                yMax = shapeToMake[personIndex].y;
            }
            if (yMin > shapeToMake[personIndex].y)
            {
                yMin = shapeToMake[personIndex].y;
            }

            crowdMove.Insert(personIndex * 0.1f, person.transform.DOLocalMove(new Vector3(shapeToMake[personIndex].x, 0, shapeToMake[personIndex].y), 1f)).SetEase(Ease.OutBack);
            personIndex++;
        }

        if (Mathf.Round(transform.rotation.eulerAngles.y) == 90f || Mathf.Round(transform.rotation.eulerAngles.y) == 270f)
        {   
            var temp = xMax;
            xMax = yMax;
            yMax = temp;
            temp = xMin;
            xMin = yMin;
            yMin = temp;
        }

        if (xMax > movementRange/2-1 - transform.localPosition.x)
        {
            MoveLeft();
        }

        if (xMin < -movementRange / 2 - transform.localPosition.x)
        {
            MoveRight();
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

    public void OnObstacleHit(Transform crowdElement)
    {
        crowdElement.gameObject.SetActive(false);
        // TODO: Make this better
    }

    public void OnPickUpHit(Transform crowdElement)
    {
        // TODO: Add back/ReEnable a player if lost

        gameController.IncrementBoost();
        gameController.IncrementBoost();
    }

    public void OnSmokeTriggerHit(Transform crowdElement)
    {
        // TODO:Trigger Smoke for smoke tiles
    }
}
