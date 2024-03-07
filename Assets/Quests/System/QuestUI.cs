using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public static QuestUI instance;
    public Dictionary<QuestData, GameObject> questPanel = new Dictionary<QuestData, GameObject>();
    public Transform questPanelContainer;
    public GameObject questPrefab;

    public TextMeshPro textTitle;

    public void Awake()
    {
        instance = this;
    }

    public void AddQuest(QuestData quest)
    {
        textTitle.text = quest.title;
        for (int i = 0; i < quest.subObjectif.Count; i++) 
        {
            Instantiate(questPrefab, questPanelContainer);
            
        }

    }

    public void RemoveQuest(QuestData quest)
    {

    }
}
