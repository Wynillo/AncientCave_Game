using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpritesheetManagement.models;

[JsonConverter(typeof(StringEnumConverter))]  
public enum SpriteType
{
    Character,
    Enemy,
    Item,
    Object,
    Effect
}