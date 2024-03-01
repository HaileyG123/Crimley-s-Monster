using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject prompt;

    public Animator animator;

    private Queue<string> sentences; //FIFO collection

    public bool isCutscene;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, Dialogue answers)
    {
        if(prompt != null)
            prompt.SetActive(false);
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence;
        
        sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        if(isCutscene)
            SceneManager.LoadScene(scene);
        else
        {
            animator.SetBool("IsOpen", false);
            if(prompt != null)
                prompt.SetActive(true);
        }      

        
    }

}
