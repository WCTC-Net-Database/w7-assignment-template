namespace W7_assignment_template.Interfaces;

public interface IRoom
{
    string Description { get; }
    string Name { get; }

    IRoom? North { get; set; }
    IRoom? South { get; set; }
    IRoom? West { get; set; }
    IRoom? East { get; set; }

    List<ICharacter> Characters { get; set; }
    void Enter();
}
