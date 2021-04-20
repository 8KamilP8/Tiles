using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UITileImageDisplay : MonoBehaviour, IDisplay<Tile> {

    private Image img;

    private Image _img {
        get {
            if (img == null)
                img = GetComponent<Image>();
            return img;
        }
    }
    private IStaticMemory memory;

    private IStaticMemory _memory {
        get {
            if (memory == null)
                memory = GameScriptsInitializer.i.GetStaticDataReference();
            return memory;
        }
    }
    private object _reference;

    public void ConnectWithValue(ref Tile value) {
        _reference = value;
    }

    public void UpdateDisplay() {       
        if (_reference == null) return;
        UpdateDisplay((Tile)_reference);
    }

    public void UpdateDisplay(Tile value) {
        _img.color = value.color;
        _img.sprite = _memory.GetSprite(value.type);
    }
}
