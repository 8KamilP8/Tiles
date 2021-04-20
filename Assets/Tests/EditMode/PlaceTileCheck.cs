using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlaceTileCheck
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlaceTileSimplePasses() {
        Board board = new Board(5, 5);

        Tile blue_apple = new Tile(Color.blue, TileType.TYPE1);
        board.PlaceTile(blue_apple, 0, 0);
        Assert.AreEqual(TileType.TYPE1, board.GetTileType(0,0));
        Assert.AreEqual(Color.blue, board.GetTileColor(0, 0));

        Tile red_banana = new Tile(Color.red, TileType.TYPE2);
        board.PlaceTile(red_banana, 0, 0);
        Assert.AreEqual(TileType.TYPE1, board.GetTileType(0, 0));
        Assert.AreEqual(Color.blue, board.GetTileColor(0, 0));

        board.PlaceTile(red_banana, 1, 1);
        Assert.AreEqual(TileType.TYPE2, board.GetTileType(1, 1));
        Assert.AreEqual(Color.red, board.GetTileColor(1, 1));
    }
    [Test]
    public void IsPossibleNeighbourSimplePasses() {
        Tile blue_apple = new Tile(Color.blue, TileType.TYPE1);
        Tile red_apple = new Tile(Color.red, TileType.TYPE1);
        Tile red_banana = new Tile(Color.red, TileType.TYPE2);
        Tile yellow_banana = new Tile(Color.yellow, TileType.TYPE2);

        bool result = blue_apple.IsPossibleNeighbour(red_apple);
        Assert.AreEqual(true, result);

        result = blue_apple.IsPossibleNeighbour(red_banana);
        Assert.AreEqual(false, result);

        result = blue_apple.IsPossibleNeighbour(yellow_banana);
        Assert.AreEqual(false, result);

        result = red_apple.IsPossibleNeighbour(red_apple);
        Assert.AreEqual(true, result);

        result = red_apple.IsPossibleNeighbour(red_banana);
        Assert.AreEqual(true, result);

        result = red_apple.IsPossibleNeighbour(yellow_banana);
        Assert.AreEqual(false, result);
    }
    [Test]
    public void PlaceTileCheckSimplePasses()
    {
        Board board = new Board(5, 5);
        Tile blue_apple = new Tile(Color.blue, TileType.TYPE1);
        Tile red_apple = new Tile(Color.red, TileType.TYPE1);
        Tile red_banana = new Tile(Color.red, TileType.TYPE2);
        Tile yellow_banana = new Tile(Color.yellow, TileType.TYPE2);
        board.PlaceTile(blue_apple, 0, 0);

        bool result = board.CanPlaceTile(red_apple,0,1);      
        Assert.AreEqual(true, result);

        result = board.CanPlaceTile(blue_apple, 0, 1);
        Assert.AreEqual(true, result);

        result = board.CanPlaceTile(yellow_banana, 0, 1);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(yellow_banana, 1, 0);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(red_apple, 1, 0);
        Assert.AreEqual(true, result);

        board.PlaceTile(new Tile(Color.blue, TileType.TYPE1), 1, 0);
    }
    [Test]
    public void PlaceTileCheckPasses() {
        Board board = new Board(5, 5);
        Tile blue_apple = new Tile(Color.blue, TileType.TYPE1);
        Tile red_apple = new Tile(Color.red, TileType.TYPE1);
        Tile red_banana = new Tile(Color.red, TileType.TYPE2);
        Tile yellow_banana = new Tile(Color.yellow, TileType.TYPE2);

        board.PlaceTile(blue_apple, 1, 1);
        board.PlaceTile(red_banana, 0, 0);

        bool result = board.CanPlaceTile(red_apple, 0, 1);
        Assert.AreEqual(true, result);

        result = board.CanPlaceTile(red_apple, 1, 0);
        Assert.AreEqual(true, result);

        result = board.CanPlaceTile(blue_apple, 0, 1);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(blue_apple, 1, 0);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(yellow_banana, 0, 1);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(yellow_banana, 1, 0);
        Assert.AreEqual(false, result);

        board.PlaceTile(red_banana, 3, 1);

        result = board.CanPlaceTile(red_apple, 2, 1);
        Assert.AreEqual(true, result);

        result = board.CanPlaceTile(blue_apple, 2, 1);
        Assert.AreEqual(false, result);

        result = board.CanPlaceTile(yellow_banana, 2, 1);
        Assert.AreEqual(false, result);

    }
}
