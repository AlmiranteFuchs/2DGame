using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    //Controller geral de skill
    //Para o Char
    //TODO --> Quando tiver GUI, fzr as habilidades mudarem de index 
    public CharacterStats charStats;
    SkillBase skill;
    SkillBase clone;

    private int skillCount; //Serve para verificar se esta usando outra skill e instanciar nova;
    public List<SkillBase> skills = new List<SkillBase>();

    public void UseSkill(int _skillSlot)
    {
        if (skill == null || _skillSlot != skillCount)
        {
            if (_skillSlot >= 0 && _skillSlot < skills.Count) //Check if index exists
            {
                skill = skills[_skillSlot];
                clone = Instantiate(skill);
                clone.skillController = this; //Take a instance to control the skill, not altering or editing the scriptable object 
                skillCount=_skillSlot;
            }
            else
            {
                Debug.Log("Not valid"); //Index don't exist
                return;
            }
        }
        clone.UseSkill();
    }

    void Awake()
    {
        if (charStats == null)
        {
            charStats = this.GetComponent<CharacterStats>();

        }
    }
}
//skill = SkillDtb.instance.skillsList.Find(x => x.name == "GolpeGiratório");
