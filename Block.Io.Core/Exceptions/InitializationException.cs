using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Exceptions
{
    public class InitializationException : Exception
    {
        public InitializationException() : base("Collection is empty")
        {
        }
    }
}
