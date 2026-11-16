using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Common
{
    public class ProximoVencimientoRequestedEventArgrs : EventArgs
    {
        public string ClienteDni { get; }
        public ProximoVencimientoRequestedEventArgrs(string clienteDni)
        {
            ClienteDni = clienteDni;
        }
    }
}
