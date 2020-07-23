using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isDefault = false;

    public virtual void UseItem()
    {

    }
    public void RemoveFromInventory()
    {
        PlayerInventory.instance.RemoveItem(this);
    }

}
