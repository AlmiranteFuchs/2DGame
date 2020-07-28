using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //<summary> Responsável pelo cálculo de status e pequenos comportamentos dos mesmos </summary>
    //Todo campo private é somente para visualização. Não devendo ser usado para Calc ou etc...  
    //Sim é uma bosta, eu sou burro mas preciso alterar o valor das var e n quero fzr método específico e
    //pra falar a verdade nem sei como

    [Header("[Atributes]")]
    [SerializeField]
    private float _baseStrength; //fuck headers
    [SerializeField]
    private float _baseIntelligence, _baseAgility;
    public float baseStrength { get { return _baseStrength; } private set { _baseStrength = value; } }
    public float baseIntelligence { get { return _baseIntelligence; } private set { _baseIntelligence = value; } }
    public float baseAgility { get { return _baseAgility; } private set { _baseAgility = value; } }

    [SerializeField]
    private Stat _strengthModifier, _intelligenceModifier, _agilityModifier;
    public Stat strengthModifier { get { return _strengthModifier; } }
    public Stat intelligenceModifier { get { return _intelligenceModifier; } }
    public Stat agilityModifier { get { return _agilityModifier; } }

    [Space(10)]
    [SerializeField]
    private float _strength;
    [SerializeField]
    private float _intelligence, _agility;
    public float strength { get { float a = baseStrength + strengthModifier.GetValue(); _strength = a; return a; } }
    public float intelligence { get { float a = baseIntelligence + intelligenceModifier.GetValue(); _intelligence = a; return a; } }
    public float agility { get { float a = baseAgility + agilityModifier.GetValue(); _agility = a; return a; } }





    #region Attackdamagecalc
    [Header("[Physical Attack]")]
    public Stat attackDmgModifier;

    [SerializeField]
    private float _attackDmgArc, _attackDmgCritChance, _attackDmgCritMult;

    private float attackDmgArc { get { return _attackDmgArc; } set { _attackDmgArc = value; } }//O "quão amplo" o dano pode ser para ser calc entre max e min
    public float attackDmgCritChance { get { return _attackDmgCritChance; } set { _attackDmgCritChance = value; } }
    public float attackDmgCritMult { get { return _attackDmgCritMult; } set { _attackDmgCritMult = value; } }
    protected float attackDmgMax { get { return _strength * 5; } }
    protected float attackDmgMin { get { return attackDmgMax / _attackDmgArc; } }

    public float attackDmg
    {
        get
        {
            float finalvalue;
            finalvalue = Random.Range(attackDmgMin, attackDmgMax);
            finalvalue = Mathf.Round(finalvalue * 10.0f) * 0.1f;
            finalvalue = finalvalue + attackDmgModifier.GetValue();
            if (Random.value > _attackDmgCritChance && _attackDmgCritChance != 0)
            {
                //Is crit
                finalvalue = finalvalue * _attackDmgCritMult;
                Debug.Log("Crit!");
            }
            return finalvalue;
        }
        private set { attackDmg = value; }
    }

    #endregion Attackdamagecalc


    [Header("[Health/Defense]")]
    public Stat armorModifier;
    [SerializeField]
    private float _healthMax, _healthCurr, _healthRegen;
    public float healthMax { get { float a = strength * 20; _healthMax = a; return a; } set { _healthMax = value; } }
    public float healthCurr { get { return _healthCurr; } set { _healthCurr = Mathf.Clamp(value, 0, healthMax); if (!regeneration) { InvokeRepeating("Regens", 0, Time.fixedDeltaTime); } } }
    public float healthRegen { get { float a = strength * 0.01f; _healthRegen = a; return a; } set { _healthRegen = value; } }
    [Header("[Mana Points]")]
    [SerializeField]
    private float _manaCurr;
    [SerializeField]
    private float _manaMax, _manaRegen;
    public float manaCurr { get { return _manaCurr; } set { _manaCurr = Mathf.Clamp(value, 0, manaMax); if (!regeneration) { InvokeRepeating("Regens", 0, Time.fixedDeltaTime); } } }
    public float manaMax { get { float a = intelligence * 12; _manaMax = a; return a; } set { _manaMax = value; } }
    public float manaRegen { get { float a = intelligence * 0.05f; _manaRegen = a; return a; } set { _manaRegen = value; } }


    [Header("[Experience/Level]")]
    public int _currentLevel;
    private int currentLevel { get { return _currentLevel; } set { _currentLevel = value; } }


    public Stat moveSpeed;


    void Awake()
    {
        healthCurr = healthMax;
        manaCurr = manaMax;
    }

    bool regeneration = false;
    void Regens()
    {
        Debug.Log("Repeating");
        if (healthCurr < healthMax)
        {
            regeneration = true;
            healthCurr += healthRegen;
        }
        else if (manaCurr < manaMax)
        {
            regeneration = true;
            manaCurr += manaRegen;
        }
        else
        {
            regeneration = false;
            CancelInvoke("Regens");
        }
    }

}
