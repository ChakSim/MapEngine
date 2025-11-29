namespace MapEngine
{
    class PositionCalculator : IPositionCalculator
    {
        public string GetNewPosition(string index, int step)
        {
            int number = 0;
            int maxmaximumNumberCells = 48;
            int maxmaximumNumberTCells = 26;

            string prefix = string.Empty;

            (prefix, number) = Utils.FormatedIndex(index);

            if (prefix == "" || number > 0)
            {
                number += step;

                if (number > maxmaximumNumberCells)
                {
                    number -= maxmaximumNumberCells;
                }

                prefix += number;
            }

            else if (prefix == "T1.")
            {
                number += step;

                if (number > maxmaximumNumberTCells)
                {
                    number -= maxmaximumNumberCells;
                }

                prefix += number;
            }

            return prefix;
        }
    }
}