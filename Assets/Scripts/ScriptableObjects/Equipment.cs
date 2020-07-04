using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipament : Item
{
    public EquipamentSlot equipamentSlot;
    public float armorModifier, damageModifier;



    public override void UseItem(){
        PlayerEquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipamentSlot
{
    Head, Chest, Legs, Feet, RHand, LHand, BothHand
    //Maybe Hand and OffHand?
}
