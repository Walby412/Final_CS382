using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro UI component for the timer
    private float timer = 0f;
    private bool isTiming = false;

    void Start()
    {
        // Optional: Start the timer immediately when the game starts
        StartTimer();
    }

    void Update()
    {
        if (isTiming)
        {
            // Increase the timer by the time elapsed since the last frame
            timer += Time.deltaTime;

            // Format the timer to minutes and seconds in 00:00 format
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);

            // Update the TextMeshPro UI with the formatted time in 00:00 format
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        isTiming = true; // Start the timer
        timer = 0f; // Reset the timer if needed
    }

    public void StopTimer()
    {
        isTiming = false; // Stop the timer
    }
}