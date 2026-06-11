using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioManuel.Excepciones
{
    public class EquipoException : Exception
    {
        public EquipoException() { }
        public EquipoException(string message) : base(message) { }
        public EquipoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
