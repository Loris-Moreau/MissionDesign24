using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance;
    public QuestData questActive;
    public GameObject questObject;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questObjectRequirement;


    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (questActive == null)
        {
            questObject.SetActive(false);
        }
        else if (questActive != null)
        {
            questObject.SetActive(true);
            questTitle.text = questActive.title;
            questDescription.text = questActive.objectif;
            
            if (questActive.itemReward != null)
            {
                questDescription.fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
