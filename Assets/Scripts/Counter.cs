using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Toggle _toggle;

    private Coroutine _countingCoroutine;
    private bool _isActive = false;
    private float _currentValue = 0f;
    private float _stepCount = 0.5f;
    private float _stepDelay = 1f;

    private void Start()
    {
        _text.text = $"{_currentValue}";
    }

    private void OnEnable()
    {
        _toggle.ButtonClicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _toggle.ButtonClicked -= OnButtonClick;
    }
    private void OnButtonClick()
    {
        if( _isActive )
        {
            if(_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
                _isActive = false;
        }
        else
        {
            _countingCoroutine = StartCoroutine(Counting());
            _isActive = true;
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_stepDelay);
        bool isWork = true;

        while (isWork)
        {
            DisplayCounting(_currentValue);
            _currentValue += _stepCount;
            yield return wait;
        }
    }

    private void DisplayCounting(float count)
    {
        _text.text = count.ToString("");
    }
}