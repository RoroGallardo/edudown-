using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DatAcc;

namespace Negocio
{
    public class BLDoctor
    {
        public List<ENProfesional> llamarRDoctorDispFecha(String iTiempo, String iTipotratamiento)
        {
            return new DDoctor().returnDoctorDispFecha(iTiempo, iTipotratamiento);
        }

        //public List<ENProfesional> llamarRDoctorDispFecha(String iTiempo, String iTipotratamiento)
        //{
        //    List<ENProfesional> lista = new DDoctor().returnDoctorDispFecha(iTiempo, iTipotratamiento);
        //    return lista;
        //}

        public List<ENProfesional> llamarRDoctorCo(String iTiempo, String iTipotratamiento)
        {
            return new DDoctor().returnDoctorCo(iTiempo, iTipotratamiento);
        }


        public String llamarRDoctorCompatible(int iId_profesional)
        {
            return new DDoctor().returnDoctorCompatible(iId_profesional);
        }


        public List<ENProfesional> llamarListarDoctores()
        {
            List<ENProfesional> lista = new DDoctor().listarDoctores();
            return lista;
        }

        public List<String> doctoresRuts()
        {
            List<ENProfesional> lista = new DDoctor().listarDoctores();
            List<String> listaAux = new List<String>();

            foreach (ENProfesional item in lista)
            {
                listaAux.Add(item.rut);
            }
            return listaAux;
        }

        public ENProfesional returnDocPorNombre(string nombre)
        {
            ENProfesional aux = new ENProfesional();
            List<ENProfesional> listPro = llamarListarDoctores();

            foreach (ENProfesional item in listPro)
            {
                if(item.persona.apellido+ " " + item.persona.nombre == nombre){
                    aux = item;
                }
            }
            return aux;
        }

        public ENProfesional llamarBuscarDoctor(int iId)
        {
            return new DDoctor().buscarDoctor(iId);
        }

    }
}
