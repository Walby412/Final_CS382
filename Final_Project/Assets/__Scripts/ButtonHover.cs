using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public GameObject hoverText; // Reference to the "Interactable" text

    private void OnMouseEnter()
    {
        if (hoverText != null)
        {
            hoverText.SetActive(true); // Show text when hovering
        }
    }

    private void OnMouseExit()
    {
        if (hoverText != null)
        {
            hoverText.SetActive(false); // Hide text when not hovering
        }
    }
}
