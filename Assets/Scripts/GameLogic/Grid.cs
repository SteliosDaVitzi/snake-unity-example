using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Grid
    {
        private readonly int _totalRows, _totalColumns;
        private readonly List<Cell> _cells = new();
        private readonly IConsumablesGenerator _consumablesGenerator;

        public List<Cell> Cells => _cells;
        public int TotalRows => _totalRows;
        public int TotalColumns => _totalColumns;

        public Grid(int totalRows, int totalColumns, IConsumablesGenerator consumablesGenerator)
        {
            _totalRows = totalRows;
            _totalColumns = totalColumns;

            _consumablesGenerator = consumablesGenerator;

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for(var i =0;i < _totalRows;i++)
                for(var j =0;j < _totalColumns; j++)
                    _cells.Add(new Cell(i,j));

            SpawnConsumable();
        }

        public Cell GetCenterCell()
        {
            return GetCellByCoordinates(_totalRows / 2, _totalColumns / 2);
        }

        public Cell GetCellByCoordinates(int row, int col)
        {
            return _cells.Find(cell => cell.Row == row && cell.Column == col);
        }

        public void SpawnConsumable()
        {
            var availableCells = _cells.FindAll(cell => cell.HasConsumable == false && cell.HasSnakeSegment == false);
            var randomInt = Random.Range(0, availableCells.Count - 1);

            availableCells[randomInt].Consumable = _consumablesGenerator.GetConsumable();
        }
    }
}