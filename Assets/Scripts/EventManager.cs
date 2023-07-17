using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EventManager : MonoBehaviour
{

    public static event Action<GameStates> onGameStateChanged;
    public static event Action<InputState> onInputChanged;

    public static void UpdateGameState(GameStates newState)
    {
        Debug.Log(" gameState = " + newState.ToString());
        onGameStateChanged?.Invoke(newState);
    }

    public static void OnInputChanged(InputState newState)
    {
        onInputChanged?.Invoke(newState);
    }


}
