using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    public class NrException : Exception
    {
        public NrException()
        {
        }

        public NrException(string message) : base(message)
        {
        }

        public NrException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NrException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
