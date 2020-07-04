using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public Transform slotParent;
    UIInventorySlot[] slots;
    PlayerInventory pInventory;

    void Start()
    {
        slots = slotParent.GetComponentsInChildren<UIInventorySlot>(true);
        pInventory = PlayerInventory.instance;
        pInventory.onItemChangeCallBack += UpdateUI;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < pInventory.items.Count)
            {
                slots[i].AddItem(pInventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
