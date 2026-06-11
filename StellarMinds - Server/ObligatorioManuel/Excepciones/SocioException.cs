using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Excepciones
{
    public class SocioException : Exception
    {
        public SocioException() { }
        public SocioException(string message) : base(message) { }
        public SocioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
