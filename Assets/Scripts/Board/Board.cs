

public class Board {
    private Tile[,] tiles;

    public Board(int xSize, int ySize) {
        tiles = new Tile[xSize, ySize];
        for (int x= 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {
                tiles[x,y] = new Tile(UnityEngine.Color.white, TileType.EMPTY);
            }
        }
    }
    private void ForEachNeighbour(int x, int y, System.Action<Tile> action) {
        try {
            action(tiles[x + 1, y]);
        }
        catch (System.IndexOutOfRangeException _) { }
        try {
            action(tiles[x - 1, y]);
        }
        catch (System.IndexOutOfRangeException _) { }
        try {
            action(tiles[x, y + 1]);
        }
        catch (System.IndexOutOfRangeException _) { }
        try {
            action(tiles[x, y - 1]);
        }
        catch (System.IndexOutOfRangeException _) { }
    }
    private bool ForEachNeighbourFullfillsAnd(int x, int y, System.Func<Tile, bool> predicate, bool defaultValue = true) {
        bool last = true;
        try {
            last = predicate(tiles[x + 1, y]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == false) return false;

        try {
            last = predicate(tiles[x - 1, y]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == false) return false;

        try {
            last = predicate(tiles[x, y + 1]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == false) return false;

        try {
            last = predicate(tiles[x, y - 1]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        return last;
    }
    private bool ForEachNeighbourFullfillsOr(int x, int y, System.Func<Tile, bool> predicate, bool defaultValue=true) {
        bool last = true;
        try {
            last = predicate(tiles[x + 1, y]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == false) return true;

        try {
            last = predicate(tiles[x - 1, y]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == true) return true;

        try {
            last = predicate(tiles[x, y + 1]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        if (last == false) return true;

        try {
            last = predicate(tiles[x, y - 1]);
        }
        catch (System.IndexOutOfRangeException _) {
            last = defaultValue;
        }
        return last;
    }
    private bool ForEachNeighbourFullfills(int x, int y, System.Func<Tile, bool> predicate, System.Func<bool,bool,bool> operation) {
        bool status = operation(predicate(tiles[x + 1, y]), predicate(tiles[x - 1, y]));
        status = operation(status, predicate(tiles[x, y + 1]));
        status = operation(status, predicate(tiles[x, y - 1]));
        return status;
    }
    public bool CanPlaceTile(Tile tile, int x, int y) {
        if (IsEmptyField(x, y)) {
            return ForEachNeighbourFullfillsAnd(x, y, (t) => t.IsPossibleNeighbour(tile)) && !AllNeighboursEmpty(x,y);
        }
        else {
            return false;
        }
    }
    public bool CanPlaceTile(Tile tile) {
        for (int x = 0; x < tiles.GetLength(0); x++) {
            for (int y = 0; y < tiles.GetLength(1); y++) {
                if (CanPlaceTile(tile, x, y)) return true;
            }
        }
        return false;
    }
    public bool AllNeighboursEmpty(int x, int y) {
        return ForEachNeighbourFullfillsAnd(x, y, (t)=>t.type==TileType.EMPTY);

    }
    private bool CheckNeighoburing(Tile tile, int x, int y) {
        try {           
            return tiles[x, y].IsPossibleNeighbour(tile);
        }
        catch (System.Exception _){
            return true;
        }
    }
    public void PlaceTile(Tile tile, int x, int y) {
        if (IsEmptyField(x, y)) {
            tiles[x, y] = tile;
        }
    }
    public TileType GetTileType(int x, int y) {
        return tiles[x, y].type;
    }
    public UnityEngine.Color GetTileColor(int x, int y) {
        return tiles[x, y].color;
    } 
    public void ClearTile(int x, int y) {
        tiles[x, y].type = TileType.EMPTY;
    }

    public bool IsEmptyField(int x, int y) {
        return tiles[x, y].type == TileType.EMPTY;
    }

    public UnityEngine.Vector2Int GetSize() {
        return new UnityEngine.Vector2Int(tiles.GetLength(0), tiles.GetLength(1));
    }
}
