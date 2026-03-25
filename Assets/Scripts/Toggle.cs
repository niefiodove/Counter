using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Toggle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private string _titleTextStart = "Нажми, чтобы начать отсчёт.";
    private string _titleTextStop = "Нажми, чтобы остоновить отсчёт.";
    private Color _startColor = Color.green;
    private Color _stopColor = Color.red;

    public event Action ButtonClicked;

    private void Start()
    {
        ChangeText(_titleTextStart, _startColor);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
