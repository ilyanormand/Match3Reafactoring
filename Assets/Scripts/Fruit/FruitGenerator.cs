using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FruitGenerator : MonoBehaviour
{
    
    public GameObject fruitPrefab;
    public Data data;
    public int[] TypeOfFruit; // elements are made in scene unity manually

    void Start()
    {
        data = FindObjectOfType<Data>(); // найти более оптимизированый способ нахождения обьекта
        int x = transform.GetSiblingIndex();
        int y = transform.parent.transform.GetSiblingIndex();
        GameObject fruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
        fruit.transform.parent = this.transform;
        int index = Random.Range(0, TypeOfFruit.Length);
        fruit.transform.GetChild(TypeOfFruit[index]).gameObject.SetActive(true);
        //Debug.Log(data.FruitArray);
        data.FruitArray[y, x] = TypeOfFruit[index];
        data.addedToArray = true;
        data.GeneratedFruits[y, x] = fruit;

    }
}

