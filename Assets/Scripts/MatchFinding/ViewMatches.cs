using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMatches : MonoBehaviour
{
    Data data;
    private void Start()
    {
        data = FindObjectOfType<Data>();
    }
    public void DestroyMatches() 
    {
        Debug.Log("DestroyMatches");
        Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);
        if (data.MatchedColumnIndexs.Count > 0) 
        {
            foreach (List<int[]> list in data.MatchedColumnIndexs)
            {
                foreach (int[] arr in list)
                {
                    //активировать анимацию у нужных элементов
                    Debug.Log($"[{arr[0]}, {arr[1]}]");
                    DesactivateMatches(arr[0], arr[1]);
                    //деактивировать анимацию
                }
            }
        }
        if (data.MatchedRowIndexs.Count > 0) 
        {
            foreach (List<int[]> list in data.MatchedRowIndexs) 
            {
                foreach (int[] arr in list) 
                {
                    DesactivateMatches(arr[0], arr[1]);
                }
            }
        }  
    }

    private void DesactivateMatches(int y, int x) 
    {
        GameObject fruit = data.GeneratedFruits[y, x];
        int spriteIndex = data.FruitArray[y, x];
        int randomSprite = Random.Range(0, 5);
        //desactivate child object
        fruit.transform.GetChild(spriteIndex).gameObject.SetActive(false);
        // activate another sprite randomly
        fruit.transform.GetChild(randomSprite).gameObject.SetActive(true);
        data.FruitArray[y, x] = randomSprite;
    }

   /* Data data;
    OnDestroying destroy;
    bool animationStart = false;
    void Start()
    {
        data = FindObjectOfType<Data>();
        destroy = FindObjectOfType<OnDestroying>();
    }

    private void DeactivatedMatchedFruits(List<int> indexArray, List<GameObject> fruitArray)
    {
        int spriteIndex;
        //data.WriteIntoFile(Application.dataPath);
        foreach (int index in indexArray)
        {
            //Debug.Log("Destroy: " + fruitArray[index].transform.parent.name);
            spriteIndex = data.FruitArray[index];
            
            if (fruitArray[index].transform.GetChild(spriteIndex).gameObject.activeInHierarchy) 
            {
                fruitArray[index].transform.GetChild(spriteIndex).gameObject.SetActive(false); // декативируем дочерний обьект 
                destroy.RandomActivationSprites(index, 5);
                //Debug.Log("Deactivate");
            }
        }
        
        //data.WriteIntoFile(Application.dataPath);
        data.GameWait = false;
        //Debug.Log("finish foreach");
    }

    private void Update()
    {
        //Debug.Log("matchesFinded = " + data.MatchesFinded);
        if (data.MatchesFinded == true)
        {
            DeactivatedMatchedFruits(data.MatchedFruitIndexs, data.GeneratedFruits);
            data.MatchedFruitIndexs.Clear();
            data.MatchesFinded = false;
            data.CheckMatches = true;
        }
        else
        {
            data.CheckMatches = true;
        }
    }*/
}
