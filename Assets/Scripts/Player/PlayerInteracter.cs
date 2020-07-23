using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    public bool canInteract{get; private set;}
    private GameObject interactFocus;

    public void Interact(){
        if(canInteract){
            interactFocus.GetComponent<Interactables>().Interact();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Interactable")){
            //ativar reação gui q da pra interagir
            canInteract=true;
            interactFocus=other.gameObject;
        }
        if(other.CompareTag("SoloInteractable")){
            canInteract=true;
            interactFocus=other.gameObject;
            Interact();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {   
        canInteract=false;
        interactFocus=null;
    }
}
