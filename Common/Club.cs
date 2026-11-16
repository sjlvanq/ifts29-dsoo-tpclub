using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

using Club1.Data.Repositories;
using Club1.Models;

namespace Club1.Common
{
    public class Club
    {
        SocioRepo socioRepo = new SocioRepo();
        PagoRepo pagoRepo = new PagoRepo();

        public Models.Socio registrarSocio(Models.Socio socio)
        {
            if (socioRepo.existeSocio(socio.getDni()))
            {
                throw new InvalidOperationException("El socio ya está registrado.");
            }

            if (socioRepo.registrar(socio))
            {
                return socio;
            }

            throw new InvalidOperationException("Error al registrar el socio.");
        }

        public Models.ContratacionResultado contratarPlan(int idCliente, int idPlan, int idPromocion, DateTime? fechaInicio = null)
        {
            return socioRepo.contratarPlan(idCliente, idPlan, idPromocion, fechaInicio);
        }

        public bool registrarPago(Models.Pago pago)
        {
            return pagoRepo.registrar(pago);
        }
    }
}
