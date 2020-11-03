using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FindMatches : MonoBehaviour
{
    Data data;
    BoosterFinding boosterFinding;
    BoosterMatching boosterMatching;
    List<int[]> matchedList;
    int[] arrayInt;
    ViewMatches viewMatches;
    private void Start()
    {
        boosterFinding = FindObjectOfType<BoosterFinding>();
        boosterMatching = FindObjectOfType<BoosterMatching>();
        viewMatches = FindObjectOfType<ViewMatches>();
        matchedList = new List<int[]>();
        data = FindObjectOfType<Data>();        
    }
    public void findAllMatches() 
    {
        Debug.Log("Starting finding matches");
    }

    public void findMatch()
    {
        SearchRowMatch();
        SearchColumnMatch();
        if (data.MatchedColumnIndexs.Count > 0 && data.MatchedRowIndexs.Count > 0) 
        {
            /*boosterMatching.findMatchedBoosterIndexs(data.CandyBoosters, data.MatchedColumnIndexs, data.MatchedRowIndexs, "candy");
            boosterMatching.findMatchedBoosterIndexs(data.ColorBoosters, data.MatchedColumnIndexs, data.MatchedRowIndexs, "color");
            boosterMatching.findMatchedBoosterIndexs(data.ColBoosters, data.MatchedColumnIndexs, data.MatchedRowIndexs, "column");
            boosterMatching.findMatchedBoosterIndexs(data.RowBoosters, data.MatchedColumnIndexs, data.MatchedRowIndexs, "row");*/
            viewMatches.DestroyMatches();
            //boosterFinding.MakeBooster();
        }
        
        //Debug.Log($"[{data.y_clickedIndex}, {data.x_clickedIndex}]");
    }
    private void SearchColumnMatch() 
    {
        for (int x = 0; x < data.widht; x++) 
        {
            for (int y = 0; y < data.widht; y++)
            {
                if ((y + 1) > (data.widht-1)) 
                {
                    if (matchedList.Count >= 2)
                    {
                        arrayInt = new int[2];
                        arrayInt[0] = y;
                        arrayInt[1] = x;
                        matchedList.Add(arrayInt);

                        List<int[]> tempList = new List<int[]>();
                        foreach (int[] arr in matchedList)
                        {
                            tempList.Add(arr);
                        }
                        data.MatchedColumnIndexs.Add(tempList);
                        matchedList.Clear();
                    }
                    matchedList.Clear();
                    break;
                }
                if (data.FruitArray[y, x] == data.FruitArray[y + 1, x])
                {
                    arrayInt = new int[2];
                    arrayInt[0] = y;
                    arrayInt[1] = x;
                    matchedList.Add(arrayInt);
                }
                else if (matchedList.Count >= 2)
                {
                    arrayInt = new int[2];
                    arrayInt[0] = y;
                    arrayInt[1] = x;
                    matchedList.Add(arrayInt);

                    List<int[]> tempList = new List<int[]>();
                    foreach (int[] arr in matchedList)
                    {
                        tempList.Add(arr);
                    }
                    data.MatchedColumnIndexs.Add(tempList);
                    matchedList.Clear();
                }
                else
                {
                    matchedList.Clear();
                }
            }
        }
    }

    private void SearchRowMatch() 
    {
        for (int y = 0; y < data.widht; y++)
        {
            for (int x = 0; x < data.height; x++)
            {
                if ((x + 1) > (data.widht - 1))
                {
                    if (matchedList.Count >= 2) 
                    {
                        arrayInt = new int[2];
                        arrayInt[0] = y;
                        arrayInt[1] = x;
                        matchedList.Add(arrayInt);

                        List<int[]> tempList = new List<int[]>();
                        foreach (int[] arr in matchedList)
                        {
                            tempList.Add(arr);
                        }
                        data.MatchedRowIndexs.Add(tempList);
                        matchedList.Clear();
                    }
                    matchedList.Clear();
                    break;
                }
                if (data.FruitArray[y, x] == data.FruitArray[y, x + 1])
                {
                    arrayInt = new int[2];
                    arrayInt[0] = y;
                    arrayInt[1] = x;
                    matchedList.Add(arrayInt);
                }
                else if (matchedList.Count >= 2)
                {
                    arrayInt = new int[2];
                    arrayInt[0] = y;
                    arrayInt[1] = x;
                    matchedList.Add(arrayInt);

                    List<int[]> tempList = new List<int[]>();
                    foreach (int[] arr in matchedList)
                    {
                        tempList.Add(arr);
                    }
                    data.MatchedRowIndexs.Add(tempList);
                    matchedList.Clear();
                }
                else
                {
                    matchedList.Clear();
                }
            }
        }
    }

    
    

}
