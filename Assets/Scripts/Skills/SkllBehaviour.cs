using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkllBehaviour : MonoBehaviour
{
    public SkillBase skillParent;
    // Start is called before the first frame update
    public virtual void Behaviour(){
        Debug.Log("Default Beh");
    }
}
