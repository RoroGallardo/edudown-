using Entidades;
using DatAcc;
using System.Collections.Generic;


namespace Negocio
{
	public class BLFichaPaciente {


		public bool llamarAgregarFichaPaciente(ENFichaPaciente iFichaPaciente){
			return new DFichaPaciente().insertar(iFichaPaciente);
		}

		public bool llamarEliminarFichaPaciente(ENFichaPaciente iFichaPaciente){
           return new DFichaPaciente().eliminar(iFichaPaciente);
		}

		public bool llamarModificarFichaPaciente(ENFichaPaciente iFichaPaciente){
			return new DFichaPaciente().modificar(iFichaPaciente);
		}

		public List<ENFichaPaciente> llamarListarFichaPaciente(){
			List<ENFichaPaciente> lista = new DFichaPaciente().listarFichaPaciente();
			return lista;

		}

        public ENFichaPaciente llamarBuscarFichaID(int iId)
        {
            return new DFichaPaciente().buscarFichaID(iId);
        }
        public ENFichaPaciente llamarBuscarPorRut(string rut)
        {
            return new DFichaPaciente().buscarFichaPaciente(rut);
        }

     }
}
