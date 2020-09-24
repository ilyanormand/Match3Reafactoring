using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FruitReader : MonoBehaviour
{
    
    //string[] TypeTiles = { "blank", "breakable", "concrete", "lock" }; // Типы Плиток\
    public GameObject TilePrefab;
    ReaderCSV readerCSV; //Обьект для чтения csv
    public int Width = 9;
    public int Height = 9;
    public float PaddingX = 1.2f;
    public float PaddingY = 1.2f;
    private List<GameObject> GeneratedTiles;
    void Start()
    {
        GeneratedTiles = new List<GameObject>();
        readerCSV = FindObjectOfType<ReaderCSV>();
        if (readerCSV.finish == true) // если readerCSV прочитал csv file
        {
            GenerateTiles(TilePrefab, Width, Height, PaddingX, PaddingY);
            chooseType(readerCSV.ListOfTiles); // определить какой тип на каждый элемент массива котороый передает csv file
            readerCSV.finish = false;

        }
        else
        {
            //Debug.Log("readerCSV is not finished his work!");
        }
    }

    private void chooseType(List<int> mapList)
    {
        //Debug.Log("ListOfTiles.Count = " + mapList.Count);
        //int TypeTilesLen = TypeTiles.Length; // закешировали длину TypeTiles
        for (int i = 0; i < mapList.Count; i++)
        {
            int elementNumber = mapList[i];
            //string type = TypeTiles[elementNumber];
            GeneratedTiles[i].transform.GetChild(elementNumber-1).gameObject.SetActive(true);
        }
    }

    private void GenerateTiles(GameObject prefab, int width, int height, float x_padding, float y_padding)  
    {
        //Debug.Log("Start generating");
        for (int i = width; i > 0; i--) 
        {
            for (int j = 0; j < height; j++)
            {
                //Vector2 position = new Vector2(-4.78f +(x_padding *(j % width)), -4 + (y_padding * (i % height)));
                Vector2 position = new Vector2(j, i);
                Debug.Log("vector position generation = " + position);
                GameObject tile = Instantiate(prefab, position, Quaternion.identity);
                tile.transform.parent = this.transform;
                tile.name = "(" + i + ", " + j + ")";
                GeneratedTiles.Add(tile);
            }
        }
    }

}
