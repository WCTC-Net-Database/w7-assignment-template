using W7_assignment_template.Interfaces;
using W7_assignment_template.Services;

namespace W7_assignment_template.Models.Rooms
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(string roomType, OutputManager outputManager)
        {
            switch (roomType.ToLower())
            {
                case "treasure":
                    return new Room("Treasure Room", "Filled with gold and treasures.", outputManager);
                case "dungeon":
                    return new Room("Dungeon", "Dark and damp, with echoes of past prisoners.", outputManager);
                case "entrance":
                    return new Room("Entrance Hall", "A large room with high ceilings.", outputManager);
                case "library":
                    return new Room("Library", "Shelves filled with ancient books.", outputManager);
                case "armory":
                    return new Room("Armory", "Weapons and armor line the walls.", outputManager);
                case "garden":
                    return new Room("Garden", "A peaceful garden with blooming flowers.", outputManager);
                default:
                    return new Room("Generic Room", "A simple room.", outputManager);

            }
        }
    }
}
