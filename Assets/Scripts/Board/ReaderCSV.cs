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
    public int[,] ListOfTiles = new int[9, 9];
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

    public void fileParse(TextAsset csv) 
    {
        string text = csv.text;
        string[] lines = text.Split('\n', ',');
        int word = 0;
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++) 
            {
                ListOfTiles[y, x] = int.Parse(lines[word]);
                word++;
            }
        }
        finish = true;
    }
}
