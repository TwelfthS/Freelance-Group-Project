using UnityEngine;
using UnityEngine.UI;

public class SkillWidget : MonoBehaviour
{
    [SerializeField] private SkillsName selectSkill;
    [SerializeField] private Text name;
    [SerializeField] private Image image;
    [SerializeField] private Image selectable;
    [SerializeField] private Image locked;

    private string prerequisite;
    private WindowSkills windowSkills;

    public string Prerequisite => prerequisite;
    public string Name => selectSkill.ToString();

    [System.Obsolete]
    public bool isSelect => selectable.gameObject.active == true;

    [System.Obsolete]
    public bool isUnLocked => locked.gameObject.active == false;

    [System.Obsolete]
    public void Select()
    {
        windowSkills.UnSelectedSkills();
        selectable.gameObject.SetActive(true);
    }

    public void AddInfo(string name, Sprite image, string prerequisite, WindowSkills windowSkills)
    {
        this.name.text = name;
        this.image.sprite = image;
        this.prerequisite = prerequisite;
        this.windowSkills = windowSkills;
    }

    [System.Obsolete]
    public void UnSelect() => selectable.gameObject.SetActive(false);

    public void UnLocked()
    {
        locked.gameObject.SetActive(false);
    }
}
