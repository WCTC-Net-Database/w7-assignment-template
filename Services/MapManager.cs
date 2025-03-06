using W7_assignment_template.Interfaces;

namespace W7_assignment_template.Services
{
    public class MapManager
    {
        private IRoom _currentRoom;
        private readonly OutputManager _outputManager;

        private const int RoomNameLength = 5;
        private const int gridRows = 5;
        private const int gridCols = 5;
        private string[,] mapGrid;

        public MapManager(OutputManager outputManager)
        {
            _currentRoom = null;
            _outputManager = outputManager;
            mapGrid = new string[gridRows, gridCols];
        }

        public void UpdateCurrentRoom(IRoom currentRoom)
        {
            _currentRoom = currentRoom;
        }

        public void DisplayMap()
        {
            _outputManager.WriteLine("Map:");

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridCols; j++)
                {
                    mapGrid[i, j] = "       ";
                }
            }

            if (_currentRoom != null)
            {
                int startRow = gridRows / 2;
                int startCol = gridCols / 2;
                PlaceRoom(_currentRoom, startRow, startCol);
            }

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridCols; j++)
                {
                    if (mapGrid[i, j].Contains("[") && mapGrid[i, j].Contains("]"))
                    {
                        if (mapGrid[i, j] == $"[{_currentRoom.Name.Substring(0, RoomNameLength)}]")
                        {
                            _outputManager.Write($"{mapGrid[i, j],-7}", ConsoleColor.Green);
                        }
                        else
                        {
                            _outputManager.Write($"{mapGrid[i, j],-7}", ConsoleColor.White);
                        }
                    }
                    else
                    {
                        _outputManager.Write($"{mapGrid[i, j],-7}");
                    }
                }
                _outputManager.WriteLine("");
            }

            _outputManager.Display();
        }

        private void PlaceRoom(IRoom room, int row, int col)
        {
            if (mapGrid[row, col] != "       ")
                return;

            string roomName = room.Name.Length > RoomNameLength
                ? room.Name.Substring(0, RoomNameLength)
                : room.Name.PadRight(RoomNameLength);

            if (room == _currentRoom)
            {
                mapGrid[row, col] = $"[{roomName}]";
            }
            else
            {
                mapGrid[row, col] = $"[{roomName}]";
            }

            if (room.North != null && row > 1)
            {
                mapGrid[row - 1, col] = "   |   ";
                PlaceRoom(room.North, row - 2, col);
            }
            if (room.South != null && row < gridRows - 2)
            {
                mapGrid[row + 1, col] = "   |   ";
                PlaceRoom(room.South, row + 2, col);
            }
            if (room.East != null && col < gridCols - 2)
            {
                mapGrid[row, col + 1] = "  ---  ";
                PlaceRoom(room.East, row, col + 2);
            }
            if (room.West != null && col > 1)
            {
                mapGrid[row, col - 1] = "  ---  ";
                PlaceRoom(room.West, row, col - 2);
            }
        }
    }
}
