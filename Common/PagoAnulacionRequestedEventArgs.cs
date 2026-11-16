using System;

namespace Club1.Common
{
    public sealed class PagoAnulacionRequestedEventArgs : EventArgs
    {
        public int IdPago { get; }
        public string NotaAnulacion { get; }

        public PagoAnulacionRequestedEventArgs(int idPago, string notaAnulacion)
        {
            IdPago = idPago;
            NotaAnulacion = notaAnulacion;
        }
    }
}
