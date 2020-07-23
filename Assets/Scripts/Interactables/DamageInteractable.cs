using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInteractable : Interactables
{
    [SerializeField]
    float interactDmg;
    public override void Interact(){
        base.Interact();
        SystemReferences.instance.playerRef.GetComponent<PlayerStats>().TakeDamage(interactDmg);
    }
}
