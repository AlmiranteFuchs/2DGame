using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [SerializeField]
    [Header("Atributes")]
    private float strength;
    [SerializeField]
    private float inteligence;
    [SerializeField]
    private float agility;


    #region Attackdamagecalc
    [Header("Physical Attack")]
    public Stat attackDmgModifier;
    [SerializeField]
    private float amplADamage;
    public float adProcChance;
    public float adCritMult;

    protected float maxADamage
    {
        get { return strength * 5; }
        set { maxADamage = value; }
    }
    protected float minADamage
    {
        get { return maxADamage / amplADamage; }
        set { minADamage = value; }
    }
    public float attackDamage
    {
        get
        {
            float finalvalue;
            finalvalue = Random.Range(minADamage, maxADamage);
            finalvalue = Mathf.Round(finalvalue * 10.0f) * 0.1f;
            finalvalue = finalvalue + attackDmgModifier.GetValue();
            if (Random.value > adProcChance && adProcChance != 0)
            {
                //Is crit
                finalvalue = finalvalue * adCritMult;
                Debug.Log("Crit!");
            }
            Debug.Log(finalvalue);
            return finalvalue;
        }
        private set { attackDamage = value; }
    }

    #endregion Attackdamagecalc


    [Header("Health/Defense")]
    [SerializeField]
    private float currHealth;
    [SerializeField]
    private float maxHealth
    {
        get { return strength * 20; }
        set { maxHealth = value; }
    }
    public Stat armorModifier;

    public float mana { get { return manaValue; } private set { manaValue = value; } }
    [SerializeField]
    private float manaValue;


    public Stat moveSpeed;


    void Awake()
    {
        currHealth = maxHealth;
    }



    //Comportamentos 
    public void TakeDamage(float _damage)
    {
        _damage -= armorModifier.GetValue();
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        Debug.Log("Ouch! = " + _damage);
        currHealth -= _damage;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHeal(float _heal)
    {
        currHealth += _heal;
        Mathf.Clamp(currHealth, 0, maxHealth);
    }
    public virtual void Die()
    {
        //Focking dies
        //This method is supposed to be overrighted 
    }


}
