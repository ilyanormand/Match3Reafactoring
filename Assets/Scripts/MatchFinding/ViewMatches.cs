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
    public void ScaleMatches() 
    {
        Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);
        /*foreach (List<int[]> n in data.MatchedFruitIndexs)
        {
            foreach (int[] f in n)
            {
                //активировать анимацию у нужных элементов
                data.GeneratedFruits[f[0], f[1]].transform.localScale = scale;
                //деактивировать анимацию
            }
        }*/
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
