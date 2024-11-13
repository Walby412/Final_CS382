using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance; // Static reference to the singleton instance

    public Transform HoldPosition; // The position where picked-up items will be held

    void Awake()
    {
        // Ensure only one instance of Player exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Destroy the duplicate instance
        }
    }
}
