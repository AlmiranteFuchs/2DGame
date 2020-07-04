using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public float strength;
    public float inteligence;
    public float agility;
    public Stat minDamage;

    public Stat maxHealth;
    public int currHealth { get; private set; }
    public Stat armor;
    public Stat moveSpeed;


    void Awake()
    {
        currHealth = maxHealth.GetValue();
    }

    //Comportamentos 
    public void TakeDamage(int _damage)
    {
        _damage -= armor.GetValue();
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);

        currHealth -= _damage;
        if (currHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //Focking dies
        //This method is supposed to be overrighted 
    }


}
