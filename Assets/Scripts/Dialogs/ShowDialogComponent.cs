using UnityEngine;

public class ShowDialogComponent : MonoBehaviour
{
    [SerializeField] private DialogDef _external;
    [SerializeField] private DialogBoxController _dialogBox;

    public void Show()
    {
        var f = Instantiate(_dialogBox.gameObject, FindObjectOfType<Canvas>().gameObject.transform);
        f.GetComponent<DialogBoxController>().ShowDialog(_external.Data);
    }
}
