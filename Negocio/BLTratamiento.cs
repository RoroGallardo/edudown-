using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DatAcc;
namespace Negocio
{
    public class BLTratamiento
    {
        public bool llamarInsertarTratamiento(ENTratamiento eTratamiento)
        {
            return new DTratamiento().insertar(eTratamiento);
        }

        public bool llamarEliminarTratamiento(ENTratamiento eTratamiento)
        {
            return new DTratamiento().eliminar(eTratamiento);
        }

        public bool llamarModifcarTraramiento(ENTratamiento eTratamiento)
        {
           return new DTratamiento().modificar(eTratamiento);
        }
        public List<ENTratamiento> llamarListarTratamiento()
        {
            List<ENTratamiento> lista = new DTratamiento().listarEtapa();
            return lista;

        }
        public ENTratamiento llamarBuscarTratamiento(int id)
        {
            return new DTratamiento().buscar(id);
        }
    }
}
