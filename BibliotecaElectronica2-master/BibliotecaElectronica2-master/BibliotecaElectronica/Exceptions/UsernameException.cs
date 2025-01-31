using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    public class UsernameException : Exception
    {
        public UsernameException()
        {
        }

        public UsernameException(string message) : base(message)
        {
        }

        public UsernameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsernameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
