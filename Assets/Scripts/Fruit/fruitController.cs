using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitController : MonoBehaviour
{
    public static event EventReciever.Array2DReturn MatchedFindEvent;
    public static event EventReciever.BoosterSearch BoosterFindEvent;
    Data data;

    private void Start()
    {
        data = FindObjectOfType<Data>();
    }

    private void OnMouseDown() 
    {
        data.x_clickedIndex = transform.parent.transform.GetSiblingIndex();
        data.y_clickedIndex = transform.parent.transform.parent.transform.GetSiblingIndex();
        MatchedFindEvent();
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
