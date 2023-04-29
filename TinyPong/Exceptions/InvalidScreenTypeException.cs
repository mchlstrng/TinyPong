using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TinyPong.Exceptions
{
    public class InvalidScreenTypeException : Exception
    {
        public InvalidScreenTypeException()
        {
        }

        public InvalidScreenTypeException(string message) : base(message)
        {
        }

        public InvalidScreenTypeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
