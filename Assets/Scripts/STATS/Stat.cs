using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float baseValue;

    [SerializeField]
    private List<float> modifiers = new List<float>();
    public void AddModifier(float _modifier)
    {
        if (_modifier != 0)
        {
            modifiers.Add(_modifier);
        }
    }
    public void RemoveModifier(float _modifier)
    {
        if (_modifier != 0)
        {
            modifiers.Remove(_modifier);
        }
    }
    public float GetValue()
    {
        float finalvalue = baseValue;
        modifiers.ForEach(x => finalvalue += x);
        return finalvalue;
    }

}
