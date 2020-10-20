using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroying : MonoBehaviour
{
    // Start is called before the first frame update
    Data data;
    GameObject fruit;
    public float speedOfFalling;
    public float TimeOfFalling;
    public bool fall = false;
    void Start()
    {
        data = FindObjectOfType<Data>();
    }


    /*public void RandomActivationSprites (int indexFruit, int lenArray) // простой рандом 50/50
    {
        int index = Random.Range(0, lenArray);
        data.GeneratedFruits[indexFruit].transform.GetChild(index).gameObject.SetActive(true);
        //fallAnimation(indexFruit);
        // обновление массива
        data.FruitArray[indexFruit] = index;   
    }*/

    /*public void fallAnimation(int index) 
    {
        fruit = data.GeneratedFruits[index];
        
        Vector3 initPosition = fruit.transform.position;
        Vector3 fallPosition = new Vector3(fruit.transform.position.x, 11, 0);
        fruit.transform.position = fallPosition;
        int i = 0;
        while (fall == false) 
        {
            float step = speedOfFalling * Time.deltaTime;
            fruit.transform.position = Vector3.MoveTowards(fallPosition, initPosition, step);
            if (fruit.transform.position == initPosition) 
            {
                fall = true;
            }
            if (i == 10000) 
            {
                break;
            }
        }

    }*/

}
