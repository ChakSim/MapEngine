using System;
using System.Collections.Generic;
using System.IO;

namespace MapEngine
{
    public class MapBuilder : IMap, ICells
    {
        private string[] _file;
        private List<ICell> _cells;
        private List<List<char>> _map;
        private Queue<CellData> _nameCells;

        public MapBuilder(string path, IParser<List<List<char>>> mapParser, IParser<Queue<CellData>> cellParser)
        {
            _file = File.ReadAllLines(path);
            _map = mapParser.Parse(_file);
            _nameCells = cellParser.Parse(_file);
            _cells = BuilderCells();
        }

        private List<ICell> BuilderCells()
        {
            List<ICell> cells = new List<ICell>();

            string nameCell = string.Empty;

            if (DoNumberCellsMatch())
            {
                IteratingThroughArray((y, x) =>
                {
                    CellData cellData = _nameCells.Dequeue();
                    cells.Add(new Cell(cellData.Name, y, x, cellData.MaxLength));
                });
            }
            else
            {
                throw new InvalidDataException("Несоответствие ячеек и координат, компиляция не возможна");
            }

            return cells;
        }

        private bool DoNumberCellsMatch()
        {
            int iteration = 0;

            IteratingThroughArray((y,x) =>
                {
                    iteration++;
                });

            return iteration == _nameCells.Count;
        }

        private void IteratingThroughArray(Action<int,int> action)
        {
            bool isCell = false;

            for (int mapY = 0; mapY < _map.Count; mapY++)
            {
                for (int mapX = 0; mapX < _map[mapY].Count; mapX++)
                {
                    if (_map[mapY][mapX] == '[')
                    {
                        isCell = true;
                    }

                    else if (isCell && _map[mapY][mapX] != '[' && _map[mapY][mapX] != ']')
                    {
                        isCell = false;
                        action(mapY,mapX);
                    }
                }
            }
        }

        public List<List<char>> GetMap() => _map;

        public List<ICell> GetCells()
        {
            return _cells;
        }
    }
}