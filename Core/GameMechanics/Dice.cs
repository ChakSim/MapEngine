namespace MapEngine
{
    class Dice: IDice
    {
        private int _initialValue = 1;
        private int _finalValue = 7;

        public int Roll(ICells cells, ICellSearch cellSearch)
        {
            int roll = Utils.GenerateRandomNumber(_initialValue, _finalValue);

            cellSearch.SearchCells(cells, (cell) =>
            {
                if (cell.Index == "roll") 
                {
                    cell.RecordCellText(roll.ToString());
                }
            });

            return roll;
        }
    }
}
