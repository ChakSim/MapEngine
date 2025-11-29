namespace MapEngine
{
    class GameFactoryData : IGameFactoryData
    {
        private Dice _dice;
        private Players _players;
        private MapBuilder _mapBulder;
        private ICells _cells;
        private IMap _map;
        private SceneRenderFactory _render;
        private CellSearch _cellSearch;
        private PositionService _positionService;
        private CreatePlayer _createPlayers;
        private ProcessTurn _turn;
        private PositionCalculator _positionCalculator;

        public GameFactoryData()
        {
            _dice = new Dice();
            _mapBulder = EngineFactory.CreateMapBuilder("map.txt");
            _cells = _mapBulder;
            _map = _mapBulder;
            _cellSearch = new CellSearch();
            _positionService = new PositionService(_cells, _cellSearch);
            _render = new SceneRenderFactory(_positionService);
            _createPlayers = new CreatePlayer();
            _players = new Players(_createPlayers,_cells,_cellSearch);
            _turn = new ProcessTurn();
            _positionCalculator = new PositionCalculator();
        }

        public IDice Dice => _dice;

        public IPlayers Players => _players;

        public ICells Cells => _cells;

        public IMap Map => _map;

        public ICellSearch CellSearch => _cellSearch;

        public ICreatePlayer CreatePlayers => _createPlayers;

        public ISceneRenderFactory Render => _render;

        public IProcessTurn ProcessTurn => _turn;

        public IPositionCalculator PositionCalculator => _positionCalculator;
    }
}
