using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string level;

    private InteractionSystem player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<InteractionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }
}
