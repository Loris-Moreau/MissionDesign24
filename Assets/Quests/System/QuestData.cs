using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Quests.System
{
    [CreateAssetMenu(menuName = "Quest System/Quest")]

    public class QuestData : ScriptableObject
    {
        public string title, shortDescription;
        [TextArea] public string description;
        [TextArea] public string thankYouMessage;

        [TextArea] public string reward;

        public List<QuestItem> requirements = new List<QuestItem>();

        [Header("Rewards")]
        public int moneyReward;
        public QuestItem itemReward;
    }
}
