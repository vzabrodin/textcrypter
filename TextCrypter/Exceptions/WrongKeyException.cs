using System;

namespace TextCrypter.Exceptions
{
    public class WrongKeyException : Exception
    {
        public WrongKeyException()
        {
        }

        public WrongKeyException(string message)
            : base(message)
        {
        }

        public WrongKeyException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
