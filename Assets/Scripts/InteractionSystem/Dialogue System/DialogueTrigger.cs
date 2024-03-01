using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject dialogueObject;
    private DialogueUI DI;

    private void Start()
    {
        //Debug.Log(dialogueObject);
        DI = FindObjectOfType<DialogueUI>();
    }

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        Debug.Log("update");
        this.dialogueObject = dialogueObject;
    }

    public void TriggerDialogue()
    {
        //Debug.Log(dialogueObject);
        /*if (TryGetComponent(out DialogueResponseEvents responseEvents) 
            && responseEvents.DialogueObject == dialogueObject)
        {
            DI.AddResponseEvents(responseEvents.Events);
        }*/

        Debug.Log("dialogue triggered");
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                DI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }
        
        DI.ShowDialogue(dialogueObject, false);
    }
}
