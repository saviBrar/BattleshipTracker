using System;
namespace BattleshipTracker
{
    public class Battleship : IBattleship
    {
        public Battleship()
        {
        }

        public int Width { get; set; }
        public OrientationType Orientation { get; set; }
    }
}
