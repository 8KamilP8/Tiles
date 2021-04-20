using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDrawer  {

    private ClickableBoardElement _emptyTilePrefab;
    private ClickableBoardElement[,] boardElements;
    private Transform _transform;
    public BoardDrawer(ClickableBoardElement prefab, Transform drawerTransform) {
        _emptyTilePrefab = prefab;
        _transform = drawerTransform;
    }

    public void DrawBoard(int sizeX, int sizeY) {
        boardElements = new ClickableBoardElement[sizeX, sizeY];
        for (int y = 0; y < sizeY; y++) {
            for(int x = 0; x < sizeX; x++) {
                boardElements[x, y] = Object.Instantiate(_emptyTilePrefab, _transform);
                boardElements[x, y].SetUp(x, y);
                
            }
        }
    }
    public void ColorFromWinningCondition(WinConditionData winCondition) {
        for (int y = 0; y < boardElements.GetLength(1); y++) {
            for (int x = 0; x < boardElements.GetLength(0); x++) {
                if (winCondition.IsOnList(x, y))
                    ColorTileYellow(x, y);
            }
        }
    }
    public void ColorTile(int x, int y, Color color) {
        boardElements[x, y].GetComponent<UnityEngine.UI.Image>().color = color;
    }
    public void ColorTileYellow(int x, int y) {
        Color yellow=Color.yellow;
        yellow.a = 0.5f;
        ColorTile(x, y, yellow);
    }
}
