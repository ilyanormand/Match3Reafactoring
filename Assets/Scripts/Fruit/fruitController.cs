using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitController : MonoBehaviour
{
    Data data;
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


    private IEnumerator changeArrPosition(List<int> array) 
    {
        yield return new WaitForSeconds(0.0001f);
        Debug.Log("Start co routine");
        if (data.swipeIndex != -1)
        {
            firstFruit.transform.GetChild(SpriteNumber).gameObject.SetActive(false);
            secondFruit.transform.GetChild(array[data.swipeIndex]).gameObject.SetActive(false);
            firstFruit.transform.GetChild(array[data.swipeIndex]).gameObject.SetActive(true);
            secondFruit.transform.GetChild(array[data.clickedObjectIndex]).gameObject.SetActive(true);

            // обновляем массив
            fruitList[data.clickedObjectIndex] = array[data.swipeIndex]; // обновления спрайта первого фрукта в массиве
            Debug.Log("fruitList[data.clickedObjectIndex] = " + fruitList[data.clickedObjectIndex]);
            fruitList[data.swipeIndex] = SpriteNumber; // обновления спрайта второго фрукта в массиве
            Debug.Log("fruitList[data.swipeIndex] = " + fruitList[data.swipeIndex]);
        }
        
    }

    private void swipeAnimation(List<int> array) 
    {
        if (data.swipeIndex != -1) 
        {
            firstFruit = data.GeneratedFruits[data.clickedObjectIndex];
            Debug.Log("firstFruit = " + firstFruit.transform.parent.name);
            SpriteNumber = array[data.clickedObjectIndex];
            Debug.Log("SwipeIndex = " + data.swipeIndex);
            secondFruit = data.GeneratedFruits[data.swipeIndex];
            Debug.Log("secondFruit = " + secondFruit.transform.parent.name);

            float step = speedOfSwipe * Time.deltaTime;
            firstFruit.transform.position = Vector3.MoveTowards(firstFruit.transform.position, secondFruit.transform.position, step);
            secondFruit.transform.position = Vector3.MoveTowards(secondFruit.transform.position, firstFruit.transform.position, step);
            Debug.Log("iiii");
        }
    }

    private void Update()
    {
        if (data.clicked == true)
        {
            fruitList = data.FruitArray;
            swipeAnimation(fruitList);
            //StartCoroutine(changeArrPosition(fruitList));
        }
    }
}
