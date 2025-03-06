using W7_assignment_template.Data;
using W7_assignment_template.Interfaces;
using W7_assignment_template.Models.Characters;
using W7_assignment_template.Models.Rooms;

namespace W7_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IRoomFactory _roomFactory;
        private readonly MenuManager _menuManager;
        private readonly MapManager _mapManager;
        private readonly OutputManager _outputManager;
        private readonly IContext _context;

        private CharacterBase _player;
        private CharacterBase _goblin;
        private List<IRoom> _rooms;

        public GameEngine(IContext context, IRoomFactory roomFactory, MenuManager menuManager, MapManager mapManager, OutputManager outputManager)
        {
            _context = context;

            _roomFactory = roomFactory;
            _menuManager = menuManager;
            _mapManager = mapManager;
            _outputManager = outputManager;
        }

        public void Run()
        {
            // Show main menu and check if the user wants to start the game
            if (_menuManager.ShowMainMenu())
            {
                // Setup game world after menu interaction
                SetupGame();
            }
        }

        private void SetupGame()
        {
            // reset the output manager
            _outputManager.Clear();

            // Setup rooms and assign starting room
            var startingRoom = SetupRooms();

            // Create player using CharacterFactory
            _player = _context.Characters.OfType<Player>().FirstOrDefault();
            _player.CurrentRoom = startingRoom;

            _outputManager.WriteLine($"{_player.Name} has entered the game.", ConsoleColor.Green);

            // Load monsters into random rooms 
            LoadMonsters();

            // Update map manager with the current room
            _mapManager.UpdateCurrentRoom(startingRoom);

            // Start game loop
            GameLoop();
        }

        private IRoom SetupRooms()
        {
            // Create rooms using RoomFactory
            var entrance = _roomFactory.CreateRoom("entrance", _outputManager);
            var treasureRoom = _roomFactory.CreateRoom("treasure", _outputManager);
            var dungeonRoom = _roomFactory.CreateRoom("dungeon", _outputManager);
            var library = _roomFactory.CreateRoom("library", _outputManager);
            var armory = _roomFactory.CreateRoom("armory", _outputManager);
            var garden = _roomFactory.CreateRoom("garden", _outputManager);

            // Link rooms together
            entrance.North = treasureRoom;
            treasureRoom.South = entrance;
            treasureRoom.West = dungeonRoom;
            library.East = armory;
            armory.West = library;
            entrance.West = library;
            entrance.East = garden;
            garden.West = entrance;
            dungeonRoom.East = treasureRoom;

            // Store rooms in a list for later use
            _rooms = new List<IRoom> { entrance, treasureRoom, dungeonRoom, library, armory, garden };

            return entrance; // Starting room
        }

        private void LoadMonsters()
        {
            var random = new Random();
            var randomRoom = _rooms[random.Next(_rooms.Count)];

            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
            _goblin.CurrentRoom = randomRoom;
            randomRoom.Characters.Add(_goblin);

            _outputManager.WriteLine($"{_goblin.Name} has entered {randomRoom.Name}.", ConsoleColor.Red);
        }

        // Game loop that handles movement and interaction
        private void GameLoop()
        {
            while (true)
            {
                _mapManager.DisplayMap();
                _outputManager.WriteLine("Choose an action:", ConsoleColor.Cyan);
                _outputManager.WriteLine("1. Move North");
                _outputManager.WriteLine("2. Move South");
                _outputManager.WriteLine("3. Move East");
                _outputManager.WriteLine("4. Move West");

                // Check if there are characters in the current room
                if (_player.CurrentRoom.Characters.Any(c => c != _player))
                {
                    _outputManager.WriteLine("5. Attack");
                }


                _outputManager.WriteLine("6. Exit Game");

                _outputManager.Display();

                string input = Console.ReadLine();

                string? direction = null;
                switch (input)
                {
                    case "1":
                        direction = "north";
                        break;
                    case "2":
                        direction = "south";
                        break;
                    case "3":
                        direction = "east";
                        break;
                    case "4":
                        direction = "west";
                        break;
                    case "5":
                        if (_player.CurrentRoom.Characters.Any(c => c != _player))
                        {
                            AttackCharacter();
                        }
                        else
                        {
                            _outputManager.WriteLine("No characters to attack.", ConsoleColor.Red);
                        }
                        break;
                    case "6":
                        _outputManager.WriteLine("Exiting game...", ConsoleColor.Red);
                        _outputManager.Display();
                        Environment.Exit(0);
                        break;
                    default:
                        _outputManager.WriteLine("Invalid selection. Please choose a valid option.", ConsoleColor.Red);
                        break;
                }

                // Update map manager with the current room after movement
                if (!string.IsNullOrEmpty(direction))
                {
                    _outputManager.Clear();
                    _player.Move(direction);
                    _mapManager.UpdateCurrentRoom(((CharacterBase)_player).CurrentRoom);
                }
            }
        }

        private void AttackCharacter()
        {
            var target = _player.CurrentRoom.Characters.FirstOrDefault(c => c != _player);
            if (target != null)
            {
                _player.Attack(target);
            }
            else
            {
                _outputManager.WriteLine("No characters to attack.", ConsoleColor.Red);
            }
        }
    }
}
