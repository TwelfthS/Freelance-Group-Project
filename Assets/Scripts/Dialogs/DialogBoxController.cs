using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogBoxController : MonoBehaviour
{
    [SerializeField] private Text _text; //текст диалога

    [Space] [SerializeField] private float _textSpeed = 0.09f; //скорость отображения текста диалога

    private DialogData _data;
    private int currentSentence;
    private Coroutine _typingRoutine;

    private IEnumerator TypeDialogText() //отображение текста диалога
    {
        _text.text = string.Empty;
        var sentence = _data.Sentences[currentSentence];
        foreach(var letter in sentence)
        {
            _text.text += letter;
            yield return new WaitForSeconds(_textSpeed);
        }

        _typingRoutine = null;
    }

    private void StopTypeAnimation() //прерывание анимации отображения текста
    {
        if (_typingRoutine != null)
            StopCoroutine(_typingRoutine);
        _typingRoutine = null;
    }

    public void OnSkip()
    {
        if (_typingRoutine == null) return;

        StopTypeAnimation();
        _text.text = _data.Sentences[currentSentence];
    }

    public void OnContinue() //переключение на следующий текст диалога
    {
        StopTypeAnimation();

        currentSentence++;
        bool isDialogCompleted = currentSentence >= _data.Sentences.Length;
        if (!isDialogCompleted)
            OnStartDialog();
        else
            Destroy(this.gameObject);
    }

    private void OnStartDialog() //запуск отображения текста
    {
        _typingRoutine = StartCoroutine(TypeDialogText());
    }

    public void ShowDialog(DialogData data) //отображение диалогового окна
    {
        _data = data;
        currentSentence = -1;
        _text.text = string.Empty;

        OnContinue();
    }

    [SerializeField] private DialogData testData;

    [Obsolete]
    [ContextMenu("d")]
    public void Test()
    {
        ShowDialog(testData);
    }
}
