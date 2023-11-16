using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public class Grid
    {
        private readonly int _totalRows, _totalColumns;
        private readonly List<Cell> _cells = new();

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
    }
}