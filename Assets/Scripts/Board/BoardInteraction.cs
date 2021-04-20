using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class BoardInteraction : MonoBehaviour {

    private Board board;
    public IDynamicMemory gameData;
    public event System.EventHandler OnTilePlaced;
    public event System.EventHandler OnIllegalMove;
    [SerializeField] private Transform tileImage;
    [SerializeField] private GameObject tilePlacedParticleSystem;
    public static BoardInteraction i;
    private bool _firstTile = true;
    public bool LockBoard = false;

    private void Start() {
        i = this;
        board = gameData.GetBoard();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            OnSkippedTile(gameData.GetCurrentTile());
        }
    }

    public void SetUpBoard(Board board) {
        this.board = board;
    }

    public bool OnEmptyTileClicked(ClickableBoardElement clickedObject) {
        if (LockBoard) return false;
        if (board.CanPlaceTile(gameData.GetCurrentTile(), clickedObject.x, clickedObject.y) || _firstTile) {
            board.PlaceTile(gameData.GetCurrentTile(), clickedObject.x, clickedObject.y);
            gameData.SetScore(gameData.GetScore()+100);
            Transform obj = Instantiate(tileImage, FindObjectOfType<Canvas>().transform);
            obj.position = tileImage.position;
            new SlideTileEffect(obj, clickedObject, gameData.GetCurrentTile(), tilePlacedParticleSystem);
            gameData.NextCurrentTile();
            _firstTile = false;
            OnTilePlaced?.Invoke(this,null);
            return true;
        }
        else if(!board.AllNeighboursEmpty(clickedObject.x, clickedObject.y)) {
            IllegalMove();
            gameData.NextCurrentTile();
        }
        return false;
    }

    public void OnSkippedTile(Tile tile) {
        if (board.CanPlaceTile(tile)) {
            IllegalMove();
            gameData.NextCurrentTile();
        }
        else {
            gameData.NextCurrentTile();
        }
    }

    private void IllegalMove() {
        gameData.SetScore(gameData.GetScore() - 200);
        gameData.SetLifes(gameData.GetLifes() - 1);
        OnIllegalMove?.Invoke(this,null);
    }

}