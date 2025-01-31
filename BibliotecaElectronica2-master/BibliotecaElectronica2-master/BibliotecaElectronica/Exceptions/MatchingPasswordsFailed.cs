using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BibliotecaElectronica.Exceptions
{
    public class MatchingPasswordsFailed : Exception
    {
        public MatchingPasswordsFailed()
        {
        }

        public MatchingPasswordsFailed(string message) : base(message)
        {
        }

        public MatchingPasswordsFailed(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MatchingPasswordsFailed(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
