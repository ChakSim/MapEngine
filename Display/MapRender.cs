using System;

namespace MapEngine
{
    public class MapRender : IMapRender
    {
        public void DrawMap(IMap map)
        {
            for (int y = 0; y < map.GetMap().Count; y++)
            {
                for (int x = 0; x < (map.GetMap()[y].Count); x++)
                {
                    if (map.GetMap()[y][x] == (char)Items.LeftEdgeField || map.GetMap()[y][x] == (char)Items.RightEdgeField)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(map.GetMap()[y][x]);
                }
                Console.Write("\n");
            }
        }
    }
}
