using System.Collections;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class DoorController : MonoBehaviour
{
    public GameObject door1; // Assign the first door
    public GameObject door2; // Assign the second door
    public float delay = 0.5f; // Delay in seconds
    public AudioSource outsideMusic; // AudioSource for the exterior music
    public AudioSource insideMusic; // AudioSource for the interior music
    public TextMeshProUGUI popupText; // Reference to the TextMeshProUGUI for the popup message

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoorsAfterDelay());
            
            // Stop the outside music and start the inside music
            outsideMusic.Stop();
            insideMusic.Play();
            
            // Display the popup message
            StartCoroutine(ShowPopupMessage());
        }
    }

    private IEnumerator CloseDoorsAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Set the first door's rotation to Y = 0 (close it)
        Quaternion targetRotation1 = Quaternion.Euler(door1.transform.rotation.eulerAngles.x, 0, door1.transform.rotation.eulerAngles.z);
        door1.transform.rotation = targetRotation1;

        // Set the second door's rotation to Y = 180 (close it)
        Quaternion targetRotation2 = Quaternion.Euler(door2.transform.rotation.eulerAngles.x, 180, door2.transform.rotation.eulerAngles.z);
        door2.transform.rotation = targetRotation2;
    }

    private IEnumerator ShowPopupMessage()
    {
        // Show the message
        popupText.gameObject.SetActive(true); // Activate the popup text

        // Wait for 5 seconds (or however long you want the message to stay)
        yield return new WaitForSeconds(5f);

        // Hide the popup message
        popupText.gameObject.SetActive(false); // Deactivate the popup text
    }
}
