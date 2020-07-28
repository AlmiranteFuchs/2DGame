using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Skill Base")]
public class SkillBase : ScriptableObject
{
    [Header("[Skill Characteristics]")]
    [SerializeField]
    string skillName;
    [SerializeField]
    string skillDesc;

    [SerializeField]
    ChooseClass chooseClass;

    [SerializeField]
    int skillIdentification;
    public int skillId { get { return skillIdentification; } private set { skillIdentification = value; } }

    [Header("[Specs]")]
    [SerializeField]
    float _skillManaCost;
    [SerializeField]
    float _skillHealthCost, _skillCoolDown, _skillDamage;
    public float skillManaCost { get { return _skillManaCost; } private set { _skillManaCost = value; } }
    public float skillHealthCost { get { return _skillHealthCost; } private set { _skillHealthCost = value; } }
    public float skillCoolDown { get { return _skillCoolDown; } private set { _skillCoolDown = value; } }
    public float skillDamage { get { return _skillDamage; } private set { _skillDamage = value; } }

    [SerializeField]
    bool passive;

    [Header("[Behaviour]")]
    public GameObject behaviour;
    public SkillController skillController; // Controller que ta instanciando a habilidade

    [Header("[SFX and Stuff]")]
    public AnimationClip skillAnimation;



    //Private Stuff
    [SerializeField]
    bool inCooldown = false;

    void Awake()
    {
        behaviour.GetComponent<SkllBehaviour>().skillBaseParent = this;
        //inCooldown=false;
        if (passive)
        {
            UseSkill();
        }
    }

    public void UseSkill()
    {
        if (_skillCoolDown != 0)
        {
            if (!Usable())
            {
                Debug.Log("Em coolDown ou mana baixa");
                return;
            }
            else
            {
                skillController.StartCoroutine(CoolDown());
                behaviour.GetComponent<SkllBehaviour>().Behaviour();
                if (skillAnimation != null)
                {

                    Animator anim = SystemReferences.instance.playerRef.GetComponent<Animator>();
                    AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
                    //animatorOverrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
                    animatorOverrideController["Skill_Animation"] = skillAnimation;
                    anim.runtimeAnimatorController = animatorOverrideController;
                    anim.Play("Skill_Animation");

                }
                else { Debug.Log("Skill Animation null"); }
            }
        }
    }


    bool Usable()
    {
        //Mana, cooldown
        if (!inCooldown)
        {
            if (_skillManaCost == 0)
            {
                return true;
            }
            else if (skillController.charStats.manaCurr >= _skillManaCost)
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
        yield return new WaitForSeconds(_skillCoolDown);
        inCooldown = false;
    }
}
