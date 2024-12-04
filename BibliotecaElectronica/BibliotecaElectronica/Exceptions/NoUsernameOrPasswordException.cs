using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
     public class NoUsernameOrPasswordException : Exception
    {
        public NoUsernameOrPasswordException()
        {
        }

        public NoUsernameOrPasswordException(string message) : base(message)
        {
        }

        public NoUsernameOrPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoUsernameOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
