using System;
namespace BattleshipTracker.Exceptions
{
    public class BoardCellNullException : Exception
    {
        public BoardCellNullException()
        {
        }

        public BoardCellNullException(string message)
        : base(message)
        {
        }

        public BoardCellNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
