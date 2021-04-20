using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDrawerInitData 
{
    public List<Vector2Int> goalPoints;
    public List<InitTileData> initTileData;

}

public class InitTileData {
    public Tile tile;
    public int x;
    public int y;
}
