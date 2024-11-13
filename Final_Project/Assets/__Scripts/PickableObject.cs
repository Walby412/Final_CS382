using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable
{
    public Transform holdPosition;  // Reference to the hold position (can be set in the editor)
    
    private Vector3 originalScale;

    public void OnPickUp()
    {
        originalScale = transform.localScale;  // Store the original scale

        if (TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = true;
        }

        // Parent the item to the hold position
        transform.SetParent(holdPosition);  // Use the holdPosition set in the editor

        // Reset position, rotation, and scale
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = originalScale;

        Debug.Log("Item Picked Up!");
    }

    public void OnDrop()
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = false;  // Re-enable physics when dropped
        }

        transform.SetParent(null);  // Remove parent

        Debug.Log("Item Dropped!");
    }
}

