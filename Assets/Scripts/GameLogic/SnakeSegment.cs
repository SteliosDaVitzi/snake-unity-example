using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class SnakeSegment
    {
        private int _currentRow, _currentColumn;

        public SnakeSegment(int row, int column)
        {
            _currentRow = row;
            _currentColumn = column;
        }
    }
}