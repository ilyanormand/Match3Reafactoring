using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public int [,] FruitArray; //sprite numbers
    public GameObject[,] GeneratedTiles;
    public GameObject[,] GeneratedFruits; // all fruit gameobject on the board
    public List<int[]> ColBoosters;
    public List<int[]> RowBoosters;
    public List<int[]> CandyBoosters;
    public List<int[]> ColorBoosters;
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
    public int[,] swipeIndexs;
    public Vector3 vectorSwipe;
    public Vector3 initPosSwipe;
    public int x_clickedIndex;
    public int y_clickedIndex;
    public fruitController fruitController;

    private void Awake()
    {
        ColBoosters = new List<int[]>();
        RowBoosters = new List<int[]>();
        CandyBoosters = new List<int[]>();
        ColorBoosters = new List<int[]>();
        MatchedRowIndexs = new List<List<int[]>>();
        MatchedColumnIndexs = new List<List<int[]>>();
        GeneratedTiles = new GameObject[9,9];
        fruitController = FindObjectOfType<fruitController>();
        FruitArray = new int[9,9];
        GeneratedFruits = new GameObject[9, 9];
        swipeIndexs = new int[2, 2];
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

