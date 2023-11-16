using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public interface IConsumable
    {
        public Color Color { get; }

        public void ExecuteConsumableEffect(ISnakeEffects snake);
    }
}