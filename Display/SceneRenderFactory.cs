using MapEngine.Display;

namespace MapEngine
{
    class SceneRenderFactory:ISceneRenderFactory
    {
        private ItemRender _itemRender;
        private MovementAnimator _movementAnimator;
        private MapRender _mapRender;
        private RenderСellСontents _sceneCellRender;
        private RefreshCellContent _refreshCellContent;

        public SceneRenderFactory(IPositionService positionService)
        {
            _itemRender = new ItemRender(positionService);
            _movementAnimator = new MovementAnimator();
            _mapRender = new MapRender();
            _sceneCellRender = new RenderСellСontents();
            _refreshCellContent = new RefreshCellContent();
        }

        public IMovementAnimator MovementAnimator => _movementAnimator;
        
        public IMapRender MapRender => _mapRender;

        public IRenderItem RenderItem => _itemRender;

        public IRenderCellContents SceneCellRender => _sceneCellRender;

        public IRefreshCellContent RefreshCellContent => _refreshCellContent;
    }
}
