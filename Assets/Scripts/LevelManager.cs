using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BlockControl baseCube;
    public BlockControl obstacleCube;
    public int maxLevelAreaRows = 40;
    public int maxLevelAreaCols = 40;
    public int maxLevelCount = 10;
    public int levelIndex = 0;

    public BlockControl[,] activeCubeArr;

    private List<BlockControl> _cubeObjectList;
    private static LevelManager _instance;

    public static LevelManager Instance => _instance ?? (_instance = FindObjectOfType<LevelManager>());

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
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _cubeObjectList = new List<BlockControl>();

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

    private void GameManager_onGameStateChanged(GameStates GameState)
    {
        if (GameState == GameStates.LoadLevel)
        {
            LoadLevel();
        }
        else if (GameState == GameStates.WinGame)
        {
            levelIndex = (levelIndex + 1) % maxLevelCount;
        }

    }

    private void LoadLevel()
    {
        StartCoroutine(LoadLevelAsync());

        IEnumerator LoadLevelAsync()
        {
            ClearGame();
            BuildLevelMap();
            yield return new WaitForSeconds(0.2f);
            GameManager.Instance.LevelLoaded();
        }

    }

    private void BuildLevelMap()
    {
        int levelIndex = GetLevelIndex();
        Level currentLevel = Levels.levels[levelIndex];

        int[,] LevelMap = currentLevel.GetLevelMap();
        int mapRows = currentLevel.GetLevelRow();
        int mapCols = currentLevel.GetLevelCol();

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
                        dBlock.blockType = BlockType.Wall;
                    }
                    else
                    {
                        dBlock = CreateBlockFromGrid(baseCube, row, col, 0);
                        dBlock.blockType = BlockType.UnMarked;
                    }

                    activeCubeArr[row, col] = dBlock;
                }
                else
                {
                    dBlock = CreateBlockFromGrid(obstacleCube, row, col);
                }

                _cubeObjectList.Add(dBlock);
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
        int objectCount = _cubeObjectList.Count;
        for (int i = 0; i < objectCount; i++)
        {
            Destroy(_cubeObjectList[i].gameObject);
        }
        _cubeObjectList.Clear();
    }

    public int GetLevelIndex()
    {
        return levelIndex;
    }
}
