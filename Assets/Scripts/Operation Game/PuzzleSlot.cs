using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer renderer; 
    
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _completeClip;
    public bool placed = false;

    public void Placed()
    {
        placed = true;
        _source.PlayOneShot(_completeClip);
    }
}
