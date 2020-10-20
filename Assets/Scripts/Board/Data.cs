using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public int [,] FruitArray; //sprite numbers
    public GameObject[,] GeneratedTiles;
    public GameObject[,] GeneratedFruits; // all fruit gameobject on the board
    public List<List<int[]>> MatchedRowIndexs;
    public List<List<int[]>> MatchedColumnIndexs;
    public bool addedToArray = false;
    public bool GameWait = false;
    public bool clicked = false;
    public bool swiped = false;
    public bool MatchesFinded = false;
    public bool CheckMatches = true;
    public int widht;
    public int height;
    public int swipeIndex;
    public Vector3 vectorSwipe;
    public Vector3 initPosSwipe;
    public int x_clickedIndex;
    public int y_clickedIndex;
    public fruitController fruitController;

    private void Awake()
    {
        MatchedRowIndexs = new List<List<int[]>>();
        MatchedColumnIndexs = new List<List<int[]>>();
        GeneratedTiles = new GameObject[9,9];
        fruitController = FindObjectOfType<fruitController>();
        FruitArray = new int[9,9];
        GeneratedFruits = new GameObject[9, 9];
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

