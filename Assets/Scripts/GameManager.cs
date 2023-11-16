using Snake.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridView _gridViewPrefab;
    private GridView _gridView;

    private Game _game;

    private float _currentSpeed = 0.2f;
    private float _timer = 0f;

    private IInputControl _inputControl;

    void Start()
    {
        _inputControl = new KeyboardInputControl();

        NewGame();
    }

    private void NewGame()
    {
        _game = new Game(21, 21, 3, MoveDirection.Up);
        CreateGridView();
    }

    private void RestartGame()
    {
        DestroyGridView();
        NewGame();
    }

    private void CreateGridView()
    {
        _gridView = Instantiate(_gridViewPrefab);
        _gridView.Setup(_game.Grid);
    }

    private void DestroyGridView()
    {
        Destroy(_gridView.gameObject);
    }


    void Update()
    {
        ControlDirection();
        UpdateSnakeMovement();
    }

    private void ControlDirection()
    {
        _game.Snake.ChangeDirection(_inputControl.GetMoveDirectionInput());
    }

    private void UpdateSnakeMovement()
    {
        _timer += Time.deltaTime;

        if (_timer >= _currentSpeed)
        {
            MoveSnake();
            _timer = 0f;
        }
    }

    private void MoveSnake()
    {
        _game.Snake.Move();
        _gridView.UpdateCellsColors();
    }
}
