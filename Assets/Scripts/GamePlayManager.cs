using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GamePlayManager : MonoBehaviour
{
    public PlayerControl playerControl;

    private BlockControl[,] blockMap;
    private int mapRow;
    private int mapCol;

    private int _unMarkedblockCount;
    private int _markedblockCount;

    private void OnEnable()
    {
        // Subscribe to the event
        EventManager.onGameStateChanged += GameManager_onGameStateChanged;
        EventManager.onInputChanged += HandleInput;
        EventManager.onGridPosChanged += OnGridPosChanged;
        EventManager.onPlayerMoveEnd += OnPlayerMoveEnd;
    }

    private void OnDisable()
    {
        // Unsubscribe to the event
        EventManager.onGameStateChanged -= GameManager_onGameStateChanged;
        EventManager.onInputChanged -= HandleInput;
        EventManager.onGridPosChanged -= OnGridPosChanged;
        EventManager.onPlayerMoveEnd -= OnPlayerMoveEnd;
    }

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LevelLoaded)
        {
            blockMap = LevelManager.Instance.activeCubeArr;
            mapRow = blockMap.GetLength(0);
            mapCol = blockMap.GetLength(1);

            _unMarkedblockCount = Tools.GetUnMarkedBlockCount(blockMap);
            InitPlayerToGrid();
        }
        else if (GameState == GameStates.NextLevel)
        {
        }
    }

    private void InitPlayerToGrid()
    {
        int levelIndex = LevelManager.Instance.GetLevelIndex();
        GridVector initPos = Levels.levels[levelIndex].GetPlayer().pos;
        playerControl.InitPos(initPos);
        SetBlockColor(initPos, Color.red);
    }
    private void OnGridPosChanged(GridVector gridPos)
    {
        SetBlockColor(gridPos, Color.red);
    }

    private void HandleInput(InputState inputState)
    {
        if (playerControl.isPlayerMoving)
            return;

        GridVector directionVector = GetDirectionVector(inputState);
        GridVector playerPos = playerControl.currentPos;

        bool isNextPosActive = true;
        do
        {
            int row = playerPos.Row + directionVector.Row;
            int col = playerPos.Col + directionVector.Col;

            if (row >= 0 && row < mapRow && col >= 0 && col < mapCol)
            {
                if (blockMap[row, col].blockType == BlockType.Wall)
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
            playerControl.StartMove(playerPos);
        }

    }

    private void SetBlockColor(GridVector gridPos, Color color)
    {
        int row = gridPos.Row;
        int col = gridPos.Col;
        blockMap[row, col].SetAsMarked(color);
    }

    private void OnPlayerMoveEnd()
    {
        int markedBlockCount = Tools.GetMarkedBlockCount(blockMap);
        if (markedBlockCount == _unMarkedblockCount)
        {
            Debug.Log(" success");
            GameManager.Instance.NextLevel();
            GameManager.Instance.LoadLevel();
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
