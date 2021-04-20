using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomUtilities;
using System;

public class DynamicGameData : IDynamicMemory
{
    private Tile currentTile;
    private int lifes;
    private int score;
    private Board board;
    private const int JOKER_PROBABILITY = 3;
    private IStaticMemory staticMemory;

    private IDisplay<Tile> currentTileDisplay;
    private IDisplay<int> currentScoreDisplay;
    private IDisplay<int> lifesDisplay;

    public DynamicGameData(int xSize=15,int ySize=10, int lifes=5) {
        this.lifes = lifes;
        score = 0;
        board = new Board(xSize, ySize);
    }
    public void Init(IStaticMemory staticMemory, IDisplay<Tile> currentTileDisplay, IDisplay<int> currentScoreDisplay, IDisplay<int> lifesDisplay) {
        this.staticMemory = staticMemory;
        this.currentTileDisplay = currentTileDisplay;
        this.currentScoreDisplay = currentScoreDisplay;
        this.currentScoreDisplay.ConnectWithValue(ref score);
        this.lifesDisplay = lifesDisplay;
        this.lifesDisplay.ConnectWithValue(ref lifes);
        this.lifesDisplay.UpdateDisplay();
        NextCurrentTile();
    }
    public Tile GetCurrentTile() {
        return currentTile;
    }

    public int GetLifes() {
        return lifes;
    }

    public int GetScore() {
        return score;
    }
    
    public Tile GetTile(int x, int y) {
        return new Tile(board.GetTileColor(x,y), board.GetTileType(x,y));
    }

    public void NextCurrentTile() {
        if(Rand.RandomTest(JOKER_PROBABILITY)) {
            currentTile = new Tile(Color.white, TileType.JOKER);
        }
        else {
            currentTile = new Tile(staticMemory.GetColor(-1), (TileType)Rand.GetRandomEnum(typeof(TileType), 2));
        }
        
        currentTileDisplay.ConnectWithValue(ref currentTile);
        currentTileDisplay.UpdateDisplay();
    }

    public void SetLifes(int newLifes) {
        lifes = newLifes;
        lifesDisplay.ConnectWithValue(ref lifes);
        lifesDisplay.UpdateDisplay();
    }

    public void SetScore(int newScore) {       
        score = newScore;
        currentScoreDisplay.ConnectWithValue(ref score);
        currentScoreDisplay.UpdateDisplay();
        
    }

    public void SetTile(int x, int y, Tile tile) {
        board.PlaceTile(tile, x, y);
    }

    public Board GetBoard() {
        return board;
    }
    
}
