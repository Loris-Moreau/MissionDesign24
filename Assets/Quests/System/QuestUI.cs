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
    public TextMeshProUGUI questObjectif;
    public GameObject thankYouGO;
    public float timeTYMessage;


    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        questObject.SetActive(false);
        thankYouGO.SetActive(false);
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
            questObjectif.text = questActive.objectif;
            questDescription.text = questActive.description;


            if (Inventory.Instance.inventory.Contains(questActive.itemReward))
            {
                questObjectif.fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    public void ThankYouMessage()
    {
        thankYouGO.SetActive(true);
        thankYouGO.GetComponent<TextMeshProUGUI>().text = questActive.thankYouMessage;

        Invoke("RemoveTYMessage", timeTYMessage);
    }

    public void RemoveTYMessage()
    {
        thankYouGO.SetActive(false);
    }
}
