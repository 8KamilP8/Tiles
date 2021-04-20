using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScriptsInitializer : MonoBehaviour {

    private DynamicGameData _dynamicGameData;
    private StaticGameData _staticGameData;
    [SerializeField] private UITileImageDisplay _nextTileDisplay;
    [SerializeField] private IntDisplay _scoreDisplay;
    [SerializeField] private IntDisplay _lifesDisplay;
    [SerializeField] private ClickableBoardElement _boardElementPrefab;
    [SerializeField] private Transform _boardParent;
    [SerializeField] private SoundManager _soundManager;
    public static GameScriptsInitializer i;
    void Start() {
        i = this;

        _staticGameData = GetComponent<StaticGameData>();

        WinConditionData.Builder builder = new WinConditionData.Builder();
        builder.AddRowSeries(4, 1, 13);
        builder.AddRowSeries(5, 1, 13);
        builder.AddRowSeries(3, 2, 12);
        builder.AddRowSeries(6, 2, 12);
        builder.AddRowSeries(7, 3, 11);
        builder.AddRowSeries(2, 3, 11);
        builder.AddPoint(0, 0);
        builder.AddPoint(0, 9);
        builder.AddPoint(14, 9);
        builder.AddPoint(14, 0);
        _dynamicGameData = new DynamicGameData();
        
        _dynamicGameData.Init(_staticGameData, _nextTileDisplay, _scoreDisplay, _lifesDisplay);

        WinConditionChecker winConditionChecker = new WinConditionChecker(builder.GetResult(), _dynamicGameData);
        BoardDrawer boardDrawer = new BoardDrawer(_boardElementPrefab, _boardParent);
        var boardSize = _dynamicGameData.GetBoard().GetSize();
        boardDrawer.DrawBoard(boardSize.x, boardSize.y);
        boardDrawer.ColorFromWinningCondition(builder.GetResult());
        var boardInteracion = GetComponent<BoardInteraction>();
        boardInteracion.gameData = _dynamicGameData;
        boardInteracion.OnTilePlaced += (o,args)=>winConditionChecker.CheckWinCondition();
        boardInteracion.OnTilePlaced += (o, args) => _soundManager.PlayOneShot(SoundEffect.CLICK);
        boardInteracion.OnIllegalMove += (o, args) => _soundManager.PlayOneShot(SoundEffect.WRONG);
        winConditionChecker.OnWin += (o,args) => _soundManager.PlayOneShot(SoundEffect.WIN_SOUND);
    }
    public StaticGameData GetStaticDataReference() {
        return _staticGameData;
    }
    public DynamicGameData GetDynamicDataReference() {
        return _dynamicGameData;
    }


    
}
