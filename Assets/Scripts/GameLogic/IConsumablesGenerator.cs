using System.Collections.Generic;

namespace Snake.GameLogic
{
    public interface IConsumablesGenerator
    {
        public List<IConsumable> Consumables { get; }
        public IConsumable GetConsumable();
    }
}