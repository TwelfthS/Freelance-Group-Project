using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class PlayerBattle : MonoBehaviour
{
    public Enemy enemy;
    public Skill[] playerSkills;
    public int currentSkillId = 0;
    public Skill currentSkill;

    void Start()
    {
        playerSkills = GetComponent<SkillsHandler>().availableSkills;
        currentSkill = playerSkills[currentSkillId];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            chooseNextSkill();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            choosePrevSkill();
        }
        if (Input.GetKeyDown(KeyCode.Space) && enemy) {
            Attack(currentSkill.damage);
        }
    }

    void chooseNextSkill() {
        if (currentSkillId == playerSkills.Length - 1) {
            currentSkillId = 0;
            pickSkill(playerSkills[currentSkillId]);
        } else {
            currentSkillId++;
            pickSkill(playerSkills[currentSkillId]);
        }
    }

    void choosePrevSkill() {
        if (currentSkillId == 0) {
            currentSkillId = playerSkills.Length - 1;
            pickSkill(playerSkills[currentSkillId]);
        } else {
            currentSkillId--;
            pickSkill(playerSkills[currentSkillId]);
        }
    }

    public void pickSkill(Skill skill) {
        currentSkill = skill;
        Debug.Log("You picked a skill called " + skill.name + "!");
    }

    public void Attack(int damage) {
        if (Vector2.Distance(enemy.transform.position, transform.position) < 5f) {
            enemy.Hit(damage);
            Debug.Log("Enemy hit with " + currentSkill.name + " and got " + damage + " of damage!");
        }
    }

    public void SetEnemy(GameObject _enemy) {
        enemy = _enemy.GetComponent<Enemy>();
    }
}
