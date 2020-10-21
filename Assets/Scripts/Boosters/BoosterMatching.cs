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
                            Debug.Log($"Matched {name} Bomb");
                            Debug.Log($"[{arr[0]}, {arr[1]}]");
                            boosterToMatch.Add(arr);
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
                            Debug.Log($"Matched {name} Bomb");
                            Debug.Log($"[{arr[0]}, {arr[1]}]");
                            boosterToMatch.Add(arr);
                        }
                    }
                }
            }
            ColumnBombMatching();
        }
    }

    private void ColumnBombMatching()
    {
        // добавить колонку в массив из матчей
        //[[y,x]] - booster array
        int count = 0;
        int[] tempArray = new int[2];
        List<int[]> tempList = new List<int[]>();
        foreach (int[] arr in boosterToMatch)
        {
            foreach (List<int[]> list in data.MatchedColumnIndexs)
            {
                foreach (int[] indexs in list)
                {
                    if (indexs[0] == arr[0])// определяем нужный нам бустер 
                    {
                        for (int i = 0; i < 9; i++) // цикл который добавляет все фишки в этой колонки в матч
                        {
                            count++;
                            if (count < list.Count)
                            {
                                if (i != list[count][0]) // защита от добавления одинаковых индексов
                                {
                                    tempArray[0] = arr[0];
                                    tempArray[1] = i;
                                    Debug.Log($"adding to array: [{tempArray[0]}, {tempArray[1]}]");
                                    tempList.Add(tempArray);
                                }
                            }
                        }
                    }
                }
            }
            data.MatchedColumnIndexs.Add(tempList);
        }

       /* int n = 0;
        foreach (List<int[]> list in data.MatchedColumnIndexs) 
        {
            n++;
            Debug.Log("ColumnBombMatching list: " + n);
            foreach (int[] arr in list) 
            {
                Debug.Log($"[{arr[0]}, {arr[1]}]");
            }
        }*/
    }

    private void RowBombMatching() 
    {
        
    }

    private void CandyBombMatching() 
    {
        
    }

    private void ColorBombMatching() 
    {
    
    }

}
