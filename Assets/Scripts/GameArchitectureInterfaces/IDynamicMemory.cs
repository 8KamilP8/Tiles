public interface IDynamicMemory {
    int GetScore();
    void SetScore(int newScore);
    Tile GetTile(int x, int y);
    void SetTile(int x, int y, Tile tile);
    int GetLifes();
    void SetLifes(int newLifes);
    Tile GetCurrentTile();
    void NextCurrentTile();
    Board GetBoard();
}
