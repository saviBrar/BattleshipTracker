using System;
namespace BattleshipTracker.Exceptions
{
    public class BoardNullException : Exception
    {
        public BoardNullException()
        {
        }

        public BoardNullException(string message)
        : base(message)
        {
        }

        public BoardNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
