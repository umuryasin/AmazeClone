using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GamePlayManager : MonoBehaviour
{
    [Header("Settings")]
    public float winAnimDelayTimeMag = 0.25f;
    public float winAnimTime = 0.75f;

    public PlayerControl playerControl;

    private BlockControl[,] _blockMap;
    private int _mapRow;
    private int _mapCol;

    private int _unMarkedblockCount;
    private Color _blockColor;
    private bool _isGameStart;

    private void OnEnable()
    {
        EventManager.onGameStateChanged += GameManager_onGameStateChanged;
        EventManager.onInputChanged += HandleInput;
        EventManager.onGridPosChanged += OnGridPosChanged;
        EventManager.onPlayerMoveEnd += OnPlayerMoveEnd;
    }

    private void OnDisable()
    {
        EventManager.onGameStateChanged -= GameManager_onGameStateChanged;
        EventManager.onInputChanged -= HandleInput;
        EventManager.onGridPosChanged -= OnGridPosChanged;
        EventManager.onPlayerMoveEnd -= OnPlayerMoveEnd;
    }

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LevelLoaded)
        {
            _blockMap = LevelManager.Instance.activeCubeArr;
            _mapRow = _blockMap.GetLength(0);
            _mapCol = _blockMap.GetLength(1);

            _unMarkedblockCount = Tools.GetUnMarkedBlockCount(_blockMap);
            InitPlayerToGrid();
            _isGameStart = true;
        }
        else if (GameState == GameStates.LoadLevel)
        {
            playerControl.SetPlayerActive(false);
        }
        else if (GameState == GameStates.WinGame)
        {
            _isGameStart = false;
            WinAnim();
        }

    }

    private void InitPlayerToGrid()
    {
        int levelIndex = LevelManager.Instance.GetLevelIndex();
        GridVector initPos = Levels.levels[levelIndex].GetPlayer().pos;
        _blockColor = Levels.levels[levelIndex].GetPlayerColor();
        playerControl.InitPos(initPos);
        playerControl.InitColor(_blockColor);
        SetBlockColor(initPos);
        playerControl.SetPlayerActive(true);
    }
    private void OnGridPosChanged(GridVector gridPos)
    {
        SetBlockColor(gridPos);
    }

    private void HandleInput(InputState inputState)
    {
        if (!_isGameStart)
            return;

        if (playerControl.isPlayerMoving)
            return;

        GridVector directionVector = GetDirectionVector(inputState);
        GridVector playerPos = playerControl.currentPos;

        bool isNextPosActive = true;
        do
        {
            int row = playerPos.Row + directionVector.Row;
            int col = playerPos.Col + directionVector.Col;

            if (row >= 0 && row < _mapRow && col >= 0 && col < _mapCol)
            {
                if (_blockMap[row, col].blockType == BlockType.Wall)
                {
                    isNextPosActive = false;
                }
                else
                {
                    playerPos += directionVector;
                }
            }
            else
            {
                isNextPosActive = false;
            }
        }
        while (isNextPosActive);

        if (playerPos != playerControl.currentPos)
        {
            playerControl.StartMove(playerPos, directionVector);
        }

    }

    private void WinAnim()
    {
        for (int row = 0; row < _mapRow; row++)
        {
            for (int col = 0; col < _mapCol; col++)
            {
                if (_blockMap[row, col].blockType == BlockType.Marked)
                {
                    float delay = row * winAnimDelayTimeMag;
                    _blockMap[row, col].WinAnim(delay, winAnimTime);
                }
            }
        }
    }

    private void SetBlockColor(GridVector gridPos)
    {
        int row = gridPos.Row;
        int col = gridPos.Col;
        Color color = _blockColor - Color.white * 0.35f;
        _blockMap[row, col].SetAsMarked(color);
    }

    private void OnPlayerMoveEnd()
    {
        int markedBlockCount = Tools.GetMarkedBlockCount(_blockMap);
        if (markedBlockCount == _unMarkedblockCount)
        {
            GameManager.Instance.WinGame();
        }
    }

    private GridVector GetDirectionVector(InputState inputState)
    {
        GridVector directionVector = GridVector.zero;
        if (inputState == InputState.Right)
            directionVector = GridVector.Right;
        else if (inputState == InputState.Left)
            directionVector = GridVector.Left;
        else if (inputState == InputState.Up)
            directionVector = GridVector.Up;
        else if (inputState == InputState.Down)
            directionVector = GridVector.Down;
        return directionVector;
    }

}
