using System;
namespace BattleshipTracker.Exceptions
{
    public class RowOrColumnNumberLessThanOneException : Exception
    {
        public RowOrColumnNumberLessThanOneException()
        {
        }

        public RowOrColumnNumberLessThanOneException(string message)
        : base(message)
        {
        }

        public RowOrColumnNumberLessThanOneException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
