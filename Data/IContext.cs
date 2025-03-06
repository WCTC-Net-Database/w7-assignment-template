using W7_assignment_template.Models.Characters;

namespace W7_assignment_template.Data
{
    public interface IContext
    {
        List<CharacterBase> Characters { get; set; }

        void AddCharacter(CharacterBase character);

        void UpdateCharacter(CharacterBase character);

        void DeleteCharacter(string characterName);

    }
}
