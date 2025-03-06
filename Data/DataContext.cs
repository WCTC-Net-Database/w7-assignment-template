using System.Text.Json;
using W7_assignment_template.Models.Characters;
using W7_assignment_template.Services;

namespace W7_assignment_template.Data
{
    public class DataContext : IContext
    {
        public List<CharacterBase> Characters { get; set; }  // Generalized to store all character types

        private readonly JsonSerializerOptions options;

        public DataContext(OutputManager outputManager)
        {
            options = new JsonSerializerOptions
            {
                Converters = { new CharacterBaseConverter(outputManager) },
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            LoadData();
        }

        private void LoadData()
        {
            var jsonData = File.ReadAllText("Files/input.json");
            Characters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, options); // Load all character types
        }

        public void AddCharacter(CharacterBase character)
        {
            Characters.Add(character);
            SaveData();
        }

        public void UpdateCharacter(CharacterBase character)
        {
            var existingCharacter = Characters.FirstOrDefault(c => c.Name == character.Name);
            if (existingCharacter != null)
            {
                existingCharacter.Level = character.Level;
                existingCharacter.HP = character.HP;

                if (existingCharacter is Player player && character is Player updatedPlayer)
                {
                    player.Gold = updatedPlayer.Gold;  // Specific to Player
                }
                if (existingCharacter is Goblin goblin && character is Goblin updatedGoblin)
                {
                    goblin.Treasure = updatedGoblin.Treasure;  // Specific to Goblin
                }

                SaveData();
            }
        }

        public void DeleteCharacter(string characterName)
        {
            var character = Characters.FirstOrDefault(c => c.Name == characterName);
            if (character != null)
            {
                Characters.Remove(character);
                SaveData();
            }
        }

        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(Characters, options);
            File.WriteAllText("Files/input.json", jsonData);
        }
    }
}
