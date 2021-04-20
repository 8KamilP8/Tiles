using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Timer : PauseMonoBehaviour
{

    private float _time = 0f;
    private float time {
        get { return _time; }
        set {
            _time = value;
            display.UpdateDisplay(_time);
        }
    }
    [SerializeField] private TimerDisplay display;
    // Update is called once per frame
    protected override void OnUpdate()
    {
        time += Time.deltaTime;
    }
}
