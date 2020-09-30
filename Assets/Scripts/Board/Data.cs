using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public List<int> FruitArray;
    public List<GameObject> GeneratedTiles;
    public List<GameObject> GeneratedFruits;
    public bool addedToArray = false;
    public bool GameWait = false;
    public bool clicked = false;
    public bool swiped = false;
    public int widht;
    public int height;
    public int swipeIndex;
    public Vector3 vectorSwipe;
    public int clickedObjectIndex;
    public GameObject clickedObject;
    public fruitController fruitController;

    private void Awake()
    {
        GeneratedTiles = new List<GameObject>();
        fruitController = FindObjectOfType<fruitController>();
        FruitArray = new List<int>();
    }

    private void WriteIntoFile(string path) 
    {
        StreamWriter sw = new StreamWriter(path + "/fruitArrayData.txt");
        for (int i = 0; i < FruitArray.Count; i++) 
        {
            sw.WriteLine(FruitArray[i]);
        }
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (addedToArray)
        {
            foreach (int k in FruitArray) 
            {
                Debug.Log(k);
            }
            addedToArray = false;
        }*/

    }
}

