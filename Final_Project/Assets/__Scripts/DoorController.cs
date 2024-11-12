using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    public GameObject door1; // Assign the first door
    public GameObject door2; // Assign the second door
    public float delay = 0.5f; // Delay in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoorsAfterDelay());
        }
    }

    private IEnumerator CloseDoorsAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Set the first door's rotation to Y = 0
        Quaternion targetRotation1 = Quaternion.Euler(door1.transform.rotation.eulerAngles.x, 0, door1.transform.rotation.eulerAngles.z);
        door1.transform.rotation = targetRotation1;

        // Set the second door's rotation to Y = 180
        Quaternion targetRotation2 = Quaternion.Euler(door2.transform.rotation.eulerAngles.x, 180, door2.transform.rotation.eulerAngles.z);
        door2.transform.rotation = targetRotation2;
    }
}