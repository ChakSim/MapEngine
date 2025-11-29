namespace MapEngine
{
    internal class Program
    {
        static void Main()
        {
            GameFactoryData gameFactoryData = new GameFactoryData();

            GameLogic gameLogic = new GameLogic(gameFactoryData);

            gameLogic.Run();
        }
    }
}