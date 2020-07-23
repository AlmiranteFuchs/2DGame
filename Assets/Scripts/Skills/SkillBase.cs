using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Skill Base")]
public class SkillBase : ScriptableObject
{
    //CREATE THAT INHERTIS FROM HERE DEBUFF SCRIPTABLE OBJECTS THAN MAKE DEBUFFS SCRITABLES
    [Header("Skill Characteristic")]
    [SerializeField]
    string skillName, skillDesc;

    [SerializeField]
    ChooseClass chooseClass;
    [SerializeField]
    int skillIdentification;
    public int skillId { get { return skillIdentification; } private set { skillIdentification = value; } }

    [Header("Specs")]
    [SerializeField]
    float skillManaCost, skillHealthCost, skillCoolDown, skillDamage;
    public float skillDmg { get { return skillDamage; } private set { skillDamage = value; } }
    [SerializeField]
    private float manaValue;

    [SerializeField]
    bool passive;

    [Header("Behaviour")]
    public SkillController controller;
    public GameObject behaviour;



    //Private Stuff
    [SerializeField]
    bool inCooldown = false;

    void Awake()
    {
        behaviour.GetComponent<SkllBehaviour>().skillParent = this;
        //inCooldown=false;
        if (passive)
        {
            controller=SystemReferences.instance.playerRef.GetComponent<SkillController>();
            UseSkill();
        }
    }

    public void UseSkill()
    {
        if (skillCoolDown != 0)
        {
            if (!Usable())
            {
                Debug.Log("Em coolDown ou mana baixa");
                return;
            }
            else
            {
                controller.StartCoroutine(CoolDown());
                behaviour.GetComponent<SkllBehaviour>().Behaviour();
            }
        }
    }


    bool Usable()
    {
        //Mana, cooldown
        if (!inCooldown)
        {
            if (skillManaCost == 0)
            {
                return true;
            }
            else if (controller.charStats.mana >= skillManaCost)
            {
                return true;
            }
            else { return false; }
        }
        else { return false; }
    }

    IEnumerator CoolDown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(skillCoolDown);
        inCooldown = false;
    }
}
