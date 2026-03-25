using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _countingCoroutine;
    private float _currentValue = 0f;
    private float _stepCount = 0.5f;
    private float _stepDelay = 1f;

    public event Action<float> CounterTextSent;
    public event Action<bool> StartCounter;

    private void OnEnable()
    {
        _inputReader.ButtonClicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _inputReader.ButtonClicked -= OnButtonClick;
    }
    private void OnButtonClick()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
            StartCounter?.Invoke(false);
        }
        else
        {
            _countingCoroutine = StartCoroutine(Counting());
            StartCounter?.Invoke(true);
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_stepDelay);
        bool isWork = true;

        while (isWork)
        {
            CounterTextSent?.Invoke(_currentValue);
            _currentValue += _stepCount;
            yield return wait;
        }
    }
}