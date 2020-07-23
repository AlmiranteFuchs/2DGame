using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public ChooseClass choose;
    public ICharacterJob job;
    void Awake()
    {
        if(choose==ChooseClass.Wizard){
            job=new Wizard();
        }
        if(choose==ChooseClass.Warrior){
            job=new Warrior();
        }
        if(choose==ChooseClass.Ranger){
            job=new Ranger();
        }
        if(choose==ChooseClass.None){
            job=new None();
        }
    }
}
public enum ChooseClass
{
    Wizard,
    Warrior, 
    Ranger,
    None
}
