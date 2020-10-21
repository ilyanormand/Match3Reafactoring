using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterFinding : MonoBehaviour
{
    // Start is called before the first frame update
    Data data;
    public Sprite spriteStrife;
    public Sprite spriteColorBomb;
    public Sprite candyBomb;
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
                MakeStrifeBomb(spriteStrife, list);
            }
            else if(list.Count == 5)
            {
                MakeColorBomb(spriteColorBomb, list);
            }
        }
        foreach (List<int[]> list in data.MatchedColumnIndexs)
        {
            if (list.Count == 4)
            {
                MakeStrifeBomb(spriteStrife, list);
            }
            else if (list.Count >= 5)
            {
                MakeColorBomb(spriteColorBomb, list);
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
        int spriteIndex = data.FruitArray[indexs[0], indexs[1]];
        GameObject fruit = data.GeneratedFruits[indexs[0], indexs[1]];
        fruit.transform.GetChild(spriteIndex).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = candyBomb;
        data.CandyBoosters.Add(indexs);
    }

    private void MakeColorBomb(Sprite colorBomb, List<int[]> matchedList) 
    {
        // сделать colorBomb
        // берем первый элемента списка для создания на его месте бустера
        int spriteIndex = data.FruitArray[matchedList[0][0], matchedList[0][1]];
        GameObject fruit = data.GeneratedFruits[matchedList[0][0], matchedList[0][1]];
        // делаем из него другой спрайт
        fruit.transform.GetChild(spriteIndex).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = colorBomb;
        data.ColorBoosters.Add(matchedList[0]);
    }

    private void MakeStrifeBomb(Sprite strifeImage, List<int[]> matchedList)
    {
        // берем первый элемента списка для создания на его месте бустера
        int spriteIndex = data.FruitArray[matchedList[0][0], matchedList[0][1]]; 
        GameObject fruit = data.GeneratedFruits[matchedList[0][0], matchedList[0][1]];
        // делаем из него другой спрайт
        fruit.transform.GetChild(spriteIndex).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = strifeImage;
        data.ColBoosters.Add(matchedList[0]);
    }
    // массив для бустеров (карта)
    // массив для хранения
    // 
}
