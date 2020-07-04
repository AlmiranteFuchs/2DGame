using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region singleton


    public static PlayerInventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance PlayerInventory");
        }
        instance = this;
    }
    #endregion singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallBack;
    public List<Item> items = new List<Item>();
    public int inventorySpace = 20;
    public bool AddItem(Item _item)
    {
        //CHECK CLASS BEFORE ADD
        //CHECK IF PLAYER CAN CARRY THE ITEM
        if (items.Count >= inventorySpace)
        {
            Debug.Log("No space on inventory");
            return false;
        }
        else
        {
            items.Add(_item);
            if (onItemChangeCallBack != null)
            {
                onItemChangeCallBack.Invoke();
            }
            return true;
        }
    }
    public void RemoveItem(Item _item)
    {
        items.Remove(_item);
        if (onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        }
    }
}
