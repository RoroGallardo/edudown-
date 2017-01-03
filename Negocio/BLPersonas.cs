using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DatAcc;
namespace Negocio
{
    public class BLPersonas
    {
        public ENPersona llamarBuscarPersonas(int id)
        {
            return new DPersona().buscarPersona(id);
        }

        public int llamarRetornarId(string rut)
        {
            return new DPersona().returnIdPersona(rut);
        }

    }
}
