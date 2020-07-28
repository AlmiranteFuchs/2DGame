using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamageable : EnvironmentInteractable
{
    [SerializeField]
    float dmg;
    protected override void Interact(GameObject _interactWith)
    {
        _interactWith.GetComponent<CharController>().GetDamage(dmg);
    }
}
