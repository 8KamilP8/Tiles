using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesTypeMapper : MonoBehaviour {

    [SerializeField] private Sprite[] sprites;
    TilesTypeMapper i;
    public Sprite GetSprite(TileType tileType) {
        return sprites[(int)tileType];
    }
    private void Start() {
        i = this;
    }
}
