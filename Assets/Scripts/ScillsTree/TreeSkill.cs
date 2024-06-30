using System;
using UnityEngine;

[Serializable]
public class TreeSkill
{
    public string name;
    public string prerequisite;
    public string description;
    public Sprite icon;
}

public enum SkillsName
{
    Огненый_шар,
    Огненая_стрела,
    Водяной_шар,
    Водяные_шипы,
    Водяной_хлыст
}