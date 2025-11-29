using System.Collections.Generic;

namespace MapEngine.Parser
{
    public class ParseNameCell : IParser<Queue<CellData>>
    {
        private Queue<string> _cellsNames = new Queue<string>();

        public Queue<CellData> Parse(string[] file)
        {
            Queue<CellData> cellsData = new Queue<CellData>();

            foreach (var line in file)
            {
                bool inBrackets = false;

                bool isBrackets = false;

                string nameCell = string.Empty;

                int bracketContentLength = 0;

                foreach (char c in line)
                {
                    if (c == '(')
                    {
                        inBrackets = true;
                        continue;
                    }

                    if (c == ')')
                    {
                        inBrackets = false;
                        isBrackets = true;
                        continue;
                    }

                    if (inBrackets)
                    {
                        nameCell += c;
                    }

                    if (c == ']')
                    {
                        isBrackets = false;
                        cellsData.Enqueue(new CellData
                        {
                            Name = nameCell,
                            MaxLength = bracketContentLength
                        });
                        nameCell = string.Empty;
                        bracketContentLength = 0;
                        continue;
                    }

                    if (isBrackets)
                    {
                        bracketContentLength++;
                    }

                }
            }

            return cellsData;
        }
    }
}
