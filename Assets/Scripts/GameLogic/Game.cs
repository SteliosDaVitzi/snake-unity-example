namespace Snake.GameLogic
{
    public class Game
    {
        private readonly Snake _snake;
        private readonly Grid _grid;

        public Grid Grid => _grid;
        public Snake Snake => _snake;

        private GameState _currentState;
        public GameState CurrentState => _currentState;

        public Game(int totalGridRows, int totalGridColumns, SnakeConfig snakeConfig, IConsumablesGenerator consumablesGenerator)
        {
            _grid = new Grid(totalGridRows, totalGridColumns, consumablesGenerator);
            _snake = new Snake(snakeConfig, _grid);

            _currentState = GameState.InProgress;
        }
    }

    public enum MoveDirection
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    public enum GameState
    {
        NotStarted,
        InProgress
    }
}