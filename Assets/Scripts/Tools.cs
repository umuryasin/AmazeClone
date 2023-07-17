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
}

public struct GridVector
{
    public int Row;
    public int Col;

    public GridVector(int row, int col)
    {
        Row = row;
        Col = col;
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
