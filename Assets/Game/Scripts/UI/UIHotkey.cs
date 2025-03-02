using System;
using TMPro;
using UnityEngine;

public class UIHotkey : MonoBehaviour
{
    [SerializeField] private string symbol;
    [SerializeField] private TextMeshProUGUI symbolText;

    private void Start()
    {
        symbolText.text = symbol;
    }
    
    public void Show() => symbolText.enabled = true;
    public void Hide() => symbolText.enabled = false;
}
