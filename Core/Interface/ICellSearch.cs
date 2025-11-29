using System;

namespace MapEngine
{
    interface ICellSearch
    {
        void SearchCells(ICells cells, Action<ICell> action);
    }
}
