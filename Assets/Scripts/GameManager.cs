using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStates
{
    Initilazed,
    Started,
    Finished,
    Paused,
    EndGameStarted,
    EndGameFinished,
    RestartGame,
    ScoreUp,
    LoseGame,
    WinGame,
    LoadLevel,
    LevelLoaded,
};

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance => instance ?? (instance = FindObjectOfType<GameManager>());

    void Awake()
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
    }


    public void StartGame()
    {
        EventManager.UpdateGameState(GameStates.Started);
    }

    public void WinGame()
    {
        EventManager.UpdateGameState(GameStates.WinGame);
    }

    public void LoseGame()
    {
        EventManager.UpdateGameState(GameStates.LoseGame);
    }

    public void RestartGame()
    {
        EventManager.UpdateGameState(GameStates.RestartGame);
    }

    public void LoadLevel()
    {
        EventManager.UpdateGameState(GameStates.LoadLevel);
    }

    public void LevelLoaded()
    {
        EventManager.UpdateGameState(GameStates.LevelLoaded);
    }

    public void ScoreUp()
    {
        EventManager.UpdateGameState(GameStates.ScoreUp);
    }
}
