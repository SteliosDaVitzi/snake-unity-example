using UnityEngine;

namespace Snake.GameLogic.Consumables
{
    public class RevertSnakeConsumable : IConsumable
    {
        private Color _color = Color.cyan;
        public Color Color { get { return _color; } }

        public void ExecuteConsumableEffect(ISnakeEffects snakeEffects)
        {
            snakeEffects.Revert();
        }
    }
}