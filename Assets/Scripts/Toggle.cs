using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action ButtonClicked;

    private string _buttonTextStart = "Начать.";
    private string _buttonTextStop = "Пауза";


    private void Start()
    {
        _text.text = _buttonTextStart;
        _button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        ButtonClicked?.Invoke();

        if(_text.text == _buttonTextStart)
            _text.text = _buttonTextStop;
        else 
            _text.text = _buttonTextStart;
    }
}
