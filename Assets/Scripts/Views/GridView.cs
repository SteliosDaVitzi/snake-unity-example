using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.GameLogic;

public class GridView : MonoBehaviour
{
    [SerializeField] private CellView cellViewPrefab;

    private readonly List<CellView> cellViews = new();

    public void Setup(Snake.GameLogic.Grid grid)
    {
        cellViews.Clear();
        GenerateGrid(grid);
    }

    private void GenerateGrid(Snake.GameLogic.Grid grid)
    {
        var sr = cellViewPrefab.GetComponent<SpriteRenderer>();
        var ratio = sr.sprite.pixelsPerUnit / sr.sprite.rect.width;

        foreach (var cell in grid.Cells)
        {
            var cellPos = new Vector3(cell.Column/ ratio - (grid.TotalColumns / 2)/ratio, cell.Row/ratio - (grid.TotalRows / 2)/ratio, 0);
            var cellView = Instantiate(cellViewPrefab, cellPos, Quaternion.identity);
            cellView.transform.SetParent(transform, false);
            cellView.Setup(cell);
            cellViews.Add(cellView);
        }
    }

    public void UpdateCellsColors()
    {
        foreach(var cell in cellViews)
            cell.UpdateColor();
    }
}
