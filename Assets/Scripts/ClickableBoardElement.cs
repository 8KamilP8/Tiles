using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableBoardElement : MonoBehaviour, IPointerClickHandler {
    private int _x;
    private int _y;
    private bool empty = true;
    private Image _img;

    private IStaticMemory _memory;

    public int x { get { return _x; } }
    public int y { get { return _y; } }

    void Start() {
        _memory = GameScriptsInitializer.i.GetStaticDataReference();
        _img = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            print((x, y));
            if (empty) {
                
                empty = !BoardInteraction.i.OnEmptyTileClicked(this);                
            }
        }
    }

    public void SetUp(int x, int y) {
        this._x = x;
        this._y = y;
        
    }

    public void SetSprite(Sprite sprite) {
        _img.sprite = sprite;
    }
    public void SetToTile(Tile tile) {
        _img.sprite = _memory.GetSprite(tile.type);
        _img.color = tile.color;
    }
}
