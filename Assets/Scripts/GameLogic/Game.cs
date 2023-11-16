using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Game
    {
        private readonly Snake _snake;
        private readonly Grid _grid;

        public Grid Grid => _grid;
        public Snake Snake => _snake;

        public Game(int totalGridRows, int totalGridColumns, int snakeInitialSize, MoveDirection initialDirection)
        {
            _grid = new Grid(totalGridRows, totalGridColumns);
            _snake = new Snake(snakeInitialSize, _grid.GetCenterCell(), initialDirection, _grid);
        }
    }

    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
}