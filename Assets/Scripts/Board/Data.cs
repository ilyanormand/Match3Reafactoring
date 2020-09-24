using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public List<int> FruitArray;
    public bool addedToArray = false;
    private void Awake()
    {
        FruitArray = new List<int>();
    }
    void Start()
    {

    }

    private void WriteIntoFile(string path) 
    {
        StreamWriter sw = new StreamWriter(path + "/fruitArrayData.txt");
        for (int i = 0; i < FruitArray.Count; i++) 
        {
            sw.WriteLine(FruitArray[i]);
        }
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (addedToArray) 
        {
            WriteIntoFile(Application.dataPath);
            addedToArray = false;
        }*/
        
    }
}

