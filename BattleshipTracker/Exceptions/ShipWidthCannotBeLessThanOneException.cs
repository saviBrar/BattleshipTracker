using System;
namespace BattleshipTracker
{
    public class ShipWidthCannotBeLessThanOneException : Exception
    {
        public ShipWidthCannotBeLessThanOneException()
        {
        }

        public ShipWidthCannotBeLessThanOneException(string message)
        : base(message)
        {
        }

        public ShipWidthCannotBeLessThanOneException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
