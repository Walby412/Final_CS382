using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float interactionRange = 5f; // The distance at which the player can interact
    public LayerMask interactableLayer; // Layer mask to filter the objects that can be interacted with

    public float holdDistance = 1.5f; // Distance from the camera to hold the item
    public float rotationSpeed = 5f;  // Speed at which the item rotates with the mouse

    private GameObject currentObject; // The currently picked up object
    private bool isHoldingItem = false; // Whether the player is currently holding an item

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click for interaction
        {
            PerformRaycast();
        }

        if (Input.GetMouseButtonDown(1)) // Right-click to drop item
        {
            DropItem();
        }

        if (isHoldingItem)
        {
            RotateHeldItem();
        }

        // Optional: Highlight object when player is looking at it
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            IPickable pickable = hit.collider.GetComponent<IPickable>();

            if (clickable != null || pickable != null)
            {
                // Highlight the object (e.g., change its material or color)
                Renderer rend = hit.collider.GetComponent<Renderer>();
                // Uncomment to highlight
                // if (rend != null) rend.material.color = Color.green;
            }
        }
    }

    void PerformRaycast()
    {
        RaycastHit hit;

        // Cast a ray from the camera's center forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {
            // Check if the hit object has the IClickable interface (for buttons)
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            if (clickable != null)
            {
                clickable.OnClick(); // Call the OnClick method of the object
                return; // If it's a button interaction, return early
            }

            // Check if the hit object has the IPickable interface (for items)
            IPickable pickable = hit.collider.GetComponent<IPickable>();
            if (pickable != null)
            {
                PickupItem(hit.collider.gameObject); // Pick up the item
            }
        }
    }

    void PickupItem(GameObject item)
    {
        if (isHoldingItem) return; // Prevent picking up multiple items at once

        currentObject = item;
        isHoldingItem = true;

        // Disable collider and set kinematic for physics handling
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        // Position the item in front of the camera and set scale to 2, 2, 2
        item.transform.SetParent(playerCamera.transform); // Attach to camera
        item.transform.localPosition = new Vector3(0, 0, holdDistance); // Position in front of the camera
        item.transform.localRotation = Quaternion.identity; // Reset rotation
        item.transform.localScale = new Vector3(2, 2, 2); // Set scale to 2, 2, 2
    }

    void DropItem()
    {
        if (isHoldingItem)
        {
            currentObject.GetComponent<Collider>().enabled = true;
            currentObject.GetComponent<Rigidbody>().isKinematic = false;
            currentObject.transform.SetParent(null); // Detach from the camera

            // The scale remains 2, 2, 2 when dropped, so no need to reset
            // currentObject.transform.localScale = Vector3.one; // This line is removed

            isHoldingItem = false;
            currentObject = null;
        }
    }

    void RotateHeldItem()
    {
        if (currentObject == null) return;

        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotate the item based on mouse movement
        currentObject.transform.Rotate(Vector3.up, -rotationX, Space.World); // Horizontal rotation
        currentObject.transform.Rotate(Vector3.right, rotationY, Space.World); // Vertical rotation
    }
}
