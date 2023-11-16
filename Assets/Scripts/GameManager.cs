using Snake.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridView _gridViewPrefab;
    private GridView _gridView;

    private Game _game;

    void Start()
    {
        NewGame();
    }

    void Update()
    {
        _gridView.UpdateCellsColors();
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
}
