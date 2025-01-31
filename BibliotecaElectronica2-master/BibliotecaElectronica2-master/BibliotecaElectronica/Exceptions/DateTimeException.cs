using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Exceptions
{
    public class DateTimeException : Exception
    {
        public DateTimeException()
        {
        }

        public DateTimeException(string message) : base(message)
        {
        }

        public DateTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
