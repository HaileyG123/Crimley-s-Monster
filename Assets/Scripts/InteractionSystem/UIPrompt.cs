using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPrompt : MonoBehaviour
{
    public GameObject uiPanel;
    public bool IsDisplayed = false;
    public TMP_Text uiText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(GameObject obj)
    {
        Item item = obj.GetComponent<Item>();
        string instruction = "error";

        if (item.type == Item.InteractionType.Door || item.type == Item.InteractionType.Door2)
        {
            instruction = "Open the Door";
        }
        else if (item.type == Item.InteractionType.Examine)
        {
            instruction = "Talk";
        }
        else if (item.type == Item.InteractionType.PickUp)
        {
            instruction = "Pick Up";
        }
        
        uiText.text = "Press E to " + instruction;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        //exclamationMark.SetActive(true);
        IsDisplayed = false;
    }
}
