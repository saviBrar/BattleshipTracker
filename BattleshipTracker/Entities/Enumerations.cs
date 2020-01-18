
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BattleshipTracker
{
    //Define whether an attack was a hit or a miss
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AttackResult
    {
        Hit,
        Miss
    }

    //Define how the ship is placed
    public enum OrientationType
    {
        Vertical,
        Horizontal
    }
}