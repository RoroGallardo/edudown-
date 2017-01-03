using Entidades;
using DatAcc;
using System.Collections.Generic;

namespace Negocio
{
	public class BLPeriodo{


        public void llamarInsertarPeriodo(ENPeriodo iPeriodo)
        {
            new DPeriodo().insertar(iPeriodo);
        }

        public void llamarEliminarPeriodo(ENPeriodo iPeriodo)
        {
            new DPeriodo().eliminar(iPeriodo);
        }

        public void llamarModificarPeriodo(ENPeriodo iPeriodo)
        {
            new DPeriodo().modificar(iPeriodo);
        }

        public List<ENPeriodo> llamarListarPeriodo()
        {
            List<ENPeriodo> lista = new DPeriodo().listarPeriodo();
            return lista;

        }
        public ENPeriodo llamarBuscarPeriodo(int iId)
        {
            return new DPeriodo().buscar(iId);
        }
        public int llamarCount()
        {
            return new DPeriodo().count();
        }

     }
}