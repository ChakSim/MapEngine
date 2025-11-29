using System.Collections.Generic;

namespace MapEngine
{
    interface IRefreshCellContent
    {
        void SynchronizeWithChips(IPlayers players,ICells cells,ICellSearch cellSearch);
    }
}
