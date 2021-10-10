using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Exceptions
{
    public class UnknownException : Exception
    {
        public UnknownException()
            : base()
        {
        }

        public UnknownException(string message)
            : base(message)
        {
        }

        public UnknownException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UnknownException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was unknown.")
        {
        }
    }
}
