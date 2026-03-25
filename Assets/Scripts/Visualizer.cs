using TMPro;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _handlerText;
    [SerializeField] private TextMeshProUGUI _counterText;

    private string _titleTextStart = "Нажми, чтобы начать отсчёт.";
    private string _titleTextStop = "Нажми, чтобы остоновить отсчёт.";
    private float _startCounterValue = 0;
    private Color _startColor = Color.green;
    private Color _stopColor = Color.red;

    private void OnEnable()
    {
        _counter.CounterTextSent += OnValueChanged;
        _counter.StartCounter += OnButtonClick;
    }

    private void OnDisable()
    {
        _counter.CounterTextSent -= OnValueChanged;
        _counter.StartCounter -= OnButtonClick;
    }

    private void Start()
    {
        ChangeText(_titleTextStart, _startColor);
        OnValueChanged(_startCounterValue);
    }

    private void ChangeText(string text, Color color)
    {
        _handlerText.color = color;
        _handlerText.text = text;
    }

    private void OnValueChanged(float value)
    {
        _counterText.text = value.ToString("");
    }

    private void OnButtonClick(bool isWorkCorutain)
    {
        if (isWorkCorutain)
            ChangeText(_titleTextStop, _stopColor);
        else
            ChangeText(_titleTextStart, _startColor);
    }
}
