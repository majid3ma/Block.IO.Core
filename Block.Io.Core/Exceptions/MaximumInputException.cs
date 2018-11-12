using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Exceptions {
    public class MaximumInputException : Exception {
        public MaximumInputException(string message):base(message) {}
    }
}
