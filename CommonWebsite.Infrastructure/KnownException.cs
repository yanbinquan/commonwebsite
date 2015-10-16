using System;

namespace CommonWebsite.Infrastructure
{
    public class KnownException : Exception
    {
        public KnownException(string message)
            : base(message)
        {

        }
    }
}
