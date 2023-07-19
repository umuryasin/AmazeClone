using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;

    private int blockOffset = 7;
    private int blocSize = 1;

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
        int mapRows = currentLevel.GetLevelRow();
        int mapCols = currentLevel.GetLevelCol();

        int maxBlockCountInLevel = Mathf.Max(mapRows, mapCols);

        float fieldOfViewRadian = gameCamera.fieldOfView * Mathf.PI / 180;

        Vector3 cameraWord = Tools.ConvertGridToWord(new GridVector(mapRows, mapCols));

        float cameraX = (cameraWord.x - blocSize) / 2f;
        float cameraY = (cameraWord.y + blocSize) / 2f;
        float cameraZ = (maxBlockCountInLevel + blockOffset) / Mathf.Sin(fieldOfViewRadian);

        gameCamera.transform.position = new Vector3(cameraX, cameraY, -cameraZ);

    }

}
