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
        StartCoroutine(GiveKey());
        //this.gameObject.SetActive(false);
    }

    private IEnumerator GiveKey()
    {
        Instantiate(key);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
