using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BattleshipTracker.Models
{
    public class AttackResponse
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public string Result { get; set; }
        public IBoard Board { get; set; }
    }
}
