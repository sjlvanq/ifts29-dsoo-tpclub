using System;
using System.Collections.Generic;
using System.Text;

namespace Club1
{
    public interface IControlListadoRecord
    {
        public string ClienteNombreCompleto { get; }
        public bool ClienteHabilitado { get; }
        public string ClienteNroCarnet { get; }
        public string ClienteDni { get; }
    }
}
