using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Cell
    {
        private readonly int _row, _column;

        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
        }
    }
}