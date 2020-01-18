using System;
using System.ComponentModel.DataAnnotations;

namespace BattleshipTracker.Models
{
    public class PlaceBattleshipRequest
    {
        [Required]
        [Range(1, 10)]
        public int RowCoordinate { get; set; }

        [Required]
        [Range(1, 10)]
        public int ColumCoordinate { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public string Orientation { get; set; }
    }
}
