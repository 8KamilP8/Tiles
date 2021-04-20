using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WinConditionChecker :  IWinConditionChecker {

    private WinConditionData _winConditionData;
    private IDynamicMemory _memory;
    public System.EventHandler OnWin;

    public WinConditionChecker(WinConditionData winConditionData, IDynamicMemory memory) {
        _memory = memory;
       _winConditionData = winConditionData;
    }

    public bool CheckWinCondition() {
        if (_winConditionData.AllGoalPoint((point) => _memory.GetTile(point.x, point.y).type != TileType.EMPTY)) {
            OnWin?.Invoke(this, null);
            return true;
        }
        else {
            return false;
        }
    }
}
public interface IWinConditionChecker {
    bool CheckWinCondition();
}



public class WinConditionData {
    private List<Vector2Int> _goalPoints;
    
    public class Builder {
        private WinConditionData _product;

        public Builder(int size = 5) {
            _product = new WinConditionData();
            _product._goalPoints = new List<Vector2Int>(size);
        }
        public void AddPoint(Vector2Int point) {
            _product._goalPoints.Add(point);
        }
        public void AddPoint(int x, int y) {
            AddPoint(new Vector2Int(x, y));
        }
        public void AddColumnSeries(int columnNr, int firstIndex, int lastIndex) {
            for (int i = firstIndex; i <= lastIndex; ++i) {
                AddPoint(new Vector2Int(columnNr, i));
            }
        }
        public void AddRowSeries(int columnNr, int firstIndex, int lastIndex) {
            for (int i = firstIndex; i <= lastIndex; ++i) {
                AddPoint(new Vector2Int(i, columnNr));
            }
        }
        public WinConditionData GetResult() {
            return _product;
        }

    }
    private WinConditionData() { }

    public bool AllGoalPoint(System.Func<Vector2Int, bool> predicate) {
        foreach(Vector2Int point in _goalPoints) {
            if (!predicate(point)) return false;
        }
        return true;
    }
    public bool IsOnList(int x, int y) {
        return IsOnList(new Vector2Int(x, y));
    }
    public bool IsOnList(Vector2Int point) {
        return _goalPoints.Contains(point);
    }
}