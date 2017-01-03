using Entidades;
using DatAcc;
using System.Collections.Generic;


namespace Negocio
{
	public class BLPatologia{


		public void llamarAgregarPatologia(ENPatologia iPatologia){
			new DPatologia().insertar(iPatologia);           
		}

		public void llamarEliminarPatologia(ENPatologia iPatologia){
			new DPatologia().eliminar(iPatologia);
		}

		public void llamarModificarPatologia(ENPatologia iPatologia){
			new DPatologia().modificar(iPatologia);
		}

        public ENPatologia llamarBuscar(int id)
        {
            return new DPatologia().buscar(id);
        }

		public List<ENPatologia> llamarListarPatologia(){
			List<ENPatologia> lista = new DPatologia().listar();
			return lista;

		}

     }
}