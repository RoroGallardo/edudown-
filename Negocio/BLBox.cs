using Entidades;
using DatAcc;
using System.Collections.Generic;
using System;

namespace Negocio
{
	public class BLBox{


        public bool llamarREstadoAgendado(string iTiempo, string iTipotratamiento, int iBox_id)
        {
            return new DBox().returnEstaAgendado(iTiempo, iTipotratamiento, iBox_id);
        }

        public bool llamarAgregarBox(ENBox box)
        {
            return new DBox().agregarBox(box);
        }

        public List<ENBox> llamarListarBoxs()
        {
            List<ENBox> lista = new DBox().listarBoxs();
            return lista;
        }

        public List<ENBox> llamarListarOcupados(string iTiempo, string iTtipotratamiento)
        {
            return new DBox().listarOcupados(iTiempo, iTtipotratamiento);
        }

        public List<ENBox> ListarRestoLibres(string iTiempo, string iTtipotratamiento)
        {

            try
            {
                DBox db = new DBox();
                List<ENBox> aux = new List<ENBox>();
                List<ENBox> boxlist = db.listarBoxs();
                List<ENBox> listOcupados = db.listarOcupados(iTiempo, iTtipotratamiento);


                foreach (ENBox item in listOcupados)
                {
                    foreach (ENBox em in boxlist)
                    {
                        if (item.id != em.id)
                        {
                            ENBox nb = db.buscarBox(Convert.ToInt16(em.id));
                            aux.Add(nb);
                        }

                    }

                }

                return aux;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ENBox> llamarListarLibres(string iTiempo, string iTtipotratamiento)
        {
            return new DBox().listarLibres(iTiempo, iTtipotratamiento);
        }

        public ENBox llamarBuscarBox(int iID)
        {
            return new DBox().buscarBox(iID);

        }

        public bool llamarEliminarBox(int iID)
        {
            return new DBox().eliminar(iID);

        }
        public bool llamarModificar(ENBox box)
        {
            return new DBox().modificar(box);
        }

     }
}

