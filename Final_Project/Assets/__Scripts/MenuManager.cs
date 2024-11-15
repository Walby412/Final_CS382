using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // References to UI elements
    public GameObject controlsPanel;
    public Slider dpiSlider;
    public TextMeshProUGUI dpiValueText; // Change to TextMeshProUGUI
    public FirstPersonController playerController;

    // Key to toggle the menu
    public KeyCode toggleKey = KeyCode.Escape;

    private bool isMenuOpen = false;

    private void Start()
    {
        // Ensure the controls panel is hidden initially
        controlsPanel.SetActive(false);

        // Initialize the DPI slider with a default value
        dpiSlider.minValue = 0.5f; // Min sensitivity
        dpiSlider.maxValue = 3.0f; // Max sensitivity
        dpiSlider.value = 1.0f; // Default sensitivity
        dpiSlider.onValueChanged.AddListener(OnDPIChange);

        // Set initial DPI text
        UpdateDPIValueText(dpiSlider.value);
    }

    private void Update()
    {
        // Check if the toggle key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleControlsPanel();
        }
    }

    // Function to handle DPI slider changes
    private void OnDPIChange(float value)
    {
        // Update DPI value text
        UpdateDPIValueText(value);

        // Adjust the in-game mouse sensitivity based on the slider value
        playerController.UpdateMouseSensitivity(value);
    }

    // Update the DPI value text using TextMeshProUGUI
    private void UpdateDPIValueText(float value)
    {
        dpiValueText.text = "Mouse DPI: " + (value * 100).ToString("F0") + "%";
    }

    // Function to show/hide the controls panel
    private void ToggleControlsPanel()
    {
        isMenuOpen = !isMenuOpen;
        controlsPanel.SetActive(isMenuOpen);

        // Enable/disable player movement
        playerController.SetPlayerMovement(!isMenuOpen);

        // Show or hide the cursor based on menu state
        if (isMenuOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void OnRestartButton(){
        SceneManager.LoadScene(1);
    }
}

