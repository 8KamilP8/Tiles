using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomUtilities;

public class StaticGameData : MonoBehaviour,IStaticMemory {

    [SerializeField] private ColorPool colorPool;
    [SerializeField] private TilesTypeMapper mapper;

    public Sprite GetSprite(TileType type) {
        return mapper.GetSprite(type);
    }

    public Color GetColor(int id) {
        if (id < 0 || id >= colorPool.Length)
            return colorPool.GetRandomColor();
        return colorPool.GetColor(id);
    }
}
