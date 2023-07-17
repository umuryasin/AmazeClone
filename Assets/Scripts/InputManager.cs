using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputState
{
    Right,
    Left,
    Up,
    Down,
};

class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance => instance ?? (instance = FindObjectOfType<InputManager>());

    private Vector3 initMousePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 diffPos = currentMousePos - initMousePos;
            float deltaX = diffPos.x;
            float deltaY = diffPos.y;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    Debug.Log("right");
                    EventManager.OnInputChanged(InputState.Right);
                }
                else
                {
                    Debug.Log("left");
                    EventManager.OnInputChanged(InputState.Left);
                }
            }
            else
            {
                if (deltaY > 0)
                {
                    Debug.Log("up");
                    EventManager.OnInputChanged(InputState.Up);
                }
                else
                {
                    Debug.Log("down");
                    EventManager.OnInputChanged(InputState.Down);
                }
            }
        
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
    }

}
