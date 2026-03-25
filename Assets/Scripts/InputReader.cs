using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action ButtonClicked;

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
    }
}
