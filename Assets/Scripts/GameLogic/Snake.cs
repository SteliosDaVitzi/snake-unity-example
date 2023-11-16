using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Snake
    {
        private readonly List<SnakeSegment> _segments = new();
        private readonly Grid _grid;

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
                            CreateSegment(initialCell.Row - i, initialCell.Column);
                        break;
                    case MoveDirection.Down:
                            CreateSegment(initialCell.Row + i, initialCell.Column);
                        break;
                    case MoveDirection.Left:
                            CreateSegment(initialCell.Row, initialCell.Column + i);
                        break;
                    case MoveDirection.Right:
                            CreateSegment(initialCell.Row, initialCell.Column - i);
                        break;
                }
            }
        }

        private void CreateSegment(int row, int column)
        {
            var snakeSegment = new SnakeSegment(row, column);
            _segments.Add(snakeSegment);
            _grid.GetCellByCoordinates(row, column).SnakeSegment = snakeSegment;
        }
    }
}