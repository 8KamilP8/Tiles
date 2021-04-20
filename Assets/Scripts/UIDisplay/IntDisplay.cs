using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class IntDisplay : TextDisplay, IDisplay<int> {

    [SerializeField] private string prefix;
    private object _reference;

    public void ConnectWithValue(ref int value) {
        _reference = value;
    }

    public void UpdateDisplay() {
        UpdateDisplay((int)_reference);
    }

    public void UpdateDisplay(int value) {
        _textMesh.text = prefix + _reference.ToString();
    }
}
