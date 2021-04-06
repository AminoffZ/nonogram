using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNonogram : MonoBehaviour
{
    private static readonly int size = 4;

    Dictionary<List<string>, List<List<bool>>> gridDict
        = new Dictionary<List<string>, List<List<bool>>>();
    Dictionary<List<string>, List<List<int>>> numberDict
        = new Dictionary<List<string>, List<List<int>>>();

    System.Random rng = new System.Random();

    private void AddXList()
    {
        List<List<bool>> xDict = new List<List<bool>>();
        for (int i = 0; i < size; i++)
        {
            List<bool> xList = new List<bool>();
            for (int j = 0; j < size; j++)
            {
                xList.Add(rng.Next(0, 2) > 0);
            }
            xDict.Add(xList);
        }
        gridDict.Add(new List<string> { "X" }, xDict);
    }

    private void AddYList()
    {
        List<List<bool>> yDict = new List<List<bool>>();
        int count = 0;

        // Please help (it does work though)
        for (int i = 0; i < size; i++)
        {
            foreach (var item in gridDict)
            {
                List<bool> yList = new List<bool>();
                for (int j = 0; j < item.Value[count].Count; j++)
                {
                    yList.Add(item.Value[j][count]);
                }
                count++;
                yDict.Add(yList);
            }
        }
        
        gridDict.Add(new List<string> { "Y" }, yDict);
    }

    private List<int> CreateNumberList(List<bool> gridList)
    {
        List<int> numberList = new List<int>();
        int count = 0;
        foreach (bool isTrue in gridList)
        {
            if (isTrue)
            {
                count++;
            } else if (count > 0)
            {
                numberList.Add(count);
                count = 0;
            }
        }

        if (count > 0)
        {
            numberList.Add(count);
        }

        if (numberList.Count == 0)
        {
            numberList.Add(0);
        }

        return numberList;
    }

    private void AddClueList()
    {
        int axis = 0;

        foreach (var key in gridDict)
        {
            List<List<int>> numberList = new List<List<int>>();
            foreach (var gridList in key.Value)
            {
                numberList.Add(CreateNumberList(gridList));
            }
            if (axis == 0)
            {
                numberDict.Add(new List<string> { "X" }, numberList);
                axis++;
            } else
            {
                numberDict.Add(new List<string> { "Y" }, numberList);
            }
            
        }
    }


    // Update is called once per frame
    void Start()
    {
        AddXList();
        AddYList();
        AddClueList();

        // Check lists of booleans
        foreach (var item in gridDict)
        {
            Debug.Log(item.Key.ToString());
            foreach (var subSet in item.Value)
            {
                string result = string.Join(",", subSet);
                Debug.Log(result);
            }
        }

        foreach (var item in numberDict)
        {
            Debug.Log(item.Key.ToString());
            foreach (var subSet in item.Value)
            {
                string result = string.Join(",", subSet);
                Debug.Log(result);
            }
        }
    }
}
