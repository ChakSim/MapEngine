namespace MapEngine
{
    interface IMovementAnimator
    {
        void AnimateMovement(IRefreshCellContent refreshCellContent, IRenderCellContents render,
            IPlayer player, IPlayers players, ICells cells,
            ICellSearch cellSearch, IPositionCalculator positionCalculator, int step);
    }
}