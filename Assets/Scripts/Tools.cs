using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static Vector3 ConvertGridToWord(GridVector gridVector)
    {
        Vector3 xy = new Vector3(gridVector.Col, -gridVector.Row);
        return xy;
    }

    public static Vector3 ConvertGridToWord(float row, float col)
    {
        Vector3 xy = new Vector3(col, -row);
        return xy;
    }

    public static Vector3 ConvertGridToWord(float row, float col, float depth)
    {
        Vector3 xyz = new Vector3(col, -row, depth);
        return xyz;
    }

    public static GridVector ConvertWordToGrid(float x, float y)
    {
        GridVector xy = new GridVector((int)-y, (int)x);
        return xy;
    }

    public static GridVector ConvertWordToGrid(Vector3 pos)
    {
        GridVector xy = new GridVector((int)-pos.y, (int)pos.x);
        return xy;
    }

    public static int GetUnMarkedBlockCount(BlockControl[,] LevelMap)
    {
        int ObstacleCount = 0;

        int levelMapRows = LevelMap.GetLength(0);
        int LevelMapCols = LevelMap.GetLength(1);

        for (int row = 0; row < levelMapRows; row++)
        {
            for (int col = 0; col < LevelMapCols; col++)
            {
                if (LevelMap[row, col].blockType == BlockType.UnMarked)
                {
                    ObstacleCount++;
                }
            }
        }

        return ObstacleCount;
    }

    public static int GetMarkedBlockCount(BlockControl[,] LevelMap)
    {
        int ObstacleCount = 0;

        int levelMapRows = LevelMap.GetLength(0);
        int LevelMapCols = LevelMap.GetLength(1);

        for (int row = 0; row < levelMapRows; row++)
        {
            for (int col = 0; col < LevelMapCols; col++)
            {
                if (LevelMap[row, col].blockType == BlockType.Marked)
                {
                    ObstacleCount++;
                }
            }
        }

        return ObstacleCount;
    }
}

public struct GridVector
{
    public static GridVector zero = new GridVector(0, 0);
    public static GridVector one = new GridVector(1, 1);

    public static GridVector Right = new GridVector(0, 1);
    public static GridVector Left = new GridVector(0, -1);
    public static GridVector Up = new GridVector(-1, 0);
    public static GridVector Down = new GridVector(1, 0);

    public int Row;
    public int Col;

    public GridVector(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public static GridVector operator +(GridVector v1,
                                GridVector v2)
    {
        return new GridVector(v1.Row + v2.Row, v1.Col + v2.Col);
    }

    public static bool operator ==(GridVector v1,
                                   GridVector v2)
    {
        if (v1.Row == v2.Row && v1.Col == v2.Col)
            return true;
        else
            return false;
    }

    public static bool operator !=(GridVector v1,
                                   GridVector v2)
    {
        if (v1.Row == v2.Row && v1.Col == v2.Col)
            return false;
        else
            return true;
    }
}

public class Level
{
    private int[,] LevelMap;
    private Invader playerPos;

    public Level(int[,] map, Invader enemyPos)
    {
        LevelMap = (int[,])map.Clone();
        playerPos = enemyPos;
    }

    public int[,] GetLevelMap()
    {
        return LevelMap;
    }

    public int GetLevelRow()
    {
        return LevelMap.GetLength(0);
    }
    public int GetLevelCol()
    {
        return LevelMap.GetLength(1);
    }

    public Invader GetPlayer()
    {
        return playerPos;
    }

    public Level DeepCopy()
    {
        Level dLevel = new Level(LevelMap, playerPos);
        return dLevel;
    }

    public int GetObstacleBlockCount()
    {
        int ObstacleCount = 0;

        int levelMapRows = LevelMap.GetLength(0);
        int LevelMapCols = LevelMap.GetLength(1);

        for (int row = 0; row < levelMapRows; row++)
        {
            for (int col = 0; col < LevelMapCols; col++)
            {
                if (LevelMap[row, col] == 1)
                {
                    ObstacleCount++;
                }
            }
        }

        return ObstacleCount;
    }

    public int GetFreeBlockCount()
    {
        int ObstacleCount = 0;

        int levelMapRows = LevelMap.GetLength(0);
        int LevelMapCols = LevelMap.GetLength(1);

        for (int row = 0; row < levelMapRows; row++)
        {
            for (int col = 0; col < LevelMapCols; col++)
            {
                if (LevelMap[row, col] == 0)
                {
                    ObstacleCount++;
                }
            }
        }

        return ObstacleCount;
    }
}


public class Block
{
    public GridVector GridPos;
    public bool IsActive;

    public Block(GridVector gridPos)
    {
        GridPos = gridPos;
        IsActive = true;
    }
}

public class Invader
{
    public GridVector pos;

    public Invader(GridVector pos)
    {
        this.pos = pos;
    }

}
