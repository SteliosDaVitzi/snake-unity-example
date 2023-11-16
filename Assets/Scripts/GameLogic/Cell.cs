using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Cell
    {
        private readonly int _row, _column;

        public int Row => _row;
        public int Column => _column;

        private SnakeSegment _snakeSegment;
        public SnakeSegment SnakeSegment { get { return _snakeSegment; } set { _snakeSegment = value; } }
        public bool HasSnakeSegment => _snakeSegment != null;

        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
        }
    }
}