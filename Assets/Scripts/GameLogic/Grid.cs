using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Grid
    {
        private readonly int _totalRows, _totalColumns;
        private readonly List<Cell> _cells = new();

        public List<Cell> Cells => _cells;
        public int TotalRows => _totalRows;
        public int TotalColumns => _totalColumns;

        public Grid(int totalRows, int totalColumns)
        {
            _totalRows = totalRows;
            _totalColumns = totalColumns;

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for(var i =0;i < _totalRows;i++)
                for(var j =0;j < _totalColumns; j++)
                    _cells.Add(new Cell(i,j));
        }

        public Cell GetCenterCell()
        {
            return GetCellByCoordinates(_totalRows / 2, _totalColumns / 2);
        }

        public Cell GetCellByCoordinates(int row, int col)
        {
            return _cells.Find(cell => cell.Row == row && cell.Column == col);
        }
    }
}