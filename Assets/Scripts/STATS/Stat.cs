using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;
    public int GetValue(){
        return baseValue;
    }

    /* public float minDamage(float _maxDamage){
        
        return baseValue;
    } */
    
}
