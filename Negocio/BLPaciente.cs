using Entidades;
using DatAcc;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Negocio
{
	public class BLPaciente{
		public bool llamarAgregarPaciente(ENPaciente iPaciente ){

            try
            {
                if (validarRut(iPaciente.rut))
                {
                    return new DPaciente().insertar(iPaciente);      

                }
                else
                {
                    return false;
                }
                

            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.StackTrace);
            }

		}

		public bool llamarEliminarPaciente(ENPaciente iPaciente){
            try
            {
                if (existeRut(iPaciente.rut) && validarRut(iPaciente.rut))
                {
                    return new DPaciente().eliminar(iPaciente);

                }
                else
                {
                    return false;
                }


            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.StackTrace);
            }


			
		}

		public bool llamarModificarPaciente(ENPaciente iPaciente){
            try
            {
                if (existeRut(iPaciente.rut) && validarRut(iPaciente.rut))
                {
                    return new DPaciente().modificar(iPaciente);

                }
                else
                {
                    return false;
                }


            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.StackTrace);
            }


		}
        public ENPaciente llamarBuscarPacienteRut(string rut)
        {
            return new DPaciente().buscarPacienteRut(rut);

        }

		public List<ENPaciente> llamarListarPaciente(){
			 List<ENPaciente> lista = new DPaciente().listar();
			return lista ;
		}

        public List<ENPaciente> llamarListarPorEtapa(int x)
        {
            try
            {
                List<ENPaciente> lista = new DPaciente().listarPorEtapa(x);
                return lista;

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public string llamarReturnNombre(string iRut)
        {
            return new DPaciente().returnNombre(iRut);
        }

        public string llamarReturnApellido(string iRut)
        {
            return new DPaciente().returnApellido(iRut);
        }

        public int llamarReturnEdad(string iRut)
        {
            return new DPaciente().returnEdad(iRut);
        }


        public ENPaciente llamarbuscarPacienteRut(string iRut)
        {
            return new DPaciente().buscarPacienteRut(iRut);
        }

        #region //Validar Rut
        public bool validarRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }
        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
        #endregion

        public bool existeRut(string strExisRut)
        {
            ENPaciente objPaciente = new ENPaciente();
            objPaciente = new BLPaciente().llamarbuscarPacienteRut(strExisRut);
            if (objPaciente.rut.Equals(strExisRut))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
