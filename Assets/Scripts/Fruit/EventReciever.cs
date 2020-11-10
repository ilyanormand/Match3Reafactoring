using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReciever : MonoBehaviour
{

    public delegate void Array2DReturn();
    public delegate void SwipeEvent();
    public delegate void FillBoardEvent();
    public FindMatches findMatches;
    private void Awake()
    {
        findMatches = FindObjectOfType<FindMatches>();
        fruitController.MatchedFindEvent += findMatches.findMatch;
    }

    /*private Vector3 firstTouchPosition, finalTouchPosition;
    public float swipeAngle;
    public Data data;
    private void OnMouseDown()
    {
        if (data.GameWait == false) 
        {
            data.clickedObjectIndex = transform.parent.transform.GetSiblingIndex();
            data.clickedObject = this.gameObject;
            data.initPosSwipe = data.clickedObject.transform.position;
            //Debug.Log("data.clickedObject = " + data.clickedObject);
            //Debug.Log("nameClicked = " + transform.parent.name);
            //Debug.Log("indexClickedObject = " + data.clickedObjectIndex);
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // получаю позицию обьекта при клике
        }
        
    }

   

    private void OnMouseUp()
    {
        if (data.GameWait == false) 
        {
            data.clicked = true;
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
            //Debug.Log("SwipeAngle = " + swipeAngle);
            data.swipeIndex = SwipeIndexFinding();
        }
        
    }

    private void Start()
    {
        data = FindObjectOfType<Data>();
    }

    private int SwipeIndexFinding() 
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && swipeAngle != 0)
        {
            //Debug.Log("vector right");
            int newIndex = data.clickedObjectIndex + 1;
            //Debug.Log("newIndex = " + newIndex);
            data.vectorSwipe = data.GeneratedFruits[newIndex].transform.position; // сохраняем координаты обьекта для свайпа
            return newIndex;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && swipeAngle != 0)
        {
            //Debug.Log("vector up");
            int newIndex = data.clickedObjectIndex - data.widht;
            //Debug.Log("newIndex = " + newIndex);
            data.vectorSwipe = data.GeneratedFruits[newIndex].transform.position; // сохраняем координаты обьекта для свайпа
            return newIndex;
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && swipeAngle != 0)
        {
            //Debug.Log("vector left");
            int newIndex = data.clickedObjectIndex - 1;
            //Debug.Log("newIndex = " + newIndex);
            data.vectorSwipe = data.GeneratedFruits[newIndex].transform.position; // сохраняем координаты обьекта для свайпа
            return newIndex;
        }
       
        
        else if (swipeAngle < -45 && swipeAngle >= -135 && swipeAngle != 0)
        {
            //Debug.Log("vector down");
            int newIndex = data.clickedObjectIndex + data.widht;
            //Debug.Log("newIndex = " + newIndex);
            data.vectorSwipe = data.GeneratedFruits[newIndex].transform.position; // сохраняем координаты обьекта для свайпа
            return newIndex;
        }
        else
        {
            data.GameWait = false;
            return -1;
        }
        
    }*/

}
