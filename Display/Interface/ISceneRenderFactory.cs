using MapEngine.Display;

namespace MapEngine
{
    interface ISceneRenderFactory
    {
        IMovementAnimator MovementAnimator { get; }

        IMapRender MapRender { get; }

        IRenderItem RenderItem { get; }

        IRenderCellContents SceneCellRender { get; }

        IRefreshCellContent RefreshCellContent { get; }
}
}
