using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BlockControl baseCube;
    [SerializeField] private BlockControl obstacleCube;

    [SerializeField] private int maxLevelAreaRows = 40;
    [SerializeField] private int maxLevelAreaCols = 40;

    [SerializeField] private int maxLevelCount = 10;
    [SerializeField] private int levelIndex = 0;

    private List<BlockControl> cubeObjectList;

    public BlockControl[,] activeCubeArr;

    private static LevelManager instance;

    public static LevelManager Instance => instance ?? (instance = FindObjectOfType<LevelManager>());

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

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        cubeObjectList = new List<BlockControl>();

    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("starttttt");
        GameManager.Instance.LoadLevel();
    }

    public void ResetGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LoadLevel)
        {
            LoadLevel();
        }
        else if (GameState == GameStates.NextLevel)
        {
            levelIndex = (levelIndex + 1) % maxLevelCount;
        }

    }

    private void LoadLevel()
    {
        ClearGame();
        BuildLevelMap();
        GameManager.Instance.LevelLoaded();
    }

    private void BuildLevelMap()
    {
        int levelIndex = GetLevelIndex();
        Level currentLevel = Levels.levels[levelIndex];

        int[,] LevelMap = currentLevel.GetLevelMap();
        int mapRows = LevelMap.GetLength(0);
        int mapCols = LevelMap.GetLength(1);

        activeCubeArr = new BlockControl[mapRows, mapCols];

        int AreaRow = (maxLevelAreaRows - mapRows) / 2;
        int AreaCol = (maxLevelAreaCols - mapCols) / 2;

        for (int row = -AreaRow; row < AreaRow + mapRows; row++)
        {
            for (int col = -AreaCol; col < AreaCol + mapCols; col++)
            {
                BlockControl dBlock;
                if (row >= 0 && row < mapRows && col >= 0 && col < mapCols)
                {
                    if (LevelMap[row, col] == 1)
                    {

                        dBlock = CreateBlockFromGrid(obstacleCube, row, col);
                    }
                    else
                    {
                        dBlock = CreateBlockFromGrid(baseCube, row, col, 0);
                    }

                    activeCubeArr[row, col] = dBlock;
                }
                else
                {
                    dBlock = CreateBlockFromGrid(obstacleCube, row, col);
                }

                cubeObjectList.Add(dBlock);
            }
        }
    }

    private BlockControl CreateBlockFromGrid(BlockControl dBlockObject, float initGridPosX, float initGridPosY, float initPosZ = -0.5f)
    {
        Vector3 cubePosWord = Tools.ConvertGridToWord(initGridPosX, initGridPosY);
        cubePosWord.z = initPosZ;
        return Instantiate(dBlockObject, cubePosWord, Quaternion.Euler(Vector3.zero));
    }

    private void ClearGame()
    {
        int objectCount = cubeObjectList.Count;
        for (int i = 0; i < objectCount; i++)
        {
            Destroy(cubeObjectList[i].gameObject);
        }
        cubeObjectList.Clear();
    }

    public int GetLevelIndex()
    {
        return levelIndex;
    }
}
