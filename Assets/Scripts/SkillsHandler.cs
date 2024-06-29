using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsHandler : MonoBehaviour
{
    public Skill[] availableSkills;
    public bool defaultSkillMastery = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float DefaultSkill() {
        return 4;
    }
}
