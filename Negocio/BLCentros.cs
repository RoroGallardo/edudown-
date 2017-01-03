using Entidades;
using DatAcc;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
	public class BLCentros{

		public bool llamarAgregarCentros(ENCentros iCentro){
            try
            {
                return new DCentros().insertar(iCentro);
                 
            }
            catch (System.Exception ex)
            {          
                return false;
            }
		}

		public bool llamarEliminarCentro(int idCentro){
            try
            {
                return new DCentros().eliminar(idCentro);
            }
            catch (System.Exception)
            {

                throw;
            }
		}

		public bool llamarModificarCentro(ENCentros iCentro){
            try
            {
                return new DCentros().modificar(iCentro);
            }
            catch (System.Exception)
            {
                
                throw;
            }
		}

		public List<ENCentros> llamarListarcentros(){
            try
            {
                List<ENCentros> lista = new DCentros().listar();
                return lista;

            }
            catch (System.Exception)
            {
                
                throw;
            }
		        }

        public ENCentros llamarBuscarCentro(int iID)
        {
            try
            {
                return new DCentros().buscar(iID);
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

        public int llamarRetornarId(string nombre)
        {
            try
            {
                return new DCentros().returnIdNombre(nombre);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

     }
}
