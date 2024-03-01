using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    //Collider Trigger
    //Interaction Type
    public enum InteractionType { NONE, PickUp, Examine, Door, Door2}
    public InteractionType type;

    public DialogueTrigger trigger;
    public DialogueUI DI;

    public string name;
    public UIPrompt prompt;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                //Add the object to the PickedUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //Disable the object
                gameObject.SetActive(false); 
                break;
            case InteractionType.Examine:
                if (!DI.dialogueTriggered)
                {
                    trigger.TriggerDialogue();
                    DI.dialogueTriggered = true;
                }
                    
                //Debug.Log("EXAMINE");
                break;
            case InteractionType.Door:
                Destroy(this.gameObject);
                break;
            case InteractionType.Door2:
                //determine if the player has enough keys 
                List<GameObject> inventory = FindObjectOfType<InteractionSystem>().pickedItems;
                int keyCounter = 0;
                foreach (GameObject item in inventory)
                {
                    if (item.GetComponent<Item>().name == "key")
                    {
                        keyCounter++;
                    }
                }

                if (keyCounter == 3)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    prompt.uiText.text = "You need more keys to open meeees";
                }

                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
