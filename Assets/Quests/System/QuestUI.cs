using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance;
    public QuestData questActive;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;


    private void Awake()
    {
        Instance = this;
    }
    

    private void Update()
    {
        questTitle.text = questActive.title;
        questDescription.text = questActive.objectif;

        if(questActive.itemReward != null)
        {
            questDescription.fontStyle = FontStyles.Strikethrough;
        }

    }


}
