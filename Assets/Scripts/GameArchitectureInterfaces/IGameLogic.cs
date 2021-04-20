public interface IGameLogic {
    bool CheckNeighbours(Tile tile, int x, int y);
    bool IsEmpty(int x, int y);
    bool PossibleNeighBours(Tile tile1, Tile tile2);
    bool CheckGameOverCondition();
}
