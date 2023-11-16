using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Snake : ISnakeEffects
    {
        private readonly List<SnakeSegment> _segments = new();
        private readonly Grid _grid;

        private MoveDirection _currentDirection;

        public Action OnSpeedUp;
        public Action OnSlowDown;

        private float _currentSpeed = 0.0f;
        public float CurrentSpeed => _currentSpeed;

        private bool _hasSpeedEffect;
        public bool HasSpeedEffect {  get { return _hasSpeedEffect; } set { _hasSpeedEffect = value; } }

        public float SpeedEffectDuration => _config.speedEffectDuration;

        private SnakeConfig _config;

        public Action OnSelfCollision;

        public Action<int> OnEatenConsumable;

        private int _score;
        public int Score => _score;

        public Snake(SnakeConfig config, Grid grid)
        {
            _grid = grid;
            _config = config;  
            CreateSnake();
        }

        private void CreateSnake()
        {
            var initialCell = _grid.GetCenterCell();

            _currentSpeed = _config.normalSpeed;

            ChangeDirection(_config.initialDirection);

            for (var i = 0; i < _config.initialSize; i++)
            {
                switch (_currentDirection)
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

            var targetCell = _grid.GetCellByCoordinates(row, column);

            if (targetCell == null)
                return;

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

            var snakeHead = _segments.First();
            var targetCell = _grid.GetCellByCoordinates(snakeHead.CurrentRow, snakeHead.CurrentColumn);

            if (targetCell.HasConsumable)
                EatConsumable(targetCell);

            if (targetCell.SnakeSegment != snakeHead && targetCell.HasSnakeSegment)
                OnSelfCollision?.Invoke();
        }

        private void EatConsumable(Cell targetCell)
        {
            targetCell.Consumable.ExecuteConsumableEffect(this);

            targetCell.EatConsumable();

            ++_score;
            OnEatenConsumable?.Invoke(_score);

            _grid.SpawnConsumable();
        }

        public void SetNormalSpeed()
        {
            _currentSpeed = _config.normalSpeed;
        }

        public void IncreaseSize()
        {
            var lastSegment = _segments.Last();
            _segments.Add(new SnakeSegment(lastSegment.PreviousRow, lastSegment.PreviousColumn));
        }

        public void DecreaseSize()
        {
            if (_segments.Count <= 1)
                return;

            var lastSegment = _segments.Last();
            lastSegment.RemoveSegment(_grid);
            _segments.Remove(_segments.Last());
        }

        public void IncreaseSpeed()
        {
            _hasSpeedEffect = true;
            _currentSpeed = _config.fastSpeed;
        }

        public void DecreaseSpeed()
        {
            _hasSpeedEffect = true;
            _currentSpeed = _config.slowSpeed;
        }

        public void Revert()
        {
            _segments.Reverse();
            if (_currentDirection == MoveDirection.Up)
                _currentDirection = MoveDirection.Down;
            else if (_currentDirection == MoveDirection.Down)
                _currentDirection = MoveDirection.Up;
            else if (_currentDirection == MoveDirection.Left)
                _currentDirection = MoveDirection.Right;
            else if (_currentDirection == MoveDirection.Right)
                _currentDirection = MoveDirection.Left;
        }
    }

    public struct SnakeConfig
    {
        public int initialSize;
        public MoveDirection initialDirection;
        public float normalSpeed;
        public float slowSpeed;
        public float fastSpeed;
        public float speedEffectDuration;
    }
}