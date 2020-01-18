using System;
using System.ComponentModel.DataAnnotations;

namespace BattleshipTracker.Models
{
    public class AttackRequest
    {
        [Required]
        [Range(1, 10)]
        public int RowCoordinate { get; set; }
        [Required]
        [Range(1, 10)]
        public int ColumnCoordinate { get; set; }
    }
}
