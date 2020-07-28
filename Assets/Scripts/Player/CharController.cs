using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public CharacterStats charStats;
    public ChooseClass choose;
    public ICharacterJob job;
    void Awake()
    {
        charStats = this.gameObject.GetComponent<CharacterStats>();
        switch (choose)
        {
            case ChooseClass.Wizard:
                job = new Wizard();
                break;
            case ChooseClass.Warrior:
                job = new Warrior();
                break;
            case ChooseClass.Ranger:
                job = new Ranger();
                break;
            case ChooseClass.None:
                job = new None();
                break;
            default:
                job = new None();
                break;
        }
    }

    //Comportamentos
    public void GetDamage(float _damage)
    {
        _damage -= charStats.armorModifier.GetValue();
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        Debug.Log("Ouch! = " + _damage);
        charStats.healthCurr -= _damage;
        if (charStats.healthCurr <= 0.1f)
        {
            Die();
        }
    }

    public void GetHeal(float _heal)
    {
        Mathf.Clamp(_heal, 0, charStats.healthMax);
        charStats.healthCurr += _heal;
    }

    public void GetXP(int _amount)
    {

    }
    public virtual void Die()
    {
        Debug.Log("Dies");
    }
}
public enum ChooseClass
{
    Wizard,
    Warrior,
    Ranger,
    None
}
