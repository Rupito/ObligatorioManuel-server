using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Excepciones
{
    public class PrestamoException : Exception
    {
        public PrestamoException() { }
        public PrestamoException(string message) : base(message) { }
        public PrestamoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
