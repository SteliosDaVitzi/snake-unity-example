using Snake.GameLogic;
using System.Collections.Generic;

public class RandomConsumablesGenerator : IConsumablesGenerator
{
    public List<IConsumable> Consumables { get; }

    public RandomConsumablesGenerator()
    {
        Consumables = new();
    }

    public IConsumable GetConsumable()
    {
        return Consumables[UnityEngine.Random.Range(0, Consumables.Count)];
    }
}