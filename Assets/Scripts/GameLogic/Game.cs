using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Game
    {
        private readonly Snake _snake;
        private readonly Grid _grid;

        public Game(int totalRows, int totalColumns, int snakeInitialSize)
        {
            _grid = new Grid(totalRows, totalColumns);
            _snake = new Snake(snakeInitialSize);
        }
    }
}