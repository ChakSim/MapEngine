using System;

namespace MapEngine.Display
{
    internal class RenderСellСontents : IRenderCellContents
    {
        public void RenderCell(IPlayers players,ICells cells,ICellSearch cellSearch,IRefreshCellContent refreshCell)
        {
            refreshCell.SynchronizeWithChips(players,cells,cellSearch);

            cellSearch.SearchCells(cells, (cell) => 
            {
                Console.SetCursorPosition(cell.CoordinatesY,cell.CoordinatesX);

                string content = cell.InputText;

                if (content != string.Empty)
                {
                    Console.Write(cell.InputText);
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            });
        }
    }
}