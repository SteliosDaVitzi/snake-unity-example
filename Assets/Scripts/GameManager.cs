using Snake.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Game _game;

    void Start()
    {
        NewGame();
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        _game = new Game(21, 21, 3, MoveDirection.Up);
    }
}
