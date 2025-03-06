using W7_assignment_template.Interfaces;
using W7_assignment_template.Services;

namespace W7_assignment_template.Models.Rooms;

public class Room : IRoom
{
    public string Name { get; }
    public IRoom? North { get; set; }
    public IRoom? South { get; set; }
    public IRoom? West { get; set; }
    public IRoom? East { get; set; }
    public string Description { get; }
    public List<ICharacter> Characters { get; set; }

    private readonly OutputManager _outputManager;

    public Room(string name, string description, OutputManager outputManager)
    {
        Name = name;
        Description = description;
        _outputManager = outputManager;
        Characters = new List<ICharacter>();
    }
 
    public void Enter()
    {
        _outputManager.WriteLine($"You have entered {Name}. {Description}", ConsoleColor.Green);
        foreach (var character in Characters)
        {
            _outputManager.WriteLine($"{character.Name} is here.", ConsoleColor.Red);
        }
    }

}
