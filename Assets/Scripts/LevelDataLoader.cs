using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataLoader : MonoBehaviour
{
    private List<Vector2Int> _goalPoints;

    private List<GameOverCondition> _gameOverConditions;

    public void AddGameOverCondition(GameOverCondition gameOverCondition) {
        _gameOverConditions.Add(gameOverCondition);
    }

    public void AddGoalPoint(int x, int y) {
        _goalPoints.Add(new Vector2Int(x, y));
    }
    public void AddGoalPoint(Vector2Int point) {
        _goalPoints.Add(point);
    }

    public bool IsInGoalPointsList(Vector2Int point) {
        return _goalPoints.Contains(point);
    }
}
