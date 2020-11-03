using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitController : MonoBehaviour
{
    public static event EventReciever.Array2DReturn MatchedFindEvent;
    public static event EventReciever.SwipeEvent SwipeEvent;
    Data data;
    private Vector3 firstTouchPosition, finalTouchPosition;
    private float swipeAngle;
    public float speedOfSwipe;
    bool anim = false;

    private void Start()
    {
        data = FindObjectOfType<Data>();
    }

    private void OnMouseDown() 
    {
        data.x_clickedIndex = transform.parent.transform.GetSiblingIndex();
        data.y_clickedIndex = transform.parent.transform.parent.transform.GetSiblingIndex();
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // получаю позицию обьекта при клике(по глобальным координатам)
        data.initPosSwipe = data.GeneratedFruits[data.y_clickedIndex, data.x_clickedIndex].transform.position;
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        data.swipeIndexs = GetSwipeIndex(); //  получаем массив элементов которыем менят с собой местами
        anim = true;
    }

    private int[,] AddSwipeIndexs(int y, int x, int y_direction, int x_direction, int[,] arr) //  добавляет нужные индексы в массив
    {
        if ((y + y_direction) <= 8 && (y + y_direction) >= 0 && (x + x_direction) <= 8 && (x + x_direction) >= 0) // условие чтобы нельязы было свайпнуть за край
        {
            arr[0, 0] = y;
            arr[0, 1] = x;
            arr[1, 0] = y + y_direction;
            arr[1, 1] = x + x_direction;
            return arr;
        }
        else 
        {
            arr[0, 0] = -1;
            arr[0, 1] = -1;
            arr[1, 0] = -1;
            arr[1, 1] = -1;
            return arr;
        }
        
    } 
    
    private int[,] GetSwipeIndex() // получает массив для свайпа исходя из направелния свайпа
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
        Debug.Log(swipeAngle);
        int[,] swipeIndexs = new int[2, 2];

        if (swipeAngle > -45 && swipeAngle <= 45 && swipeAngle != 0)
        {
            //right swipe
            swipeIndexs = AddSwipeIndexs(data.y_clickedIndex, data.x_clickedIndex, 0, 1, swipeIndexs);
            data.vectorSwipe = data.GeneratedFruits[swipeIndexs[1, 0], swipeIndexs[1, 1]].transform.position;
            return swipeIndexs;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && swipeAngle != 0)
        {
            //up swipe
            Debug.Log("Swipe Up");
            swipeIndexs = AddSwipeIndexs(data.y_clickedIndex, data.x_clickedIndex, -1, 0, swipeIndexs);
            data.vectorSwipe = data.GeneratedFruits[swipeIndexs[1, 0], swipeIndexs[1, 1]].transform.position;
            return swipeIndexs;
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && swipeAngle != 0)
        {
            //left swipe
            swipeIndexs = AddSwipeIndexs(data.y_clickedIndex, data.x_clickedIndex, 0, -1, swipeIndexs);
            data.vectorSwipe = data.GeneratedFruits[swipeIndexs[1, 0], swipeIndexs[1, 1]].transform.position;
            return swipeIndexs;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && swipeAngle != 0)
        {
            //down swipe
            swipeIndexs = AddSwipeIndexs(data.y_clickedIndex, data.x_clickedIndex, 1, 0, swipeIndexs);
            data.vectorSwipe = data.GeneratedFruits[swipeIndexs[1, 0], swipeIndexs[1, 1]].transform.position;
            return swipeIndexs;
        }
        else
        {
            swipeIndexs[0, 0] = -1;
            return swipeIndexs;
        }
    }

    private void changeArrPosition(int[,] arr) 
    {
        if (arr[0,0] != -1) 
        {
            GameObject firstFruit = data.GeneratedFruits[arr[0,0], arr[0, 1]];
            int spriteNumber1 = data.FruitArray[arr[0, 0], arr[0, 1]];
            int spriteNumber2 = data.FruitArray[arr[1, 0], arr[1, 1]];
            GameObject secondFruit = data.GeneratedFruits[arr[1, 0], arr[1, 1]];

            firstFruit.transform.GetChild(spriteNumber1).gameObject.SetActive(false);
            secondFruit.transform.GetChild(spriteNumber2).gameObject.SetActive(false);
            firstFruit.transform.GetChild(spriteNumber2).gameObject.SetActive(true);
            secondFruit.transform.GetChild(spriteNumber1).gameObject.SetActive(true);

            // обновляем массив
            data.FruitArray[arr[0, 0], arr[0, 1]] = spriteNumber2;
            data.FruitArray[arr[1, 0], arr[1, 1]] = spriteNumber1;

            //MatchedFindEvent();
        }
        
    }

    private void SwipeAnimation(GameObject firstFruit, GameObject secondFruit) 
    {
        Vector3 initPos = data.GeneratedFruits[data.swipeIndexs[0, 0], data.swipeIndexs[0, 1]].transform.position;
        Debug.Log("initPos, swipeIndexs = " + $"[{data.swipeIndexs[0, 0]}, {data.swipeIndexs[0, 1]}]");
        Debug.Log("initPos = " + initPos);
        Vector3 swipePos = data.GeneratedFruits[data.swipeIndexs[1, 0], data.swipeIndexs[1, 1]].transform.position;
        Debug.Log("swipePos, swipeIndexs = " + $"[{data.swipeIndexs[1, 0]}, {data.swipeIndexs[1, 1]}]");
        Debug.Log("swipePos = " + swipePos);
        if (speedOfSwipe < 1f)
        {
            speedOfSwipe += 0.15f;
            Debug.Log("initPosSwipe = " + data.initPosSwipe);
            Debug.Log("vectorSwipe = " + data.vectorSwipe);
            firstFruit.transform.position = Vector3.Lerp(data.initPosSwipe, data.vectorSwipe, speedOfSwipe);
            secondFruit.transform.position = Vector3.Lerp(data.vectorSwipe, data.initPosSwipe, speedOfSwipe);
        }
        else if (firstFruit.transform.position == data.vectorSwipe && secondFruit.transform.position == data.initPosSwipe)
        {
            speedOfSwipe = 0;
            changeArrPosition(data.swipeIndexs);
            anim = false;
        }
    }

    private void Update()
    {
        if (anim) 
        {
            SwipeAnimation(data.GeneratedFruits[data.swipeIndexs[0,0], data.swipeIndexs[0, 1]], data.GeneratedFruits[data.swipeIndexs[1, 0], data.swipeIndexs[1, 1]]);
        }
    }
    /*Data data;
    List<int> fruitList;
    private int SpriteNumber;
    GameObject firstFruit;
    GameObject secondFruit;
    public float speedOfSwipe;
    private bool swiped = false;
    void Start()
    {
        data = FindObjectOfType<Data>();
        fruitList = new List<int>();
    }
    // обработчик событий по клику на экран


    private void changeArrPosition(List<int> array) 
    {
        //Debug.Log("changeArrPosition()");
        if (data.swipeIndex != -1)
        {
            firstFruit = data.GeneratedFruits[data.clickedObjectIndex];
            //Debug.Log("firstFruit = " + firstFruit.transform.parent.name);
            SpriteNumber = array[data.clickedObjectIndex];
            //Debug.Log("SwipeIndex = " + data.swipeIndex);
            secondFruit = data.GeneratedFruits[data.swipeIndex];
            //Debug.Log("secondFruit = " + secondFruit.transform.parent.name);

            firstFruit.transform.position = data.initPosSwipe;
            secondFruit.transform.position = data.vectorSwipe;

            firstFruit.transform.GetChild(SpriteNumber).gameObject.SetActive(false);
            secondFruit.transform.GetChild(array[data.swipeIndex]).gameObject.SetActive(false);
            firstFruit.transform.GetChild(array[data.swipeIndex]).gameObject.SetActive(true);
            secondFruit.transform.GetChild(array[data.clickedObjectIndex]).gameObject.SetActive(true);

            // обновляем массив
            fruitList[data.clickedObjectIndex] = array[data.swipeIndex]; // обновления спрайта первого фрукта в массиве
            //Debug.Log("fruitList[data.clickedObjectIndex] = " + fruitList[data.clickedObjectIndex]);
            fruitList[data.swipeIndex] = SpriteNumber; // обновления спрайта второго фрукта в массиве
            //Debug.Log("fruitList[data.swipeIndex] = " + fruitList[data.swipeIndex]);
            data.CheckMatches = true;
        }
        
    }

    private void swipeAnimation(List<int> array) 
    {
        if (data.swipeIndex != -1) 
        {
            //Debug.Log("swipeAnimation()");
            firstFruit = data.GeneratedFruits[data.clickedObjectIndex];
            secondFruit = data.GeneratedFruits[data.swipeIndex];
            if (speedOfSwipe < 1f)
            {
                speedOfSwipe += 0.15f;
                firstFruit.transform.position = Vector3.Lerp(data.initPosSwipe, data.vectorSwipe, speedOfSwipe);
                secondFruit.transform.position = Vector3.Lerp(data.vectorSwipe, data.initPosSwipe, speedOfSwipe);
            }
            else if(firstFruit.transform.position == data.vectorSwipe && secondFruit.transform.position == data.initPosSwipe)
            {
                data.clicked = false;
                speedOfSwipe = 0;
                changeArrPosition(fruitList);
            }   
        }
    }

    private void Update()
    {
        *//*if (data.clicked == true)
        {
            fruitList = data.FruitArray;
            swipeAnimation(fruitList);
        }*//*
    }*/
}
