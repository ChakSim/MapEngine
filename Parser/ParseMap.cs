using System.Collections.Generic;

namespace MapEngine
{
    public class ParseMap : IParser <List<List<char>>>
    {
        private List<List<char>> _parseMatrixMap;

        public ParseMap()
        {
            _parseMatrixMap = new List<List<char>>();
        }

        public List<List<char>> Parse(string[] file)
        {
            foreach (var line in file)
            {
                var filteredChars = new List<char>();
                bool inBrackets = false;

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
                        continue;
                    }

                    if (!inBrackets)
                    {
                        filteredChars.Add(c);
                    }
                }

                _parseMatrixMap.Add(filteredChars);
            }

            return _parseMatrixMap;
        }
    }
}
