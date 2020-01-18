using System;
namespace BattleshipTracker.Models
{
    public class PlaceBattleshipResponse
    {
        public bool Result { get; set; }
        public IBoard Board { get; set; }
    }
}
