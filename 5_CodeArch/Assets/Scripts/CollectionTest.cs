using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    const int numberOfTests = 10000;

    int[] inventory = new int[numberOfTests];
    Dictionary<int, int> inventoryDic = new Dictionary<int, int>();
    List<int> inventoryList = new List<int>();
    HashSet<int> inventoryHash = new HashSet<int>();

    private void Start()
    {
        AddValuesInArray();
        AddValuesInDic();
        AddValuesInList();
        AddValuesInHash();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PrintValuesInArray();
            PrintValuesInDic();
            PrintValuesInList();
            PrintValuesInHash();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ContainsValuesInArray();
            ContainsValuesInDict();
            ContainsValuesInList();
            ContainsValuesInHash();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RemoveValuesInArray();
            RemoveValuesInDict();
            RemoveValuesInList();
            RemoveValuesInHash();
        }
    }

    #region Remove
    private void RemoveValuesInArray()
    {
        int index = 5000;
        int[] temp = new int[inventory.Length - 1];
        int tempCount = 0;

        for(int i = 0; i < inventory.Length; i++)
        {
            if(i != index)
            {
                temp[tempCount] = inventory[i];
                tempCount++;
            }
        }
        
        inventory = temp;
    }
    private void RemoveValuesInDict()
    {
        int searchValue = 5000;
        bool found = inventoryDic.Remove(searchValue);
    }
    private void RemoveValuesInList()
    {
        int searchValue = 5000;
        bool found = inventoryList.Remove(searchValue);
    }
    private void RemoveValuesInHash()
    {
        int searchValue = 5000;
        bool found = inventoryHash.Remove(searchValue);
    }
    #endregion

    #region Contains
    private void ContainsValuesInArray()
    {
        int searchValue = 5000;

        foreach(int i in inventory)
            if(inventory[i] == searchValue)
                return;
    }
    private void ContainsValuesInDict()
    {
        int searchValue = 5000;
        bool found = inventoryDic.ContainsKey(searchValue);
    }
    private void ContainsValuesInList()
    {
        int searchValue = 5000;
        bool found = inventoryList.Contains(searchValue);
    }
    private void ContainsValuesInHash()
    {
        int searchValue = 5000;
        bool found = inventoryHash.Contains(searchValue);
    }
    #endregion

    #region Print
    private void PrintValuesInArray()
    {
        foreach(int i in inventory)
            Debug.Log(i);
    }
    private void PrintValuesInDic()
    {
        foreach(KeyValuePair<int, int> i in inventoryDic)
            Debug.Log(i.Value);
    }
    private void PrintValuesInList()
    {
        foreach(int i in inventoryList)
            Debug.Log(i);
    }
    private void PrintValuesInHash()
    {
        foreach(int i in inventoryHash)
            Debug.Log(i);
    }
    #endregion

    #region Add
    private void AddValuesInArray()
    {
        for (int i = 0; i < numberOfTests; i++)
            inventory[i] = Random.Range(10, 100);
    }
    private void AddValuesInDic()
    {
        for (int i = 0; i < numberOfTests; i++)
            inventoryDic.Add(i, Random.Range(10, 100));
    }
    private void AddValuesInList()
    {
        for (int i = 0; i < numberOfTests; i++)
            inventoryList.Add(Random.Range(10, 100));
    }
    private void AddValuesInHash()
    {
        for (int i = 0; i < numberOfTests; i++)
            inventoryHash.Add(Random.Range(10, 100));
    }
    #endregion
}
