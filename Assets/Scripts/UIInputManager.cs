using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("starttttt");
        GameManager.Instance.StartGame();
    }

    public void ResetGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void NextLevel()
    {
        GameManager.Instance.LoadLevel();
    }
}
