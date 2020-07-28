using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour
{
    [SerializeField]
    protected Tags tags;
    [SerializeField]
    protected GameObject used;

    //Use layerMasks
    //Stuff don't work
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo entrou");
        switch (tags)
        {
            case Tags.All:
            case Tags.Interactables:
                if (other.gameObject.CompareTag("Interactables")) { used = other.gameObject; Interact(used); }
                break;
            case Tags.Both:
            case Tags.Player:
                if (other.gameObject.CompareTag("Player")) { used = other.gameObject; Interact(used); }
                break;
            case Tags.Enemy:
                if (other.gameObject.CompareTag("Enemy")) { used = other.gameObject; Interact(used); }
                break;
        }

    }

    protected virtual void Interact(GameObject _interactWith)
    {

    }
}
public enum Tags
{
    Player,
    Enemy,
    Both,
    Interactables,
    All
}
