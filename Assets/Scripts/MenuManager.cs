using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas winMenu;

    [SerializeField] private CanvasGroup effectMenu;

    [SerializeField] private TextMeshProUGUI txtLevelGame;

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
        if (GameState == GameStates.Started)
        {
            StartGame();
        }
        else if (GameState == GameStates.RestartGame)
        {
            RestartGame();
        }
        else if (GameState == GameStates.WinGame)
        {
            WinGameMenu();
        }
        else if (GameState == GameStates.LoadLevel)
        {
            StartGame();
            int levelIndex = LevelManager.Instance.GetLevelIndex() + 1;
            txtLevelGame.text = "Level " + levelIndex.ToString();
        }
    }

    private void StartGame()
    {
        winMenu.gameObject.SetActive(false);
        StartFadeOutEffect();

    }

    private void StartFadeOutEffect()
    {
        effectMenu.alpha = 0.75f;
        effectMenu.gameObject.SetActive(true);
        effectMenu.DOFade(0, 0.5f).OnComplete(() => effectMenu.gameObject.SetActive(false));
    }

    private void RestartGame()
    {
    }

    private void WinGameMenu()
    {
        winMenu.gameObject.SetActive(true);
    }
}
