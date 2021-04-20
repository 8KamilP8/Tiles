using UnityEngine;
using TMPro;
using System.Text;

public class TimerDisplay : TextDisplay, IDisplay<float> {

    private int _seconds;
    private int _miliseconds;
    private int _minutes;
    [SerializeField] private string prefix;

    public void ConnectWithValue(ref float value) {
        Convert(value);
    }

    public void UpdateDisplay() {
        StringBuilder builder = new StringBuilder();
        builder.Insert(0, _miliseconds);
        if (_miliseconds < 10) {
            builder.Insert(0, "00");
        }
        else if (_miliseconds < 100) {
            builder.Insert(0, '0');
        }
        builder.Insert(0, ':');
        builder.Insert(0,_seconds);
        if (_seconds < 10) {
            builder.Insert(0, '0');
        }
        builder.Insert(0, ':');
        builder.Insert(0, _minutes);
        if(_minutes < 10) {
            builder.Insert(0, 0);
        }
        _textMesh.text = prefix + builder.ToString();
    }

    public void UpdateDisplay(float value) {
        Convert(value);
        UpdateDisplay();
    }

    private void Convert(float seconds) {
        int wholeSeconds = Mathf.FloorToInt(seconds);
        _miliseconds = (int)((seconds- Mathf.Floor(seconds)) *1000);
        _seconds = wholeSeconds % 60;
        _minutes = wholeSeconds / 60;
    }
}
