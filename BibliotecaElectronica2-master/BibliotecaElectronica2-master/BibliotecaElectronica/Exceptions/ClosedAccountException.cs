using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    public class ClosedAccountException : Exception
    {
        public ClosedAccountException()
        {
        }

        public ClosedAccountException(string message) : base(message)
        {
        }

        public ClosedAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClosedAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
