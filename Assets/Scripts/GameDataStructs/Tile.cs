using UnityEngine;

public struct Tile {
    public Color color;
    public TileType type;

    public Tile(Color color, TileType type) {
        this.color = color;
        this.type = type;
    }
    public bool IsPossibleNeighbour(Tile other) {
        return other.color == color || type == other.type || other.type == TileType.EMPTY || type == TileType.EMPTY || type == TileType.JOKER || other.type == TileType.JOKER;
    }
}

public enum TileType {
    EMPTY, JOKER, TYPE1, TYPE2, TYPE3, TYPE4 
}