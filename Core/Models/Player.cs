namespace MapEngine
{
    internal class Player : IPlayer
    {
        private string _name;

        private Chip _chip; 
        
        public Player(string name, string startLocation) 
        {
            _name = name;
            _chip = new Chip(startLocation);
        }

        public string Name => _name;

        public Chip Chip => _chip;
    }
}
