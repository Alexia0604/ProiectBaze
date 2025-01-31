using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    public class EmptyFiledsException : Exception
    {
        public EmptyFiledsException()
        {
        }

        public EmptyFiledsException(string message) : base(message)
        {
        }

        public EmptyFiledsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyFiledsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
