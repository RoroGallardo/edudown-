using Entidades;
using DatAcc;
using System.Collections.Generic;

namespace Negocio
{
	public class BLEquipoMedico {

        public void llamarAgregarEquipoMedico(ENEquipoMedico iEquipoMedico)
        {
            new DEquipoMedico().insertar(iEquipoMedico);

        }

        public void llamarEliminarEquipoMedico(ENEquipoMedico iEquipoMedico)
        {
            new DEquipoMedico().eliminar(iEquipoMedico);
        }

        public void llamarModificarEquipoMedico(ENEquipoMedico iEquipoMedico)
        {
            new DEquipoMedico().modificar(iEquipoMedico);
        }

        public List<ENEquipoMedico> llamarListarEquipoMed()
        {
            List<ENEquipoMedico> lista = new DEquipoMedico().listarEquipoMed();
            return lista;

        }
        public ENEquipoMedico llamarBuscarEquipoMed(int iId)
        {
            return new DEquipoMedico().buscar(iId);
        }


     }
}