using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterFinding : MonoBehaviour
{
    // Start is called before the first frame update
    Data data;
    int[] TypeOfBoosters = { 1, 2, 3, 4 }; // 1 = colBomb, 2 = rowBomb, 3 = candyBomb, 4 = colorBomb
    private void Start()
    {
        data = FindObjectOfType<Data>();
    }
    public void MakeBooster() // бомба которая взрывает ряд или колонку фишек
    {

        foreach (List<int[]> list in data.MatchedRowIndexs)
        {
            if (list.Count == 4)
            {
                MakeStrifeBomb(list);
            }
            else if (list.Count == 5)
            {
                MakeColorBomb(list);
            }
        }
        foreach (List<int[]> list in data.MatchedColumnIndexs)
        {
            if (list.Count == 4)
            {
                MakeStrifeBomb(list);
            }
            else if (list.Count >= 5)
            {
               MakeColorBomb(list);
            }
        }
        for (int i = 0; i < data.MatchedColumnIndexs.Count; i++)
        {
            for (int j = 0; j < data.MatchedRowIndexs.Count; j++)
            {
                //Debug.Log("data.MatchedRowIndexs.Count = " + data.MatchedRowIndexs.Count);
                CheckForCandyBomb(data.MatchedRowIndexs[j], data.MatchedColumnIndexs[i]);
            }
        }
    }

    private void CheckForCandyBomb(List<int[]> listRow, List<int[]> listColumn) // бобма которая взрывает фишки вокгру нее
    {
        foreach (int[] arr in listColumn)
        {
            foreach (int[] arr2 in listRow)
            {
                if (arr[0] == arr2[0] && arr[1] == arr2[1]) // находим пересечение двух масивов из матчей
                {
                    MakeCandyBomb(arr);
                }
            }
        }
    }


    private void MakeCandyBomb(int[] indexs)
    {
        int[] BoostersIndexs = new int[3];
        int spriteIndex = data.FruitArray[indexs[0], indexs[1]];
        GameObject fruit = data.GeneratedFruits[indexs[0], indexs[1]];
        BoostersIndexs[0] = indexs[0];
        BoostersIndexs[1] = indexs[1];
        BoostersIndexs[2] = TypeOfBoosters[2];
        fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[2]).gameObject.SetActive(true);
        fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[2]).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        data.CandyBoosters.Add(BoostersIndexs);
    }

    private void MakeColorBomb(List<int[]> matchedList)
    {
        int[] BoosterIndexs = new int[3];
        // берем первый элемента списка для создания на его месте бустера
        int spriteIndex = data.FruitArray[matchedList[0][0], matchedList[0][1]];
        GameObject fruit = data.GeneratedFruits[matchedList[0][0], matchedList[0][1]];
        BoosterIndexs[0] = matchedList[0][0];
        BoosterIndexs[1] = matchedList[0][1];
        BoosterIndexs[2] = TypeOfBoosters[3];
        // делаем из него другой спрайт
        fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[3]).gameObject.SetActive(true);
        fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[3]).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        data.ColorBoosters.Add(BoosterIndexs);
    }

    private void MakeStrifeBomb(List<int[]> matchedList)
    {
        int[] BoostersIndexs = new int[3];
        // берем первый элемента списка для создания на его месте бустера
        int spriteIndex = data.FruitArray[matchedList[0][0], matchedList[0][1]];
        GameObject fruit = data.GeneratedFruits[matchedList[0][0], matchedList[0][1]];
        BoostersIndexs[0] = matchedList[0][0];
        BoostersIndexs[1] = matchedList[0][1];
        int RowOrCol = Random.Range(1, 3);
        BoostersIndexs[2] = RowOrCol;
        if (RowOrCol == TypeOfBoosters[0])
        {
            fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[0]).gameObject.SetActive(true);
            fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[0]).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            data.ColBoosters.Add(BoostersIndexs);
        }
        else
        {
            fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[1]).gameObject.SetActive(true);
            fruit.transform.GetChild(spriteIndex).transform.GetChild(TypeOfBoosters[1]).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            data.RowBoosters.Add(BoostersIndexs);
        }
    }

    // массив для бустеров (карта)
    // массив для хранения
    // 
}
