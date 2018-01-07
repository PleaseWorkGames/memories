
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    private List<GameObject> itemSlots;
    
    void Start()
    {
        itemSlots = getSlots(gameObject);
    }
    
    public void renderInventory(Inventory inventory)
    {
        clearSlots();
        List<ItemListing> itemList = inventory.itemList;
        for (int i = 0; i < itemList.Count; i++)
        {
            ItemListing listing = itemList[i];
            GameObject slot = itemSlots[i];
            Text itemSlotGui = slot.GetComponent<Text>();
            itemSlotGui.text = listing.item.name;
            itemSlotGui.enabled = true;
        }
    }

    private List<GameObject> getSlots(GameObject go)
    {
        Transform[] transforms = go.GetComponentsInChildren<Transform>();
        List<GameObject> slots = new List<GameObject>();
        foreach (Transform t in transforms)
        {
            GameObject child = t.gameObject;
            if (child.tag == "itemSlot")
            {
                slots.Add(child);
            }
        }
        return slots;
    }

    private void clearSlots()
    {
        foreach (GameObject slot in itemSlots)
        {
            Text sprite = slot.GetComponent<Text>();
            sprite.enabled = false;
            sprite.text = "";
        }
    }
}
