using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in StaticData.pickedItems)
        {
            Debug.Log(StaticData.pickedItems);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
