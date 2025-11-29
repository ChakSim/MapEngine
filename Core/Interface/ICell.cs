namespace MapEngine
{
    public interface ICell
    {
        string Index { get; }
        int CoordinatesX { get; }
        int CoordinatesY { get; }
        int MaxLengthTextContent { get; }
        bool IsOccupied { get; }

        string InputText { get; }

        void LockCell(string chipID);
        void UnlocCell();
        void RecordCellText(string inputText);
        void ClearCellText();
    }
}
