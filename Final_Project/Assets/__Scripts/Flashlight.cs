using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IClickable
{
    public GameObject inventorySlot; // Reference to inventory slot UI to add flashlight icon

    public void OnClick()
    {
        inventorySlot.SetActive(true); 

        gameObject.SetActive(false);
    }
}
