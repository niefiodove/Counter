using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public event Action ButtonClicked;

    private string _titleTextStart = "Нажми, чтобы начать отсчёт.";
    private string _titleTextStop = "Нажми, чтобы остоновить отсчёт.";
    private Color _startColor = Color.green;
    private Color _stopColor = Color.red;


    private void Start()
    {
        _text.color = _startColor;
        _text.text = _titleTextStart;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnButtonClick();
        }
    }
    private void OnButtonClick()
    {
        ButtonClicked?.Invoke();

        if(_text.text == _titleTextStart)
            ChangeText(_titleTextStop, _stopColor);
        else 
            ChangeText(_titleTextStart, _startColor);
    }

    private void ChangeText(string text, Color color)
    {
        _text.color = color;
        _text.text = text;
    }
}
