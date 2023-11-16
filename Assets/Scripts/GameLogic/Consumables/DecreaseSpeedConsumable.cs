using UnityEngine;

namespace Snake.GameLogic.Consumables
{
    public class DecreaseSpeedConsumable : IConsumable
    {
        private Color _color = Color.gray;
        public Color Color { get { return _color; } }

        public void ExecuteConsumableEffect(ISnakeEffects snakeEffects)
        {
            snakeEffects.DecreaseSpeed();
        }
    }
}