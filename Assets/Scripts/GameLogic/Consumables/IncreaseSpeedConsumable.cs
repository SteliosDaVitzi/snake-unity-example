using UnityEngine;

namespace Snake.GameLogic.Consumables
{
    public class IncreaseSpeedConsumable : IConsumable
    {
        private Color _color = Color.blue;
        public Color Color { get { return _color; } }

        public void ExecuteConsumableEffect(ISnakeEffects snakeEffects)
        {
            snakeEffects.IncreaseSpeed();
        }
    }
}