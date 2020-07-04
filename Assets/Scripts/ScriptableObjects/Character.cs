using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters Info")]
public class Character : ScriptableObject
{
    //Maybe make this a character maker, with hair and stuff
    [Header("General Info")]
    public string cName;
    public Sprite cSprite;
    public RuntimeAnimatorController cAnimator;
    

}
