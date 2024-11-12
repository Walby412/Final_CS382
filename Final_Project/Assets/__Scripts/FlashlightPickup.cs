using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public Transform playerCamera; // Reference to player camera
    public GameObject hoverText; // Reference to the "Activate and deactivate flashlight with 'F'!" text

    private void OnMouseDown()
    {
        // Add the flashlight to the inventory
        InventoryManager.Instance.AddFlashlight();

        // Attach the flashlight to the player camera
        gameObject.transform.SetParent(playerCamera);

        // Position and rotate the flashlight to face forward with an additional 90-degree x-axis rotation
        gameObject.transform.localPosition = new Vector3(0.6f, -0.4f, 0); // Set to the specified position
        gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0);  // Apply a 90-degree rotation on the x-axis

        // Hide the flashlight initially
        gameObject.SetActive(false);

        // Show the message and start the coroutine to hide it after 5 seconds
        ShowMessage();
    }

    private void ShowMessage()
    {
        if (hoverText != null)
        {
            hoverText.SetActive(true); // Show the message
            StartCoroutine(HideMessageAfterDelay(5f)); // Hide the message after 5 seconds
        }
    }

    // Coroutine to hide the message after a delay
    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        hoverText.SetActive(false); // Hide the message
    }
}