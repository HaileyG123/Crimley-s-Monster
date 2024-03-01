using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private ResponseHandler _responseHandler;
    private TypeWriterEffect _typeWriterEffect;

    public bool isCutscene;
    public string scene;

    [Header("Interaction Prompt")] [SerializeField]
    private GameObject ePrompt;

    public bool dialogueTriggered;
    public DialogueObject DO;

    [SerializeField] private DialogueTrigger DT;
    [SerializeField] private GameObject clown;
    
    private void Start()
    {
        _typeWriterEffect = GetComponent<TypeWriterEffect>();
        _responseHandler = GetComponent<ResponseHandler>();
        //CloseDialogueBox();
        //ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject, bool isResponse)
    {
        Debug.Log("dialogue started");
        DO = dialogueObject;
        ePrompt.SetActive(false);
        //dialogueBox.SetActive(true);
        if (!isResponse)
        {
            animator.SetBool("IsOpen", true);
        }
        
        //handle dialogue response events
        if (clown != null)
        {
            foreach (DialogueResponseEvents responseEvents in clown.GetComponents<DialogueResponseEvents>())
            {
                if (responseEvents.DialogueObject == dialogueObject)
                {
                    this.AddResponseEvents(responseEvents.Events);
                    break;
                }
            }
        }
        
        //Debug.Log("is it null?" + dialogueObject);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        _responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        //Debug.Log(dialogueObject);
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            //Debug.Log(dialogue);
            yield return _typeWriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses)
            {
                break;
            }
            
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueObject.HasResponses)
        {
            _responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox()
    {
        if (isCutscene)
        {
            dialogueTriggered = false;
            Debug.Log("load scene");
            SceneManager.LoadScene(scene);
        }
        else
        {
            ePrompt.SetActive(true);
            dialogueTriggered = false;
            animator.SetBool("IsOpen", false);
            textLabel.text = string.Empty;
        }
    }
}
