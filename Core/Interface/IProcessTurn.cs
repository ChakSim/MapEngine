namespace MapEngine
{
    internal interface IProcessTurn
    {
        void Update(IRefreshCellContent refreshCellContent, IRenderCellContents content, IDice dice, IPlayer player, IPlayers players, IPositionCalculator positionCalculator, ICells cells, ICellSearch cellSearch, IMovementAnimator animator);
    }
}
