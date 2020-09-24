using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FruitGenerator : MonoBehaviour
{
    public GameObject fruitPrefab;
    public Data data;
    public int[] TypeOfFruit;
    void Start()
    {
        data = FindObjectOfType<Data>();
        GameObject fruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
        fruit.transform.parent = this.transform;
        int index = Random.Range(0, TypeOfFruit.Length);
        fruit.transform.GetChild(TypeOfFruit[index]).gameObject.SetActive(true);
        Debug.Log(data.FruitArray);
        data.FruitArray.Add(TypeOfFruit[index]);
        data.addedToArray = true;
    }
}

