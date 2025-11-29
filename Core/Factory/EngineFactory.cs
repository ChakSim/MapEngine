using MapEngine.Parser;

namespace MapEngine
{
    public static class EngineFactory
    {
        public static MapBuilder CreateMapBuilder(string path)
        {
            return new MapBuilder (path,new ParseMap(),new ParseNameCell());
        }

        public static MapRender CreateShowerMap()
        {
            return new MapRender();
        }
    }
}