using Entidades;
using DatAcc;
using System.Collections.Generic;


namespace Negocio
{
	public class BLAgendaBox {


        public bool llamarAgregarAgendaBox(ENAgendaBox iAgendaBox)
        {
            try
            {
                return new DAgendaBox().agregarAgenda(iAgendaBox);
            }
            catch (System.Exception)
            {
               throw;
            }

        }

        public void llamarEliminarAgendaBox(ENAgendaBox iAgendaBox)
        {
            //crar metodo 
            //new DAgendaBox.EliminarAgendaBox(iAgendaBox);
        }
        //revisar si esta bien 
        public ENAgendaBox llamarbuscarAgenda(int i_id)
        {
            return new DAgendaBox().buscarAgendaId(i_id);
        }

        public List<ENAgendaBox> llamarListarAgendaBox()
        {
            List<ENAgendaBox> lista = new DAgendaBox().listar();
            return lista;
        }

        public ENAgendaBox llamarBuscarAgendaFecha(string iFechaTratamiento)
        {
            return new DAgendaBox().buscarAgendaFecha(iFechaTratamiento);
        }

        public int llamarCount()
        {
            return new DAgendaBox().count();
        }

     }
}
