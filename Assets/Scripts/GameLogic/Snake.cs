using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Snake
    {
        private readonly List<SnakeSegment> _segments = new();

        public Snake(int initialSize, Cell initialCell, MoveDirection initialDirection)
        {
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
            _segments.Add(new SnakeSegment(row, column));
        }
    }
}