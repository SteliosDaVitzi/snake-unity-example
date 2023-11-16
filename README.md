# Snake-Unity

This is an example of the classic snake game, mad in Unity3D

Unity version : 2022.3.7f1

Gameplay features:
- Through the arrows on the keyboard, you can change the snake direction.
- If the snake hits a wall, it continues it's path through the opposite wall.
- There are random spawned consumables throught the game. 
Each time you eat one, another one spawns and you gain 1 score point.

Available consumables:
- Increase snake size (green)
- Decrease snake size (red)
- Speed up the snake (blue)
- Slow down the snake (grey)
- Revert snake's head/tail and direction (cyan)

The code contains:
- A GameManager scrpt that handles the new game, game restart, and update functionalities.
- An IInputControl interface that can be implemented to include different types of controls.
- An IConsumablesGenerator interface that can be implemented to control how the consumables are spawned. For now only a RandomConsumablesGenerator class implements it.
- An IConsumable interface that can be implemented to include a lot of different types of consumables.
- An ISnakeEffects interface, to include the methods that execute upon consumable trigger. Only usable by Consumables.