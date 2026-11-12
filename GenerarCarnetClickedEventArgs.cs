using System;
using System.Collections.Generic;
using System.Text;

namespace Club1
{
    public class GenerarCarnetClickedEventArgs : EventArgs
    {
        public int ClienteId { get; }
        public GenerarCarnetClickedEventArgs(int clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
