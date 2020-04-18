using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Infaestructure.Exceptions
{
    public class InfraestructureException: Exception
    {

        internal InfraestructureException(string message)
               : base(message)
        {
        }

        public InfraestructureException()
        {
        }

        public InfraestructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
