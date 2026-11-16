using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Common
{
    public class PagosHistorialRequestedEventArgs : EventArgs
    {
        public string ClienteDni { get; }
        public PagosHistorialRequestedEventArgs(string clienteDni)
        {
            ClienteDni = clienteDni;
        }
    }
}
