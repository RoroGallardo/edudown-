using Entidades;
using DatAcc;
using System.Collections.Generic;

namespace Negocio
{
	public class BLPaqueteInsumo{

        public void llamarInsertarPaqueteInsumo(ENPaqueteInsumo iPaqueteI)
        {
            new DPaqueteInsumo().insertar(iPaqueteI);
        }

        public void llamarEliminarPaqueteInsumo(ENPaqueteInsumo iPaqueteI)
        {
            new DPaqueteInsumo().eliminar(iPaqueteI);
        }

        public void llamarModificarPaqueteInsumo(ENPaqueteInsumo iPaqueteI)
        {
            new DPaqueteInsumo().modificar(iPaqueteI);
        }

        public List<ENPaqueteInsumo> llamarListarPaqueteInsumo()
        {
            List<ENPaqueteInsumo> lista = new DPaqueteInsumo().listarPaqueteIns();
            return lista;

        }

     }
}
