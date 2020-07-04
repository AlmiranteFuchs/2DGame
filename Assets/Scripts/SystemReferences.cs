using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemReferences : MonoBehaviour
{
    public GameObject playerRef;

    [Header("Camera")]
    public GameObject cameraPointRef;
    public GameObject cameraMainRef;

    [Header("Player Parts")]
    public GameObject handHolder;
    public GameObject weaponSlot;
    public GameObject weaponTip;
    
    [Header("UI")]
    public UIInventory UIinventory;

    [SerializeField]
    private GameObject s_currentRoom;
    public GameObject currentRoom{
        get{return s_currentRoom;}
        set{s_currentRoom= value;}
    }

    public GameObject[] itemsList;
    public static SystemReferences instance;
    private void Awake()
    {
        instance = this;
    }

    

}
