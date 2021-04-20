using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog {

    private Queue<GameLogMessage> messageQueue;

    public GameLog() {
        messageQueue = new Queue<GameLogMessage>();
    }

    public void Log(GameLogMessage message) {
        messageQueue.Enqueue(message);
    }

    public GameLogMessage GetLog() {
        return messageQueue.Dequeue();
    }
}
