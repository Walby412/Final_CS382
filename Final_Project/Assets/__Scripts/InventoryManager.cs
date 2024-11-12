using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Singleton pattern
    public static InventoryManager Instance { get; private set; }

    public List<Image> inventorySlots;
    private List<Sprite> collectedItems = new List<Sprite>();

    // Reference to the flashlight icon to add to inventory when picked up
    public Sprite flashlightIcon;
    private bool hasFlashlight = false;

    private void Awake()
    {
        // Ensure there's only one instance of InventoryManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate if there are multiple instances
        }
    }

    // Adds an item to the inventory by setting its icon in an empty slot
    public void AddItem(Sprite itemIcon)
    {
        if (collectedItems.Count < inventorySlots.Count)
        {
            collectedItems.Add(itemIcon); 
            UpdateInventoryUI(); 
        }
    }

    // Adds the flashlight specifically to the inventory
    public void AddFlashlight()
    {
        if (!hasFlashlight && collectedItems.Count < inventorySlots.Count)
        {
            collectedItems.Add(flashlightIcon); 
            UpdateInventoryUI();
            hasFlashlight = true;
        }
    }

    public bool HasFlashlight()
    {
        return hasFlashlight;
    }

    // Updates each slot with the corresponding item icon
    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < collectedItems.Count)
            {
                inventorySlots[i].sprite = collectedItems[i];
                inventorySlots[i].enabled = true;
            }
            else
            {
                inventorySlots[i].enabled = false;
            }
        }
    }
}
