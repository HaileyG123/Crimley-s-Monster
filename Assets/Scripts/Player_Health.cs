using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float timeLimit = 0.5f;

    private float timeElapsed = 0.0f;

    public bool lastHealth = false;

    public GameObject loseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        timeElapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit)
        {
            this.gameObject.SetActive(false);
            if (lastHealth)
            {
                Debug.Log("you lose");
                Time.timeScale = 0f;
                loseScreen.SetActive(true);
            }
        }
    }
}
