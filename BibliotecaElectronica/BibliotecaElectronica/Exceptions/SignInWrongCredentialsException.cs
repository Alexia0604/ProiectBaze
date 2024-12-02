using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    internal class SignInWrongCredentialsException : Exception
    {
        public SignInWrongCredentialsException()
        {
        }

        public SignInWrongCredentialsException(string message) : base(message)
        {
        }

        public SignInWrongCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SignInWrongCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
