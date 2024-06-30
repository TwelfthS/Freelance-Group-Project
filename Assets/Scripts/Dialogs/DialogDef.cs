using UnityEngine;

[CreateAssetMenu(menuName = "Def/Dialog", fileName = "Dialog")]
public class DialogDef : ScriptableObject
{
    [SerializeField] private DialogData _data;

    public DialogData Data => _data;
}
