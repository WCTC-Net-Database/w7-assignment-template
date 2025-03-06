using System.Text.Json;
using System.Text.Json.Serialization;
using W7_assignment_template.Models.Characters;
using W7_assignment_template.Services;

namespace W7_assignment_template.Data;

public class CharacterBaseConverter : JsonConverter<CharacterBase>
{
    private readonly OutputManager _outputManager;

    public CharacterBaseConverter(OutputManager outputManager)
    {
        _outputManager = outputManager;
    }

    public override CharacterBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            var typeProperty = root.GetProperty("$type").GetString();
            Type type = typeProperty switch
            {
                "W7_assignment_template.Models.Characters.Player" => typeof(Player),
                "W7_assignment_template.Models.Characters.Goblin" => typeof(Goblin),
                "W7_assignment_template.Models.Characters.Ghost" => typeof(Ghost),
                _ => throw new NotSupportedException($"Type {typeProperty} is not supported")
            };
            var character = (CharacterBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
            character.SetOutputManager(_outputManager);
            return character;
        }
    }

    public override void Write(Utf8JsonWriter writer, CharacterBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}