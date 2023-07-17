using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GamePlayManager : MonoBehaviour
{
    public PlayerControl playerControl;

    private void OnEnable()
    {
        // Subscribe to the event
        EventManager.onGameStateChanged += GameManager_onGameStateChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe to the event
        EventManager.onGameStateChanged -= GameManager_onGameStateChanged;
    }

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LevelLoaded)
        {
            InitPlayerToGrid();
        }
        else if (GameState == GameStates.NextLevel)
        {
        }
    }

    private void InitPlayerToGrid(float initPosZ = -0.5f)
    {
        int levelIndex = LevelManager.Instance.GetLevelIndex();
        GridVector initPos = Levels.levels[levelIndex].GetPlayer().pos;

        Vector3 cubePosWord = Tools.ConvertGridToWord(initPos);
        cubePosWord.z = initPosZ;

        playerControl.InitPos(cubePosWord);
    }

    private void HandleInput()
    {
        //if (!isHandleInputActive)
        //    return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -1 * Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            int blockPosWordX = Mathf.FloorToInt(worldPosition.x);
            int blockPosWordY = Mathf.FloorToInt(worldPosition.y);

        }
    }

}
