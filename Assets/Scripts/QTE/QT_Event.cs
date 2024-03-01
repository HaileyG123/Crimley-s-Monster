using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QT_Event : MonoBehaviour
{
    public float fillAmount = 0;
    public float fillChange = 0.1f;
    public float timeThreshold = 0;

    public string eventSuccess = "n";

    public ClownAttack clownAttack;
    public GameObject key;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //Debug.Log("press");
            fillAmount += fillChange;
        }

        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.1)
        {
            timeThreshold = 0;
            fillAmount -= 0.02f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0;
        }
        
        if (fillAmount > 1)
        {
            eventSuccess = "y";
            Debug.Log(eventSuccess);
            
            clownAttack.bigClown.SetActive(false);
            clownAttack.playerHearts.SetActive(false);
            this.gameObject.SetActive(false);
            
            //clown dies and key is given
            GameObject clone = Instantiate(key);
            Debug.Log("instantiate key");
            clownAttack.gameObject.SetActive(false);
        }

        GetComponent<Image>().fillAmount = fillAmount;
    }
}
