using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMatches : MonoBehaviour
{
    Data data;
    void Start()
    {
        data = FindObjectOfType<Data>();
    }

    private void DeactivatedMatchedFruits(List<int> indexArray, List<GameObject> fruitArray) 
    {
        data.MatchesFinded = false;
        foreach (int index in indexArray) 
        {
            Debug.Log("Destroy: " + fruitArray[index].transform.parent.name);
            Destroy(fruitArray[index]);
        }
    }

    void Update()
    {
        if (data.MatchesFinded == true) 
        {
            DeactivatedMatchedFruits(data.MatchedFruitIndexs, data.GeneratedFruits);
        }
    }
}
