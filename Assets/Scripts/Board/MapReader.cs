using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapReader : MonoBehaviour
{
    
    //string[] TypeTiles = { "blank", "breakable", "concrete", "lock" }; // Типы Плиток\
    public GameObject TilePrefab;
    public GameObject TileRow;
    private Data data;
    ReaderCSV readerCSV; //Обьект для чтения csv
    public int Width = 9;
    public int Height = 9;
    
    void Start()
    {
        data = FindObjectOfType<Data>();
        data.widht = Width;
        data.height = Height;
        readerCSV = FindObjectOfType<ReaderCSV>();
        if (readerCSV.finish == true) // если readerCSV прочитал csv file
        {
            GenerateTiles2D(TileRow, TilePrefab, Width, Height);
            chooseType(readerCSV.ListOfTiles); // определить какой тип на каждый элемент массива котороый передает csv file
            readerCSV.finish = false;
            
        }
    }

    // активация вида плитки исходи из карты csv
    private void chooseType(int[,] mapList)
    {
        int rowPosition = 8;
        for (int y = 0; y < 9; y++)
        {
            if (rowPosition < 0) 
            {
                break;
            }
            for (int x = 0; x < 9; x++) 
            {
                int elementNumber = mapList[y, x];
                //Debug.Log(elementNumber);
                data.GeneratedTiles[rowPosition, x].transform.GetChild(elementNumber - 1).gameObject.SetActive(true);
            }
            rowPosition--;
        }
    }

    // генерация плиток на board
    private void GenerateTiles2D(GameObject TileRow, GameObject TileColumn, int width, int height) 
    {
        for (int y = height-1; y >= 0; y--) 
        {
            Vector2 positionRow = new Vector2(0, y);
            GameObject row = Instantiate(TileRow, positionRow, Quaternion.identity);
            row.transform.parent = this.transform;
            row.name = $"{y}";
            for (int x = 0; x < width; x++) 
            {
                Vector2 positionColumn = new Vector2(x, y);
                GameObject column = Instantiate(TileColumn, positionColumn, Quaternion.identity);
                column.transform.parent = row.transform;
                column.name = $"{x}";
                data.GeneratedTiles[y, x] = column;
            }
        }
    }
}
