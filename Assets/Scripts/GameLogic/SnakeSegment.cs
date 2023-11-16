using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class SnakeSegment
    {
        private int _currentRow, _currentColumn, _previousRow, _previousColumn;

        public int CurrentRow => _currentRow;
        public int CurrentColumn => _currentColumn;

        public int PreviousRow => _previousRow;
        public int PreviousColumn => _previousColumn;

        public SnakeSegment(int row, int column)
        {
            _currentRow = row;
            _currentColumn = column;
            _previousRow = row;
            _previousColumn = column;
        }

        public void UpdatePosition(bool isHead, MoveDirection moveDirection, Grid grid, SnakeSegment nextSegment = null)
        {
            _previousRow = _currentRow;
            _previousColumn = _currentColumn;

            if (isHead)
            {
                switch (moveDirection)
                {
                    case MoveDirection.Up:
                        if (_currentRow + 1 < grid.TotalRows)
                            _currentRow++;
                        else
                            _currentRow = 0;
                        break;
                    case MoveDirection.Down:
                        if (_currentRow - 1 >= 0)
                            _currentRow--;
                        else
                            _currentRow = grid.TotalRows - 1;
                        break;
                    case MoveDirection.Left:
                        if (_currentColumn - 1 >= 0)
                            _currentColumn--;
                        else
                            _currentColumn = grid.TotalColumns - 1;
                        break;
                    case MoveDirection.Right:
                        if (_currentColumn + 1 < grid.TotalColumns)
                            _currentColumn++;
                        else
                            _currentColumn = 0;
                        break;
                }
                UpdateGridSnakeSegment(grid);
                return;
            }

            if (nextSegment == null)
                return;

            _currentRow = nextSegment.PreviousRow;
            _currentColumn = nextSegment.PreviousColumn;

            UpdateGridSnakeSegment(grid);
        }

        private void UpdateGridSnakeSegment(Grid grid)
        {
            grid.GetCellByCoordinates(_currentRow, _currentColumn).SnakeSegment = this;
            grid.GetCellByCoordinates(PreviousRow, PreviousColumn).SnakeSegment = null;
        }

        public void RemoveSegment(Grid grid)
        {
            grid.GetCellByCoordinates(_currentRow, _currentColumn).SnakeSegment = null;
            grid.GetCellByCoordinates(PreviousRow, PreviousColumn).SnakeSegment = null;
        }
    }
}