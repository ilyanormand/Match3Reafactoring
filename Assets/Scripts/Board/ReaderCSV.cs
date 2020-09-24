using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReaderCSV : MonoBehaviour
{
    // Start is called before the first frame update
    public string path;
    string _path;
    public List<int> ListOfTiles = new List<int>();
    public bool finish = false;
    public int level;
    void Awake()
    {
        _path = Application.dataPath;
        Debug.Log("dataPath = " + _path);
        path = _path + $"/Levels/lvl{level}.csv";
        ReadFile();
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

}
