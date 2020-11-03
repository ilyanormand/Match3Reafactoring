using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMatching : MonoBehaviour
{
    Data data;
    List<int[]> boosterToMatch;
    private void Start()
    {
        boosterToMatch = new List<int[]>();
        data = FindObjectOfType<Data>();
    }
    public void findMatchedBoosterIndexs(List<int[]> boostersArray, List<List<int[]>> matchedColumnArray, List<List<int[]>> matchedRowArray, string name) 
    {
        if (boostersArray.Count > 0)
        {
            foreach (int[] boosters in boostersArray)
            {
                foreach (List<int[]> list in matchedColumnArray)
                {
                    foreach (int[] arr in list)
                    {
                        if (arr[0] == boosters[0] && arr[1] == boosters[1])
                        {
                            /*Debug.Log($"Matched {name} Bomb");
                            Debug.Log($"[{arr[0]}, {arr[1]}]");*/
                            boosterToMatch.Add(boosters);
                        }
                    }
                }
            }
            foreach (int[] boosters in boostersArray)
            {
                foreach (List<int[]> list in matchedRowArray)
                {
                    foreach (int[] arr in list)
                    {
                        if (arr[0] == boosters[0] && arr[1] == boosters[1])
                        {
                            /*Debug.Log($"Matched {name} Bomb");
                            Debug.Log($"[{arr[0]}, {arr[1]}]");*/
                            boosterToMatch.Add(boosters);
                        }
                    }
                }
            }
            if (name == "column")
            {
                ColumnBombMatching();
            }
            else if (name == "candy")
            {
                CandyBombMatching();
            }
            else if (name == "row")
            {
                RowBombMatching();
            }
        }
        
    }

    private void ColumnBombMatching()
    {
        foreach (int[] boosterIndexs in boosterToMatch) 
        {
            // Для начало нужно определить какой это тип бустера
            Debug.Log(boosterIndexs.Length);
            if (boosterIndexs[2] == 1) //1 = column Bomb
            {
                List<int[]> tempList = new List<int[]>(0);
                int x_pos = boosterIndexs[1];
                for (int i = 0; i < 9; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = i;
                    tempArr[1] = x_pos;
                    //Debug.Log("adding index: " + $"[{tempArr[0]}, {tempArr[1]}]");
                    tempList.Add(tempArr);
                }
                data.MatchedColumnIndexs.Add(tempList);
                GameObject fruit = data.GeneratedFruits[boosterIndexs[0], boosterIndexs[1]];
                int spriteIndex = data.FruitArray[boosterIndexs[0], boosterIndexs[1]];
                fruit.transform.GetChild(spriteIndex).transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            } 
            
        }
    }

    private void RowBombMatching() 
    {
        foreach (int[] boosterIndexs in boosterToMatch)
        {
            if (boosterIndexs[2] == 2) //  2 = row bomb match
            {
                List<int[]> tempList = new List<int[]>(0);
                int y_pos = boosterIndexs[0];
                for (int i = 0; i < 9; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = y_pos;
                    tempArr[1] = i;
                    //Debug.Log("adding index: " + $"[{tempArr[0]}, {tempArr[1]}]");
                    tempList.Add(tempArr);
                }
                data.MatchedRowIndexs.Add(tempList);
                GameObject fruit = data.GeneratedFruits[boosterIndexs[0], boosterIndexs[1]];
                int spriteIndex = data.FruitArray[boosterIndexs[0], boosterIndexs[1]];
                fruit.transform.GetChild(spriteIndex).transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void CandyBombMatching() 
    {
        foreach(int[] boosterIndexs in boosterToMatch) 
        {

            if (boosterIndexs[2] == 3) // 3 = candyBomb 
            {
                Debug.Log("запуск уничтожение candyBomb");
                int candy_y = boosterIndexs[0];
                int candy_x = boosterIndexs[1];
                List<int[]> tempRowMatchs = new List<int[]>();
                List<int[]> tempColumnMatchs = new List<int[]>();

                int x = -1;
                // matche row up
                for (int i = 0; i < 3; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = candy_y + 1;
                    tempArr[1] = candy_x + x;
                    if (tempArr[0] >= 0 && tempArr[1] >= 0 && tempArr[0] <= 8 && tempArr[1] <= 8)
                    {
                        tempRowMatchs.Add(tempArr);
                    }
                    x++;
                }

                //match row down
                x = -1;
                for (int i = 0; i < 3; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = candy_y - 1;
                    tempArr[1] = candy_x + x;
                    if (tempArr[0] >= 0 && tempArr[1] >= 0 && tempArr[0] <= 8 && tempArr[1] <= 8)
                    {
                        tempRowMatchs.Add(tempArr);
                    }
                    x++;
                }

                //match column left
                int y = -1;
                for (int i = 0; i < 3; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = candy_y + y;
                    tempArr[1] = candy_x - 1;
                    if (tempArr[0] >= 0 && tempArr[1] >=0 && tempArr[0] <= 8 && tempArr[1] <= 8) 
                    {
                        tempColumnMatchs.Add(tempArr);
                    }
                    y++;
                }

                //match column right
                y = -1;
                for (int i = 0; i < 3; i++)
                {
                    int[] tempArr = new int[2];
                    tempArr[0] = candy_y + y;
                    tempArr[1] = candy_x + 1;
                    if (tempArr[0] >= 0 && tempArr[1] >= 0 && tempArr[0] <= 8 && tempArr[1] <= 8)
                    {
                        tempColumnMatchs.Add(tempArr);
                    }
                    y++;
                }

                int[] indexBooster = new int[2];
                indexBooster[0] = candy_y;
                indexBooster[1] = candy_x;
                tempRowMatchs.Add(indexBooster);
                data.MatchedRowIndexs.Add(tempRowMatchs);
                data.MatchedColumnIndexs.Add(tempColumnMatchs);

                Debug.Log("Start patricle candy");
                //эффект взрыва
                int spriteIndex = data.FruitArray[indexBooster[0], indexBooster[1]];
                GameObject fruit = data.GeneratedFruits[indexBooster[0], indexBooster[1]];
                Debug.Log(fruit.transform.GetChild(spriteIndex));
                Debug.Log(fruit.transform.GetChild(spriteIndex).transform.GetChild(3));
                Debug.Log(fruit.transform.GetChild(spriteIndex).transform.GetChild(3).gameObject.transform.GetChild(1));
                fruit.transform.GetChild(spriteIndex).transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else 
            {
                Debug.Log("its not candy");
            }
        }
    }

    private void ColorBombMatching(int[] swipeIndex) 
    {
        foreach (int[] boosterIndexs in boosterToMatch) 
        {
            if (boosterIndexs[2] == 4) //4 = color Bomb
            {
                int spriteNumber = data.FruitArray[swipeIndex[0], swipeIndex[1]];
                List<int[]> ColorMatched = new List<int[]>();
                // Для начало нужно определить какой это тип бустера
                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (spriteNumber == data.FruitArray[y, x])
                        {
                            int[] tempArr = new int[2];
                            tempArr[0] = y;
                            tempArr[1] = x;
                            ColorMatched.Add(tempArr);
                        }
                    }
                }
            }
        }
        
    }
  
    
}
