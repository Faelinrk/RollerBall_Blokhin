using System;

namespace RollerBall.Exceptions
{
    public class ListIsEmptyException : Exception
    {
        public ListIsEmptyException(string message) : base(message)
        {

        }
    }

}
