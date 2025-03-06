using W7_assignment_template.Interfaces;
using W7_assignment_template.Services;

namespace W7_assignment_template.Models.Characters
{
    public abstract class CharacterBase : ICharacter
    {
        public IRoom CurrentRoom;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        protected OutputManager OutputManager;

        // Parameterless constructor for deserialization
        protected CharacterBase() { }

        protected CharacterBase(string name, string type, int level, int hp, IRoom startingRoom)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;

            CurrentRoom = startingRoom;
            CurrentRoom.Enter();
        }

        public void Attack(ICharacter target)
        {
            OutputManager.WriteLine($"{Name} attacks {target.Name} with a chilling touch.", ConsoleColor.Blue);

            if (this is Player player && target is ILootable targetWithTreasure && !string.IsNullOrEmpty(targetWithTreasure.Treasure))
            {
                OutputManager.WriteLine($"{Name} takes {targetWithTreasure.Treasure} from {target.Name}", ConsoleColor.Blue);
                player.Gold += 10; // Assuming each treasure is worth 10 gold
                targetWithTreasure.Treasure = null; // Treasure is taken
            }
            else if (this is Player playerWithGold && target is Player targetWithGold && targetWithGold.Gold > 0)
            {
                OutputManager.WriteLine($"{Name} takes gold from {target.Name}", ConsoleColor.Blue);
                playerWithGold.Gold += targetWithGold.Gold;
                targetWithGold.Gold = 0; // Gold is taken
            }
        }

        // Common room entry logic
        public void EnterRoom(IRoom room)
        {
            CurrentRoom = room;
            OutputManager.WriteLine($"{Name} has entered {CurrentRoom.Name}. {CurrentRoom.Description}", ConsoleColor.Green);
            foreach (var character in CurrentRoom.Characters)
            {
                OutputManager.WriteLine($"{character.Name} is here.", ConsoleColor.Red);
            }
        }
        
        // Common movement logic
        public void Move(string? direction)
        {
            IRoom? nextRoom;
            switch (direction?.ToLower())
            {
                case "north":
                    nextRoom = CurrentRoom.North;
                    break;
                case "south":
                    nextRoom = CurrentRoom.South;
                    break;
                case "east":
                    nextRoom = CurrentRoom.East;
                    break;
                case "west":
                    nextRoom = CurrentRoom.West;
                    break;
                default:
                    nextRoom = null;
                    break;
            }

            if (nextRoom != null)
            {
                EnterRoom(nextRoom);
            }
            else
            {
                OutputManager.WriteLine($"{Name} cannot move that way.", ConsoleColor.Yellow);
            }
        }

        public void SetOutputManager(OutputManager outputManager)
        {
            OutputManager = outputManager;
        }

        // Abstract method for unique behavior to be implemented by derived classes
        public abstract void UniqueBehavior();
    }
}
