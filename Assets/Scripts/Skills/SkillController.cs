using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    //Controller geral de skill
    //Para o Char
    public CharacterStats charStats;
    SkillBase skill;
    SkillBase clone;

    public void UseSkill()
    {
        if(skill==null){
            skill = SkillDtb.instance.skillsList.Find(x => x.name == "GolpeGiratório");
            clone = Instantiate(skill);
            clone.controller = this;
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
