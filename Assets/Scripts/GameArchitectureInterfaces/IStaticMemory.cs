using UnityEngine;

public interface IStaticMemory {
    Sprite GetSprite(TileType type);
    Color GetColor(int id);
}
