using System;

namespace MapEngine
{
    internal class CellSearch:ICellSearch
    {
        public void SearchCells(ICells cells, Action<ICell> action)
        {
            foreach (ICell cell in cells.GetCells())
            {
                action(cell);
            }
        }
    }
}