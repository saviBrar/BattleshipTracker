using System;
namespace BattleshipTracker
{
    public interface IBattleship
    {
        public int Width { get; set; }
        public OrientationType Orientation { get; set; }
    }
}
