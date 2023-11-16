using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Snake
    {
        private readonly List<SnakeSegment> _segments = new();
        private readonly Grid _grid;

        private MoveDirection _currentDirection;

        public Snake(int initialSize, Cell initialCell, MoveDirection initialDirection, Grid grid)
        {
            _grid = grid;
            CreateSnake(initialSize, initialCell, initialDirection);
        }

        private void CreateSnake(int initialSize, Cell initialCell, MoveDirection initialDirection)
        {
            for (var i = 0; i < initialSize; i++)
            {
                switch (initialDirection)
                {
                    case MoveDirection.Up:
                            AddSegment(initialCell.Row - i, initialCell.Column);
                        break;
                    case MoveDirection.Down:
                            AddSegment(initialCell.Row + i, initialCell.Column);
                        break;
                    case MoveDirection.Left:
                            AddSegment(initialCell.Row, initialCell.Column + i);
                        break;
                    case MoveDirection.Right:
                            AddSegment(initialCell.Row, initialCell.Column - i);
                        break;
                }
            }
        }

        private void AddSegment(int row, int column)
        {
            var newSegment = new SnakeSegment(row, column);
            _segments.Add(newSegment);
            _grid.GetCellByCoordinates(row, column).SnakeSegment = newSegment;
        }

        public void ChangeDirection(MoveDirection newDirection)
        {
            if (newDirection == _currentDirection || newDirection == MoveDirection.None)
                return;

            if (_currentDirection == MoveDirection.Up && newDirection == MoveDirection.Down)
                return;

            if (_currentDirection == MoveDirection.Down && newDirection == MoveDirection.Up)
                return;

            if (_currentDirection == MoveDirection.Left && newDirection == MoveDirection.Right)
                return;

            if (_currentDirection == MoveDirection.Right && newDirection == MoveDirection.Left)
                return;

            _currentDirection = newDirection;
        }

        public void Move()
        {
            for (var i = 0; i < _segments.Count; i++)
            {
                if (i == 0)
                    _segments[i].UpdatePosition(true, _currentDirection, _grid);
                else
                    _segments[i].UpdatePosition(false, _currentDirection, _grid, _segments[i - 1]);
            }
        }
    }
}