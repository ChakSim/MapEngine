namespace MapEngine
{
    class ProcessTurn : IProcessTurn
    {
        public void Update(IRefreshCellContent refreshCellContent,IRenderCellContents content, IDice dice, IPlayer player,IPlayers players, IPositionCalculator positionCalculator, ICells cells, ICellSearch cellSearch, IMovementAnimator animator)
        {
            int step = dice.Roll(cells,cellSearch);

            animator.AnimateMovement(refreshCellContent,content, player,players ,  cells, cellSearch, positionCalculator,step);
        }
    }
}