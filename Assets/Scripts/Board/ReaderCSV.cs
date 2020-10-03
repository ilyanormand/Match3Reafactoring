using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class ReaderCSV : MonoBehaviour
{
    // Start is called before the first frame update
    public string path;
    string _path;
    public TextAsset textAsset;
    public List<int> ListOfTiles = new List<int>();
    public bool finish = false;
    public int level;
    object csvFile;
    /*void Awake()
    {
        _path = Application.streamingAssetsPath;
        Debug.Log("dataPath = " + _path);
        //path = _path + $"!/Assets/Levels/lvl{level}.csv";
        path = Application.persistenDataPath+"/"+"Resources/lvl1.csv";
        ReadFile();
    }*/

    void Awake()
    {
        //path = Path.Combine(Application.persistentDataPath, "lvl1.csv");
        textAsset = (TextAsset)Resources.Load("lvl1", typeof(TextAsset));
        Debug.Log("dataPath = " + Application.persistentDataPath);
        //path = Application.persistentDataPath + "/" + "lvl1.csv";
        //Debug.Log(csvFile);
        //Debug.Log(textAsset);
        //ReadFile();
        fileParse(textAsset);
    }

    private void ReadFile()
    {

        StreamReader strReader = new StreamReader(path);
        int i = 0;
        while (!strReader.EndOfStream || i == 100)
        {
            string line = strReader.ReadLine();
            string[] values = line.Split(',');
            foreach (string str in values)
            {
                //Debug.Log(str);
                ListOfTiles.Add(int.Parse(str));
            }
            // защита от бесконечного цикла
            i++;
        }
        finish = true;

        // Для просмотра контента внтури массива
        /*if (ListOfTiles != null)
        {
            foreach (string n in ListOfTiles)
            {
                Debug.Log(n);
            }
        }*/
    }

    public void fileParse(TextAsset csv) 
    {
        string text = csv.text;
        string[] lines = text.Split('\n', ',');

        foreach (string line in lines) 
        {
            ListOfTiles.Add(int.Parse(line));
        }

        finish = true;
    }
}
