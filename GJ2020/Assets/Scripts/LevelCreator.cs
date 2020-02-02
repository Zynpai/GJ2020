﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levels;

    public int noLevels = 5;

    public List<GameObject> visitedLevels;

    public float distancebetweenlevels = 200.0f;
      int prefabSize;

     public GameObject lastLevel;

    void Start() {
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Levels");
        FileInfo[] info = dir.GetFiles("*.prefab");
        prefabSize = info.Length;
       

        for(int i = 1; i < noLevels + 1; i++)
        {         

            /*Debug.Log("ON iteration: " + i.ToString());

            int rand = getRand(prefabSize - 1);
            Debug.Log("prefab size = " + prefabSize);
            Debug.Log("Should create a level " + rand.ToString());*/
            GameObject newLevel = Resources.Load<GameObject>("Levels/Level" + i.ToString());
            levels.Add(newLevel);
        }

       lastLevel = Resources.Load<GameObject>("Levels/FinalScene");

    //    string firstpart = "part" + firstnum.ToString();
        float totalx = 0.0f;;
      //  float furthestpoint = 0.0f;
       // float halfpoint = 0.0f;
       // float furthestpoint2 = 0.0f;

        Debug.Log("How many in levels: " + levels.Count);

        for(int r = 0; r < noLevels; r++)
        {
               Instantiate(levels[r], new Vector3(totalx, 0.0f, 0.0f), Quaternion.identity);
               totalx += distancebetweenlevels;
        }    
        Instantiate(lastLevel, new Vector3(totalx, 0.0f, 0.0f), Quaternion.identity);
    }

    public int getNextRoom()
    {
        int next = Random.Range(1, prefabSize);
        return next;
    }

    public int getRand(int rangemax)
    {
        int randnum = Random.Range(0, rangemax);
        return randnum;
    }

}
