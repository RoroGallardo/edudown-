using Entidades;
using DatAcc;
using System.Collections.Generic;

namespace Negocio
{
	public class BLEstado{

        public void llamarAgergarEstado(ENEstado iEstado)
        {
            new DEstado().insertar(iEstado);
        }
        //en negocio
        public void llamarEliminarEstado(ENEstado iEstado)
        {
            new DEstado().eliminar(iEstado);
        }
        //en negocio
        public void llamarModificarEstado(ENEstado iEstado)
        {
            new DEstado().modificar(iEstado);

        }
        //en negocio
        public List<ENEstado> llamarListarEstado()
        {
            List<ENEstado> lista = new DEstado().listarEstado();
            return lista;
        }
     }
}

