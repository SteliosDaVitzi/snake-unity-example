using UnityEngine;

namespace Snake.GameLogic.Consumables
{
    public class DecreaseSizeConsumable : IConsumable
    {
        private Color _color = Color.red;
        public Color Color { get { return _color; } }

        public void ExecuteConsumableEffect(ISnakeEffects snakeEffects)
        {
            snakeEffects.DecreaseSize();
        }
    }
}