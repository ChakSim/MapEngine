using System;

namespace MapEngine
{
    internal class ItemRender : IRenderItem
    {
        private readonly IPositionService _positionService;

        public ItemRender(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public void ShowItem(string text, string index)
        {
            int[] coordinate = _positionService.GetCoordinate(index);

            if (coordinate != null)
            {
                Console.SetCursorPosition(coordinate[1], coordinate[0]);
                Console.Write(text);
            }
        }
    }
}