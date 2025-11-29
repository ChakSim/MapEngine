namespace MapEngine
{
    internal class CreatePlayer : ICreatePlayer
    {
        public Player CreateNewPlayer(string name, string indexChipLocation)
        {
            return new Player(name, indexChipLocation); ;
        }
    }
}
