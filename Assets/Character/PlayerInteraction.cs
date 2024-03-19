using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    //Refs
    public static PlayerInteraction Instance;

    private Inventory _inventory;
    private Pickable _pickable;
    private Interactive _interactive;
    private QuestNpc _npc;

    private bool _isTaking;
    
    [Header("Interaction")]
    public GameObject interactBox;
    public float interactBoxTime = 0.2f;

    private void Start()
    {
        interactBox = GameObject.Find("interactBox");
        interactBox.SetActive(false);
        if (Instance) Destroy(this);
        else Instance = this;

        Invoke("SetInventory", 0.1f);

        _isTaking = false;
    }

    private void SetInventory()
    {
        _inventory = Inventory.Instance;
    }

    public void Interact(InputAction.CallbackContext context)  
    {
        if (context.performed)
        {
            interactBox.SetActive(true);
            Invoke(nameof(DisableInteractBox), interactBoxTime);
        }
        if (context.performed && _pickable)
        {
            if (!_isTaking)
            {
                _isTaking = true;
                Invoke("Pickup", 0.2f);
            }
        }
        else if (_interactive /*!= InteractionType.Pickup*/)
        {
            Invoke("Interacted", 0.2f);
        }
        else if (transform.CompareTag("NPC"))
        {
            _npc = GetComponent<QuestNpc>();
            _npc.OnInteraction();
        }
    }

    private bool IsPickableNeeded()
    {
        foreach (QuestData questData in QuestManager.Instance.questsProgress)
        {
            foreach (QuestItem questItem in questData.requirements)
            {
                if (_pickable.item.Equals(questItem.item))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void Notify()
    {
        QuestManager.Instance.Notify();
    }

    private void Pickup()
    {
        _inventory.AddInventory(_pickable.item);
        _pickable.gameObject.SetActive(false);
        Notify();
        _isTaking = false;
    }

    private void Interacted()
    {
        if (_inventory.HasEveryItem(_interactive.requiredItems))
        {
            _interactive.OnInteraction();
            if (_interactive && _interactive.onlyOnce)
            {
                DisableInteractive();
            }
        }
        else
        {
            Invoke("OnFail", 0.2f);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pickable"))
        {
            _pickable = other.GetComponentInChildren<Pickable>();
            if (IsPickableNeeded())
            {
                //Anim
            }
        }
        else if(other.transform.CompareTag("Interactive"))
        {
            Interactive interactive = other.GetComponent<Interactive>();
            if(interactive==null)return;

            bool hasRequiredItem = _inventory.HasEveryItem(interactive.requiredItems);
            if (!interactive.waitForObject || hasRequiredItem)
            {
                _interactive = interactive;
                //Set Anim(InteractionType) Here
            }
        }
    }

    private void OnFail()
    {
        //Stop all Interaction Anim
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Pickable") || other.transform.CompareTag("Interactive")|| other.transform.CompareTag("NPC"))
        {
            StopInteractive();
        }
    }

    public void StopInteractive()
    {
        //SetInteraction(InteractionType.None);
        _interactive = null;
    }
    
    private void DisableInteractive()
    {
        _interactive.GetComponent<Collider>().enabled = false;
        Destroy(_interactive);
        //Anim Here (InteractionType.None)
    }
    
    private void DisableInteractBox()
    {
        interactBox.SetActive(false);
    }
    
}
