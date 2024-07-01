using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    [SerializeField] private Text text;

    public void ChangeText(string message, Transform transform)
    {
        text.text = message;
        GameObject newObject = Instantiate(this.gameObject, transform);
        newObject.transform.SetSiblingIndex(0);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
