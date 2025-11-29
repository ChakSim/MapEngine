using System;

namespace MapEngine
{
    internal class Chip
    {
        private string _indexLocation;
        private string _id;
        private char _symbol = (char)Items.Chip;

        public Chip(string index)
        {
            _indexLocation = index;
            while (Utils.CreateUniquedId(out _id))
            {
                Console.WriteLine("Генерация Id...");
            }
        }

        public void SetIndexCell(string index) => _indexLocation = index;

        public char Symbol => _symbol;

        public string Index => _indexLocation;

        public string ID => _id;
    }
}
