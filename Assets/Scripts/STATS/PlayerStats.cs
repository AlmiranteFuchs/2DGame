using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        PlayerEquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }


    void onEquipmentChanged(Equipament newItem, Equipament oldItem)
    {
        if (newItem != null)
        {
            armorModifier.AddModifier(newItem.armorModifier);
            attackDmgModifier.AddModifier(newItem.damageModifier);
        }
        if (oldItem != null)
        {
            armorModifier.RemoveModifier(oldItem.armorModifier);
            attackDmgModifier.RemoveModifier(oldItem.damageModifier);
        }
    }
}
