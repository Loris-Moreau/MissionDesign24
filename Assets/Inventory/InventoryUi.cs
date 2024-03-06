using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    public static InventoryUi Instance;

    public Dictionary<QuestItem, GameObject> inventory = new Dictionary<QuestItem, GameObject> ();
    public Transform inventoryContainer;
    public GameObject inventorySlotPrefab;


    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        //for(int i=0;i<Inventory.MaxInventory();i++)
        //{
        //    inventory.Add(Instantiate(inventorySlotPrefab, inventoryContainer));
        //    inventory[i].SetActive(false);
        //}
    }
    public void AddInvUI(QuestItem i)
    {
        if (inventory.ContainsKey(i)) return;
        inventory.Add(i, Instantiate(inventorySlotPrefab, inventoryContainer));
        inventory[i].transform.GetChild(0).GetComponent<Image>().sprite = i.item.icon;
    }

    public void RemoveInvUI(QuestItem i)
    {
        if (inventory.ContainsKey(i))
        {
            Destroy(inventory[i]);
            inventory.Remove(i);
        }
        //inventory[invCount - 1].SetActive(false);
    }
}
