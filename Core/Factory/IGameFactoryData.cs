namespace MapEngine
{
    interface IGameFactoryData
    {
        IDice Dice { get; }

        IPlayers Players { get; }

        ICells Cells { get; }

        IMap Map { get; }

        ICellSearch CellSearch { get; }

        ICreatePlayer CreatePlayers { get; }

        ISceneRenderFactory Render { get; }

        IProcessTurn ProcessTurn { get; }

        IPositionCalculator PositionCalculator { get; }
    }
}
