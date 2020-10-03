using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatches : MonoBehaviour
{
    Data data;
    
    List<int> countedMatched;
    bool state = true;
    void Start()
    {
        data = FindObjectOfType<Data>();
        countedMatched = new List<int>();
    }
    void Update()
    {
        if (data.addedToArray && state == true) 
        {
            SearchRowMatches();
            SearchColumnMatches();
        }
    }

    // метод для поиска матчей по горизонтали

    public void SearchRowMatches() 
    {
        state = false;
        int b; // переменная которая хранит все себе следуйщий индекс массива
        int a = 0; // переменная которой присвоено первый индекс каждого ряда
        for (int i = 0; i <= 81; i++)
        {
            b = i + 1;
            //Debug.Log("i = " + i);
            if (b >= 81)
            {
                //Debug.Log("Limit");
                break;
            }
            //Debug.Log("a = " + a);
            if ((i - 8) == a) // проверка является ли i последним индексом в ряде
            {
                a = a + 9; 
                //Debug.Log("a = " + a);
                if (countedMatched.Count >= 2)  
                {
                    countedMatched.Add(i);
                    foreach (int index in countedMatched) 
                    {
                        Debug.Log("matchedIndex = " + index);
                        data.MatchedFruitIndexs.Add(index);
                    }
                }
                Debug.Log("clear Counted Matches");
                countedMatched.Clear(); // очищаем массив чтоб элемент другого ряда не взялся в матч
                continue;
            }
            if (data.FruitArray[i] == data.FruitArray[b])
            {
                Debug.Log("adding new index: " + i);
                countedMatched.Add(i);
            }
            else if(countedMatched.Count >= 2)
            {
                // добавляем эти индексы в финальный массив
                Debug.Log("adding new index: " + i);
                countedMatched.Add(i);
                Debug.Log("countedMatched.Count = " + countedMatched.Count);

                // добавляем все заматченные элементы в специальный массив для view
                foreach (int index in countedMatched)
                {
                    Debug.Log("matchedIndex = " + index);
                    data.MatchedFruitIndexs.Add(index);
                }
                countedMatched.Clear();
            }
            else
            {
                countedMatched.Clear();
            }
        }
        Debug.Log("data.MatchesFinded = " + data.MatchesFinded);
        if (data.MatchedFruitIndexs.Count >= 3) 
        {
            data.MatchesFinded = true;
        }
        Debug.Log("data.MatchesFinded = " + data.MatchesFinded);

    }

    // метод для поиска матчей по вертикали

    //TODO решить проблему почему не работает  скрипт
    public void SearchColumnMatches()
    {
        int x; // индекс сдвига
        int a = 0; // позиция первого элемента
        for (int i = 0; i < 9; i++) 
        {
            x = a + 9;
            if (x >= 81) 
            {
                break;
            }
            if (data.FruitArray[a] == data.FruitArray[x])
            {
                a = x;
                countedMatched.Add(a);
            }
            else if (countedMatched.Count >= 2)
            {
                a = x;
                foreach (int index in countedMatched)
                {
                    data.MatchedFruitIndexs.Add(index);
                }
                countedMatched.Clear();
            }
            else 
            {
                a = x;
                countedMatched.Clear();
            }
        }
    }


    

}
