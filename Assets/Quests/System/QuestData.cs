using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    public string title, objectif;
    [TextArea] public string description;
    [TextArea] public List<string> subObjectif;
    [TextArea] public string thankYouMessage;
    
    public List<QuestItem> requirements = new List<QuestItem>();
    
    [Header("Rewards")]
    [TextArea] public string reward;
    
    public QuestItem itemReward;
}
