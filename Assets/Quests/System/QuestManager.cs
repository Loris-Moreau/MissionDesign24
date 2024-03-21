using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    //public GameObject questPanelPrefab;
    //public Transform questParent;

    public List<QuestData> questsProgress = new List<QuestData>();
    private Dictionary<QuestData, GameObject> questVisualization = new Dictionary<QuestData, GameObject>();

    public void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else Instance = this;
    }
    
    public void TakeQuest(QuestData quest)
    {
        questsProgress.Add(quest);
        print("quest taken");
        //GameObject panel = Instantiate(questPanelPrefab, questParent);
        //panel.GetComponent<QuestPanel>().SetupQuest(quest);
        //questVisualization.Add(quest, panel);
    }

    public void CompleteQuest(QuestData quest)
    {
        if ( /*quest.itemReward.quantity != 0 ||*/ quest.itemReward.item != null)
        {
            Inventory.Instance.AddInventory(quest.itemReward.item);
        }

        Notify();
        questsProgress.Remove(quest);

        if (questVisualization.ContainsKey(quest))
        {
            //Destroy(questVisualization[quest]);
            //questVisualization.Remove(quest);
        }
    }

    public void Notify()
    {
        /*foreach (GameObject quest in questVisualization.Values)
        {
            QuestPanel panel = quest.GetComponent<QuestPanel>();
            panel.Notify();
        }*/
    }
}
