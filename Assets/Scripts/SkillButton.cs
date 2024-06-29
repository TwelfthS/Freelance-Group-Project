using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Skill referencedSkill;
    public bool isActive = false;
    private Image image;

    void Start() {
        image = GetComponent<Image>();
    }

    void Update() {
        if (isActive) {
            image.color = Color.red;
        } else {
            image.color = Color.white;
        }
    }

    // public void CreateSkillButtons(Skill[] playerSkills) {
    //     for (int i = 0; i < playerSkills.Length; i++) {
    //         skillButtons[i] = Instantiate(skillButtonPrefab, panel);
    //         SkillButton sb = skillButtons[i].GetComponent<SkillButton>();
    //         sb.applySkill(playerSkills[i]);
    //     }
    // }

    public void applySkill(Skill skill) {
        referencedSkill = skill;
    }
}
