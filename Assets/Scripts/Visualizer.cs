using TMPro;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private InputReader _toggle;
    [SerializeField] private TextMeshProUGUI _text;

    private string _titleTextStart = "Нажми, чтобы начать отсчёт.";
    private string _titleTextStop = "Нажми, чтобы остоновить отсчёт.";
    private Color _startColor = Color.green;
    private Color _stopColor = Color.red;

    private void OnEnable()
    {
        _toggle.ButtonClicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _toggle.ButtonClicked -= OnButtonClick;
    }

    private void Start()
    {
        ChangeText(_titleTextStart, _startColor);
    }

    private void ChangeText(string text, Color color)
    {
        _text.color = color;
        _text.text = text;
    }

    private void OnButtonClick()
    {
        if (_text.text == _titleTextStart)
            ChangeText(_titleTextStop, _stopColor);
        else
            ChangeText(_titleTextStart, _startColor);
    }
}
