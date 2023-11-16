using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Snake
    {
        private readonly int _initialSize;
        private readonly List<SnakeSegment> _segments = new();

        public Snake(int initialSize)
        {
            _initialSize = initialSize;
        }
    }
}