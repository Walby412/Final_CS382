using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float interactionRange = 5f; // The distance at which the player can interact
    public LayerMask interactableLayer; // Layer mask to filter the objects that can be interacted with

    void Update(){
    if (Input.GetMouseButtonDown(0)) // Left-click
    {
        PerformRaycast();
    }

    // Optional: Highlight object when player is looking at it
    RaycastHit hit;
    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
    {
        IClickable clickable = hit.collider.GetComponent<IClickable>();
        if (clickable != null)
        {
            // Highlight the object (e.g., change its material or color)
            Renderer rend = hit.collider.GetComponent<Renderer>();
            // if (rend != null)
            // {
            //     rend.material.color = Color.green; // Example of changing color
            // }
        }
    }}

    void PerformRaycast(){
        RaycastHit hit;

        // Cast a ray from the camera's center forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {
            // Check if the hit object has the IClickable interface
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            if (clickable != null)
            {
                clickable.OnClick(); // Call the OnClick method of the object
            }
        }
    }
}
