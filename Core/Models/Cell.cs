namespace MapEngine
{
    internal class Cell : ICell
    {
        private string _chipID;
        private string _nameSquare;
        private string _inputText;

        private int _coordinatesX;
        private int _coordinatesY;
        private int _maxLengthContentText;

        public Cell(string nameSquare, int coordinatesX, int coordinatesY, int maxLength)
        {
            _nameSquare = nameSquare;
            _coordinatesX = coordinatesX;
            _coordinatesY = coordinatesY;
            _maxLengthContentText = maxLength;
        }

        public int MaxLengthTextContent => _maxLengthContentText;

        public void LockCell(string chipID)
        {
            _chipID = chipID;
        }

        public void UnlocCell()
        {
            _chipID = string.Empty;
        }

        public void RecordCellText(string inputText)
        {
            if (inputText == null)
            {
                inputText = string.Empty;
            }
            if((MaxLengthTextContent-inputText.Length)%2>0)
            {
                _inputText = $"{new string(' ', (_maxLengthContentText - inputText.Length) / 2)}{inputText}{new string(' ', (_maxLengthContentText - inputText.Length) / 2)} ";
            }
            else
            {
            _inputText = $"{new string(' ', (_maxLengthContentText - inputText.Length) / 2)}{inputText}{new string(' ', (_maxLengthContentText - inputText.Length) / 2)}";
            }
        }


        public void ClearCellText()
        {
            _inputText = string.Empty;
        }

        public string Index => _nameSquare;

        public int CoordinatesX => _coordinatesX;

        public int CoordinatesY => _coordinatesY;

        public string InputText => _inputText;

        public bool IsOccupied => !string.IsNullOrEmpty(_chipID);
    }
}