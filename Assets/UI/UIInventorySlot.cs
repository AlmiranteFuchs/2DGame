using UnityEngine.UI;
using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeBtn;
    
    Item item;

    public void AddItem(Item _item)
    {
        item = _item;
        icon.enabled=true;
        removeBtn.interactable=true;
        icon.sprite=_item.itemIcon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.enabled=false;
        removeBtn.interactable=false;
        icon.sprite=null;
    }

    public void OnRemoveBtn(){
        PlayerInventory.instance.RemoveItem(item);
    }
    public void OnUseItem(){
        if(item!=null){
            item.UseItem();
        }
    }
}
