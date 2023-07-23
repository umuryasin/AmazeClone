using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InputState
{
    Right,
    Left,
    Up,
    Down,
};

class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance => _instance ?? (_instance = FindObjectOfType<InputManager>());

    private Vector3 _initMousePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 diffPos = currentMousePos - _initMousePos;
            float deltaX = diffPos.x;
            float deltaY = diffPos.y;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    EventManager.OnInputChanged(InputState.Right);
                }
                else
                {
                    EventManager.OnInputChanged(InputState.Left);
                }
            }
            else
            {
                if (deltaY > 0)
                {
                    EventManager.OnInputChanged(InputState.Up);
                }
                else
                {
                    EventManager.OnInputChanged(InputState.Down);
                }
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
    }

}
