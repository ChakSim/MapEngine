using System.Threading;

namespace MapEngine
{
    class MovementAnimator : IMovementAnimator
    {
        public void AnimateMovement(IRefreshCellContent refreshCellContent,IRenderCellContents render,
            IPlayer player,IPlayers players,  ICells cells, 
            ICellSearch cellSearch, IPositionCalculator positionCalculator,int step)
        {
            int fps = 1;

            for (int iteration = 0; iteration < step; iteration++)
            {
                cellSearch.SearchCells(cells, (Cell) =>
                {
                    if (Cell.Index == player.Chip.Index)
                    {
                        Cell.UnlocCell();
                        Cell.RecordCellText(" ");
                    }
                });

                string newIndex = positionCalculator.GetNewPosition(player.Chip.Index, fps);

                cellSearch.SearchCells(cells, (Cell) =>
                {
                    if (Cell.Index == newIndex)
                    {
                        Cell.LockCell(player.Chip.ID);
                        Cell.RecordCellText(player.Chip.Symbol.ToString());
                        player.Chip.SetIndexCell(newIndex);
                    }
                    else if(Cell.Index == "resault")
                    {
                        Cell.RecordCellText($"{player.Name} переходит на ячейку {player.Chip.Index}");
                    }
                });
                Thread.Sleep(150);
                render.RenderCell(players,cells,cellSearch, refreshCellContent);
            }
        }
    }
}