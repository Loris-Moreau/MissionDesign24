using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestNpc : Interactive
{
    public List<QuestData> quests = new List<QuestData>();
    protected bool gaveQuest = false;
    protected int current = 0;

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.CompareTag("interactBox"))
        {
            //print("BOB");
            OnInteraction();
        }

    }

    public override void OnInteraction()
    {
        // transform.LookAt(Inventory.Instance.transform.position);

        if (gaveQuest && Inventory.Instance.HasEveryItem(requiredItems))
        {
            ThanksMessage();
        }

        if (!gaveQuest)
        {
            GiveQuest();
        }
        
        /*if (quests.Count > 0 && current < quests.Count)
        {
            QuestUI.Instance.SetupQuest(quests[current], this);
        }*/

        PlayerInteraction.Instance.StopInteractive();
    }

    public virtual void GiveQuest()
    {
        if (quests.Count > 0 && current < quests.Count)
        {
            gaveQuest = true;
            waitForObject = true;
            
            QuestManager.Instance.TakeQuest(quests[current]);
            
            //Setting up requirements to finish quests
            foreach (QuestItem item in quests[current].requirements)
            {
                requiredItems.Add(item);
            }
            
            Debug.Log("Insanity");
        }
    }
    
    void ThanksMessage()
    {
        QuestUI.Instance.ThankYouMessage();
        FinishQuest();
    }

    public virtual void FinishQuest()
    {
        //Dialogue end quest
        foreach (QuestItem required in quests[current].requirements)
        {
            Inventory.Instance.RemoveFromInventory(required.item);
            //Inventory.Instance.RemoveFromInventory(requiredItems);
        }

        QuestManager.Instance.CompleteQuest(quests[current]);

        waitForObject = false;
        requiredItems.Clear();
        current++;
        gaveQuest = false;

        if (current == quests.Count)
        {
            Destroy(this);
        }
        else
        {
            Invoke("GiveQuest", 1f);
        }
    }
}
