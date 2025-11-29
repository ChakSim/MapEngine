using System.Collections.Generic;

namespace MapEngine
{
    class Players:IPlayers
    {
        private List<Player> _players;

        public Players(ICreatePlayer createPlayer,ICells cell, ICellSearch cellSearch)
        {
            _players = new List<Player>();

            CreatePlayerList(createPlayer,cell,cellSearch);
        }

        List<Player> IPlayers.Players => _players;

        private void CreatePlayerList(ICreatePlayer createPlayer,ICells cells, ICellSearch cellSearch)
        {
            string indexNameCell = string.Empty;
            string indexCharPlayerCell = string.Empty;
            string namePlayer = string.Empty;

            for (int x = 1; x < 5; x++)
            {
                indexNameCell = $"P{x}.Name";
                indexCharPlayerCell = $"P{x}";
                namePlayer = $"Игрок{x}";

                _players.Add(createPlayer.CreateNewPlayer(namePlayer,indexCharPlayerCell));

                cellSearch.SearchCells(cells, (cell) =>
                {
                    if (cell.Index == indexNameCell)
                    {
                        cell.RecordCellText(namePlayer);
                    }

                    if (cell.Index == indexCharPlayerCell)
                    {
                        cell.LockCell(_players[x - 1].Chip.ID);
                        cell.RecordCellText(_players[x - 1].Chip.Symbol.ToString().PadRight(cell.MaxLengthTextContent));
                    }

                });
            }
        }
    }
}
