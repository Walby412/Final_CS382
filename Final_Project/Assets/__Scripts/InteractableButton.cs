using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IClickable
{
    public GameObject door; // Reference to the door GameObject
    public float openAngle = 0f; // Angle to open the door to

    public void OnClick()
    {
        // Rotate the door to open it
        Quaternion targetRotation = Quaternion.Euler(door.transform.rotation.eulerAngles.x, openAngle, door.transform.rotation.eulerAngles.z);
        door.transform.rotation = targetRotation;
        Debug.Log("Button clicked! Door opening...");
    }
}