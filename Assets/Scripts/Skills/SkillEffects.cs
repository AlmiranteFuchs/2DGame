﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffects : SkillBase
{
    //Provavelmente eu vou descontinuar isso tudo aqui, mais fácil fzr behaviour próprio pra cada 
    //skill
    public bool isInstant;
    public float effectDuration, effectInterval;
    public float effectDamage, effectHeal, effectBuffArmor, effectBuffDamage;
    private bool stop = false;




    public void ApplyEffect(GameObject[] _targets, MonoBehaviour _caller)
    {
        stop = false;
        if (isInstant)
        {
            for (int i = 0; i < _targets.Length; i++)
            {
                _targets[i].GetComponent<CharController>().GetDamage(effectDamage);
                _targets[i].GetComponent<CharController>().GetHeal(effectHeal);
                _targets[i].GetComponent<CharacterStats>().armorModifier.AddModifier(effectBuffArmor);
                _targets[i].GetComponent<CharacterStats>().armorModifier.AddModifier(effectBuffDamage);
            }
        }
        else
        {
            stop = false;
            MyCoroutine(_caller, _targets);
        }
    }

    public void MyCoroutine(MonoBehaviour _caller, GameObject[] _targets)
    {
        _caller.StartCoroutine(Timer());
        _caller.StartCoroutine(EffectCoroutine(_targets));
    }

    IEnumerator EffectCoroutine(GameObject[] _targets)
    {
        WaitForSeconds wait = new WaitForSeconds(effectInterval);
        while (!stop)
        {
            for (int x = 0; x < _targets.Length; x++)
            {
                _targets[x].GetComponent<CharController>().GetDamage(effectDamage);
                _targets[x].GetComponent<CharController>().GetHeal(effectHeal);
                _targets[x].GetComponent<CharacterStats>().armorModifier.AddModifier(effectBuffArmor);
                _targets[x].GetComponent<CharacterStats>().armorModifier.AddModifier(effectBuffDamage);
                Debug.Log("Algo acontece!");
            }
            yield return wait;
        }
        for (int x = 0; x < _targets.Length; x++)
        {
            _targets[x].GetComponent<CharacterStats>().armorModifier.RemoveModifier(effectBuffArmor);
            _targets[x].GetComponent<CharacterStats>().armorModifier.RemoveModifier(effectBuffDamage);
        }
        Debug.Log("Efeito terminou");
        //Ends
    }

    IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(effectDuration);
        yield return wait;
        stop = true;
    }

}
