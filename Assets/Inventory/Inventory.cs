using Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<QuestItem> inventory;
    public QuestItem soTest;
    public Transform[] displayInv;
    public int inventoryCapacity;
    public int inventoryCount;

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
         inventoryCount = 0;
    }


    void Update()
    {
        for (int i = 0; i < inventoryCount; i++)
        {
            //Instantiate(inventory[i].sprite, displayInv[inventoryCount-1]);
            Debug.Log("Display inventaire");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            AddInventory(soTest);
        }
        if (Input.GetKey(KeyCode.N))
        {
            RemoveFromInventory(soTest);
        }
    }

    public void AddInventory(QuestItem i)
    {
        if(inventoryCount == inventoryCapacity)
        {
            //message erreur
        }
        else
        {
            inventoryCount++;
            Debug.Log("+1 dans l'inventaire !");
            inventory.Add(i);
        }
    }

    public void RemoveFromInventory(QuestItem i)
    {
        if (inventoryCount == 0)
        {
            //message erreur
        }
        else
        {
            inventoryCount--;
            Debug.Log("-1 dans l'inventaire !");
            inventory.Remove(i);
        }
    }
}
