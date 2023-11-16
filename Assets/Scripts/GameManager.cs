using Snake.GameLogic;
using Snake.GameLogic.Consumables;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIView _uiView;

    [SerializeField] private GridView _gridViewPrefab;
    private GridView _gridViewInstance;

    private Game _game;
    private float _timer = 0f;
    private float _speedEffectTimer = 0;

    private GameState _gameState => _game.CurrentState;

    private IInputControl _inputControl;
    private IConsumablesGenerator _consumablesGenerator;

    void Start()
    {
        _inputControl = new KeyboardInputControl();
        _consumablesGenerator = new RandomConsumablesGenerator();

        _consumablesGenerator.Consumables.Add(new IncreaseSizeConsumable());
        _consumablesGenerator.Consumables.Add(new DecreaseSizeConsumable());
        _consumablesGenerator.Consumables.Add(new IncreaseSpeedConsumable());
        _consumablesGenerator.Consumables.Add(new DecreaseSpeedConsumable());
        _consumablesGenerator.Consumables.Add(new RevertSnakeConsumable());

        NewGame();
    }

    private void NewGame()
    {
        UpdateScore(0);

        var snakeConfig = new SnakeConfig
        {
            initialSize = 3,
            initialDirection = MoveDirection.Up,
            normalSpeed = 0.2f,
            slowSpeed = 0.7f,
            fastSpeed = 0.05f,
            speedEffectDuration = 4.0f
        };

        _game = new Game(21, 21, snakeConfig, _consumablesGenerator);

        CreateGridView();

        _game.Snake.OnSelfCollision += RestartGame;
        _game.Snake.OnEatenConsumable += UpdateScore;
    }

    private void RestartGame()
    {
        DestroyGridView();
        NewGame();
    }

    private void CreateGridView()
    {
        _gridViewInstance = Instantiate(_gridViewPrefab);
        _gridViewInstance.Setup(_game.Grid);
    }

    private void DestroyGridView()
    {
        Destroy(_gridViewInstance.gameObject);
    }


    void Update()
    {
        if (_gameState != GameState.InProgress)
            return;

        ControlDirection();
        SpeedEffectCountdown();
        UpdateSnakeMovement();
    }

    private void ControlDirection()
    {
        _game.Snake.ChangeDirection(_inputControl.GetMoveDirectionInput());
    }

    private void UpdateSnakeMovement()
    {
        _timer += Time.deltaTime;

        if (_timer >= _game.Snake.CurrentSpeed)
        {
            MoveSnake();
            _timer = 0f;
        }
    }

    private void MoveSnake()
    {
        _game.Snake.Move();
        _gridViewInstance.UpdateCellsColors();
    }

    private void SpeedEffectCountdown()
    {
        if (_game.Snake.HasSpeedEffect)
        {
            _speedEffectTimer += Time.deltaTime;
            if (_speedEffectTimer >= _game.Snake.SpeedEffectDuration)
            {
                _game.Snake.SetNormalSpeed();
                _game.Snake.HasSpeedEffect = false;
                _speedEffectTimer = 0;
            }
        }
    }

    private void UpdateScore(int score)
    {
        _uiView.UpdateScore(score);
    }
}
