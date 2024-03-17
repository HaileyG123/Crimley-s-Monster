using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownLaugh : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private Animator clownAnimator;

    public void Laugh()
    {
        Debug.Log("laughing called");
        //clownAnimator.SetBool("IsLaughing", true);
        Instantiate(key);
        //this.gameObject.SetActive(false);
    }
}
