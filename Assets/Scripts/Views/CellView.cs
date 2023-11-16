using Snake.GameLogic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _snakeSegmentColor;

    private Cell _cell;

    public void Setup(Cell cell)
    {
        SetDefaultColor();
        _cell = cell;
    }

    public void UpdateColor()
    {
        if (_cell.HasSnakeSegment)
            SetSnakeSegmentColor();
        else if (_cell.HasConsumable)
            SetConsumableColor();
        else
            SetDefaultColor();
    }

    public void SetDefaultColor()
    {
        SetColorToSpriteRenderer(_defaultColor);
    }

    public void SetSnakeSegmentColor()
    {
        SetColorToSpriteRenderer(_snakeSegmentColor);
    }

    public void SetConsumableColor()
    {
        SetColorToSpriteRenderer(_cell.Consumable.Color);
    }

    private void SetColorToSpriteRenderer(Color color)
    {
        _spriteRenderer.color = color;
    }
}
