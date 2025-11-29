using System;
using System.Threading;

namespace MapEngine
{
    class GameLogic : IGameLogic
    {
        private int _currentPlayerIndex = 0;

        private IGameFactoryData _gameFactoryData;

        private ConsoleKey _imputPlayer = ConsoleKey.R;

        public GameLogic(IGameFactoryData gameFactoryData)
        {
            _gameFactoryData = gameFactoryData;

            _gameFactoryData.CellSearch.SearchCells(_gameFactoryData.Cells, (cell) =>
            {
                if (cell.Index == "info")
                {
                    cell.RecordCellText($"Нажмите {ConsoleKey.R} для того чтоб бросить кубик");
                }
            });
        }


        public void Run()
        {
            _gameFactoryData.Render.MapRender.DrawMap(_gameFactoryData.Map);

            while (true)
            {
                Console.CursorVisible = false;

                _gameFactoryData.Render.SceneCellRender.RenderCell(_gameFactoryData.Players,
                    _gameFactoryData.Cells,
                    _gameFactoryData.CellSearch,
                    _gameFactoryData.Render.RefreshCellContent);

                Update();


                Console.SetCursorPosition(0, 0);

            }
        }

        private void Update()
        {
            bool isWork = true;

            Player currentPlayer = _gameFactoryData.Players.Players[_currentPlayerIndex];

            while (isWork)
            {
                if (Console.ReadKey(true).Key == _imputPlayer)
                {
                    _gameFactoryData.ProcessTurn.Update(
                        _gameFactoryData.Render.RefreshCellContent,
                        _gameFactoryData.Render.SceneCellRender,
                        _gameFactoryData.Dice,
                        currentPlayer,
                        _gameFactoryData.Players,
                        _gameFactoryData.PositionCalculator,
                        _gameFactoryData.Cells,
                        _gameFactoryData.CellSearch,
                        _gameFactoryData.Render.MovementAnimator);
                    isWork = false;
                }
            }
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _gameFactoryData.Players.Players.Count;
        }
    }
}