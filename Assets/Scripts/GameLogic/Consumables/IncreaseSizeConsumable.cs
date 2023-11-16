using UnityEngine;

namespace Snake.GameLogic.Consumables
{
    public class IncreaseSizeConsumable : IConsumable
    {
        private Color _color = Color.green;
        public Color Color { get { return _color; } }

        public void ExecuteConsumableEffect(ISnakeEffects snakeEffects)
        {
            snakeEffects.IncreaseSize();
        }
    }
}