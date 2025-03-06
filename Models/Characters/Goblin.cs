using W7_assignment_template.Interfaces;
using W7_assignment_template.Services;

namespace W7_assignment_template.Models.Characters;

public class Goblin : CharacterBase, ILootable
{
    public string Treasure { get; set; }

    public Goblin() : base() { }

    public Goblin(string name, string type, int level, int hp, string treasure, IRoom startingRoom) : base(name, type, level, hp, startingRoom)
    {
        Treasure = treasure;
    }

    public override void UniqueBehavior()
    {
        throw new NotImplementedException();
    }
}
