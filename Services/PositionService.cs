using System.Collections.Generic;

namespace MapEngine
{
    internal class PositionService : IPositionService
    {
        private Dictionary<string, int[]> _coordinateMap;

        public PositionService(ICells cells, ICellSearch cellSearch)
        {
            _coordinateMap = new Dictionary<string, int[]>();

            InitilizationDictinary(cells, cellSearch);
        }

        public int[] GetCoordinate(string index)
        {
            if (_coordinateMap.TryGetValue(index, out int[] coords))
            {

                return coords;
            }

            return null;
        }

        private void InitilizationDictinary(ICells cells, ICellSearch cellSearch)
        {
            cellSearch.SearchCells(cells, (cell) =>
            {
                _coordinateMap[cell.Index] = new int[] { cell.CoordinatesX, cell.CoordinatesY };
            }
                );
        }
    }
}
