using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClownAttack : MonoBehaviour
{
    public GameObject clownQTE;
    public GameObject playerHearts;
    public GameObject bigClown;
    public bool isAttacking = false;
    public float moveSpeed = 0.2f;
    public DialogueUI DU;

    public DialogueTrigger clownDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQTEvent()
    {
        StartCoroutine(QTEvent());
    }
    
    IEnumerator QTEvent()
    {
        yield return new WaitForSeconds(1.5f);
        DU.CloseDialogueBox();
        
        //activate qte event
        clownQTE.SetActive(true);
        playerHearts.SetActive(true);
        bigClown.SetActive(true);
        
        //activate movement and attack
        isAttacking = true;
    }

}
