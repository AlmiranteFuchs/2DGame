using System;
using UnityEngine;

public class ItemPickup : Interactables
{
    public Item item;
    public override void Interact(){
        PickUp();
    }

    private void PickUp()
    {
        //DO STUFF
        bool yeah = PlayerInventory.instance.AddItem(item);
        if(yeah){
            Destroy(this.gameObject);
        }else{Debug.Log("no");}
    }
}
