using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    public GameObject flashlightObject;  // Reference to the flashlight GameObject
    private bool isFlashlightOn = false;

    private void Update()
    {
        // Check if the player has picked up the flashlight and presses F
        if (InventoryManager.Instance.HasFlashlight() && Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        flashlightObject.SetActive(isFlashlightOn); // Toggle the light on/off
    }
}
