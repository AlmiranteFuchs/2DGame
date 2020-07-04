using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    #region Singleton
    public static PlayerEquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion


    public delegate void OnEquipmentChanged(Equipament _newItem, Equipament _oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Equipament[] currentEquipments;
    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipamentSlot)).Length;
        currentEquipments = new Equipament[numSlots];
    }

    public void Equip(Equipament _newItem)
    {
        int slotIndex = (int)_newItem.equipamentSlot;
        Equipament oldItem = null;
        if (currentEquipments[slotIndex] != null)
        {
            oldItem = currentEquipments[slotIndex];
            PlayerInventory.instance.AddItem(oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(_newItem, oldItem);
        }
        currentEquipments[slotIndex] = _newItem;
    }

    public void UnEquip(int _slotIndex)
    {
        if (currentEquipments[_slotIndex] != null)
        {
            Equipament oldItem = currentEquipments[_slotIndex];
            PlayerInventory.instance.AddItem(oldItem);
            currentEquipments[_slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }


}
