using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;

    private int blockOffset = 4;

    void OnEnable()
    {
        // Subscribe to the event
        EventManager.onGameStateChanged += GameManager_onGameStateChanged;
    }

    void OnDisable()
    {
        // Unsubscribe to the event
        EventManager.onGameStateChanged -= GameManager_onGameStateChanged;
    }

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LoadLevel)
        {
            AdjustGameCameraPosition();
        }
    }

    private void AdjustGameCameraPosition()
    {
        int levelIndex = LevelManager.Instance.GetLevelIndex();
        Level currentLevel = Levels.levels[levelIndex];
        int[,] LevelMap = currentLevel.GetLevelMap();

        int mapRows = LevelMap.GetLength(0);
        int mapCols = LevelMap.GetLength(1);

        int maxBlockCountInLevel = Mathf.Max(mapRows, mapCols);

        float fieldOfViewRadian = gameCamera.fieldOfView * Mathf.PI / 180;

        Vector3 cameraWord = Tools.ConvertGridToWord(new GridVector(mapRows, mapCols));

        float cameraX = cameraWord.x / 2;
        float cameraY = cameraWord.y / 2;
        float cameraZ = (maxBlockCountInLevel + blockOffset) / Mathf.Sin(fieldOfViewRadian);

        gameCamera.transform.position = new Vector3(cameraX, cameraY, -cameraZ);

    }

}
