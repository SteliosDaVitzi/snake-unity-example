using Snake.GameLogic;
using UnityEngine;

public class KeyboardInputControl : IInputControl
{
    public MoveDirection GetMoveDirectionInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return MoveDirection.Up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            return MoveDirection.Down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            return MoveDirection.Left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            return MoveDirection.Right;

        return MoveDirection.None;
    }
}