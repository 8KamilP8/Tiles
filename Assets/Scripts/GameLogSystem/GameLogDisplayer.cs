using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogDisplayer : MonoBehaviour
{
    private GameLog logger;

    [SerializeField] private int logBufferSize = 5;
    [SerializeField] private float logDisplayDuration;

    private int currentDisplayedQuantity;

    public event System.EventHandler OnClock;

    private void Start() {
        logger = new GameLog();
        for (int i = 0; i < 15; i++) {
            var builder = new GameLogMessage.Builder(1,0,false);
            logger.Log(builder.GetProduct());
        }

    }
    private void Update() {
        OnClock?.Invoke(this,null);
        try {
            if(currentDisplayedQuantity < logBufferSize) {
                GameLogMessage glm = logger.GetLog();               
                DisplayLog(glm);
            }
            
        }
        catch (System.Exception _) {}
    }

    private void DisplayLog(GameLogMessage glm) {
        OnClock += glm.OnClock;
        currentDisplayedQuantity++;
        Debug.Log(glm.ToString());
    }

    private void ClearLog(GameLogMessage log, System.EventArgs args) {
        OnClock -= log.OnClock;
        currentDisplayedQuantity--;
        Debug.Log("Clear Log: " + log.ToString());
    }
}
