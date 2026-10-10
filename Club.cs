using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Club1
{
    public class Club
    {
        SocioRepo socioRepo = new SocioRepo();
        public Socio registrarSocio(Socio socio)
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
    }
}
