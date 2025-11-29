using System.Collections.Generic;

namespace MapEngine
{
    internal interface IRenderCellContents
    {
        void RenderCell(IPlayers players, ICells cells, ICellSearch cellSearch, IRefreshCellContent refreshCell);
    }
}