using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Common
{
    public interface IControlListadoRecord
    {
        public string ClienteNombreCompleto { get; }
        public bool ClienteHabilitado { get; }
        public bool ClienteEsSocio { get; }
        public string ClienteNroCarnet { get; }
        public string ClienteDni { get; }
    }
}
