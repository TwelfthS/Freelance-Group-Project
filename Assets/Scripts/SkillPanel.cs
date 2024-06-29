using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public RectTransform panelRect;
    public Skill[] playerSkills;
    public SkillButton[] sb;
    [SerializeField] private Button skillButtonPrefab;
    [SerializeField] private PlayerBattle battle;
    [SerializeField] private GameObject player;
    void Start()
    {
        panelRect = GetComponent<RectTransform>();
        playerSkills = player.GetComponent<SkillsHandler>().availableSkills;
        createSkillButtons();
        // buttonEventsSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createSkillButtons() {
        for (int i = 0; i < playerSkills.Length; i++) {
            Button currentButton = Instantiate(skillButtonPrefab, panelRect);
            currentButton.onClick.AddListener(() => OnButtonClick(currentButton));
            SkillButton skillButton = currentButton.GetComponent<SkillButton>();
            skillButton.applySkill(playerSkills[i]);
            // sb.Push(skillButton);
        }
    }

    // void buttonEventsSetup() {
    //     for (int i = 0; i < skillButtons.Length; i++) {
    //         Button clickedButton = skillButtons[i];
    //         skillButtons[i].onClick.AddListener(() => OnButtonClick(clickedButton));
    //     }
    // }

    private void OnButtonClick(Button clickedButton) {
        Skill skill = clickedButton.GetComponent<SkillButton>().referencedSkill;
        battle.pickSkill(skill);
    }
}
