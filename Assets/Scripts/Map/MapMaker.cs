using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public int[,] MapArray = new int[5, 10];
    bool IsFrontCompartmentWithi;
    //private bool m_bIsNewGame;

    private void Awake()
    {
       
        //var obj = FindObjectsOfType<MapMaker>();
        //if (obj.Length == 1)
        //{
        //    DontDestroyOnLoad(gameObject);
        //   // m_bIsNewGame = true;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

            MapMake();
        
    }

 

   
    private void MapMake()
    {
        MapArray[1, 0] = 1;
        MapArray[2, 0] = 1;
        MapArray[3, 0] = 1;
        MapArray[2, 9] = 1;

        for (int j = 1; j < 9; j++)
        {
     


            for (int i = 0; i < 5; i++)
            {
                int randomMapping = UnityEngine.Random.Range(-1, 2);

                if (MapArray[i,j-1]==1)
                {
                    
                    int MappingResult = i + randomMapping;

                    if (MappingResult <= 0)
                    {
                        MappingResult = 0;
                        MapArray[MappingResult+1, j] = 1;
                    }
                    if(MappingResult>=4)
                    {
                        MappingResult = 4;
                        MapArray[MappingResult-1, j] = 1;
                    }

                    MapArray[MappingResult, j] = 1;

                }


            }
        }
    }
}
