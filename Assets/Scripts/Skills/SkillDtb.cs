using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDtb : MonoBehaviour
{
    public static SkillDtb instance;
    [SerializeField]

    public List<SkillBase> skillsList = new List<SkillBase>();

    void Awake()
    {
        instance = this;
    }
}
