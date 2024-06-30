using System.Collections.Generic;
using UnityEngine;

public class WindowSkills : MonoBehaviour
{
    [SerializeField] private GameObject skills;

    private SkillWidget[] allSkills;

    public void Start()
    {
        allSkills = skills.GetComponentsInChildren<SkillWidget>();
        List<TreeSkill> skillsScrObj = Resources.Load<ScrObjScills>("Skills").skills;
        if (skillsScrObj != null)
        {
            for (int i = 0; i < allSkills.Length; i++)
            {
                if (skillsScrObj[i].name == allSkills[i].Name)
                {
                    allSkills[i].AddInfo(skillsScrObj[i].name, skillsScrObj[i].icon, skillsScrObj[i].prerequisite, this);
                }
            }
        }
        else
        {
            Debug.Log("Объект \"Scills\" не найден");
        }
    }

    public void UnSelectedSkills()
    {
        foreach (var skill in allSkills)
            skill.UnSelect();
    }

    public void OpenSkill()
    {
        foreach (var skill in allSkills)
        {
            if (skill.isSelect && CanUnlockSkill(skill))
            {
                skill.UnLocked();
                break;
            }
        }
    }

    public bool CanUnlockSkill(SkillWidget skill)
    {
        if (string.IsNullOrEmpty(skill.Prerequisite))
            return true;

        foreach (var s in allSkills)
        {
            if (s.Name == skill.Prerequisite && s.isUnLocked)
            {
                return true;
            }
        }

        return false;
    }
}
