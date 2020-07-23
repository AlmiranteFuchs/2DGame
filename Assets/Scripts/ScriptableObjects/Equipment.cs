using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipament : Item
{
    public ChooseClass choose;
    public EquipamentSlot equipamentSlot;
    public float armorModifier, damageModifier;



    public override void UseItem()
    {
        bool yea = PlayerEquipmentManager.instance.Equip(this);
        if (yea)
        {
            RemoveFromInventory();
        }
    }

}

public enum EquipamentSlot
{
    Head, Chest, Legs, Feet, RHand, LHand, BothHand
    //Maybe Hand and OffHand?
}
