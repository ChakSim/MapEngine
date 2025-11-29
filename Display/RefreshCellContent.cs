using System.Collections.Generic;

namespace MapEngine.Display
{
    class RefreshCellContent : IRefreshCellContent
    {
        public void SynchronizeWithChips(IPlayers players, ICells cells, ICellSearch cellSearch)
        {
            foreach (Player player in players.Players)
            {
                cellSearch.SearchCells(cells, (cell) =>
                {
                    if (player.Chip.Index == cell.Index)
                    {
                        cell.RecordCellText(player.Chip.Symbol.ToString());
                        cell.LockCell(player.Chip.ID);
                    }
                });
            }
        }
    }
}
