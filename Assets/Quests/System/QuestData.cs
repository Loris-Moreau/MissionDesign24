using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    public string title, shortDescription;
    [TextArea] public string description;
    [TextArea] public string thankYouMessage;
    
    public List<QuestItem> requirements = new List<QuestItem>();

    [TextArea] public string reward;
    
    [Header("Rewards")]
    //public int amountReward;
    public QuestItem itemReward;
}
