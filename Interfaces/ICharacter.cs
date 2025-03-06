namespace W7_assignment_template.Interfaces;

public interface ICharacter
{
    string Name { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }

    void Attack(ICharacter target);
    void EnterRoom(IRoom room);
    void Move(string? direction = null);
}
