using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
namespace DatAcc
{
    public class DDoctor
    {

        public List<ENProfesional> returnDoctorDispFecha(String tiempo, String tipotratamiento)
        {
            List<ENProfesional> aux = new List<ENProfesional>(); 

            using(EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    using (EntitiesDaBa db = new EntitiesDaBa())
                    {
                        List<PROFESIONAL> pb = (from p in db.PROFESIONAL
                                          join ag in db.AGENDABOX
                                          on p.ID equals
                                          ag.ID_PROFESIONAL
                                          where ag.FECHATRATAMIENTO != tiempo
                                          select p).ToList<PROFESIONAL>();

                        foreach (PROFESIONAL item in pb)
                        {
                            ENProfesional np = new ENProfesional();
                            np.especialidad = item.ESPECIALIDAD;
                            np.Id = Convert.ToUInt16(item.ID);
                            np.persona = new DPersona().buscarPersona(Convert.ToInt16(item.PERSONAS_PERSONAID));
                            aux.Add(np);
                        }
                    }

                    return aux;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
        }


        public List<ENProfesional> returnDoctorCo(String tiempo, String tipoTratamiento )
        {
            List<ENProfesional> praux = listarDoctores();
            List<ENProfesional> prb = returnDoctorDispFecha(tiempo, tipoTratamiento);
            List<ENProfesional> prreturn = new List<ENProfesional>();

            foreach (ENProfesional item in praux)
            {
                foreach (ENProfesional valid in prb)
                {
                    if(item.Id != valid.Id)
                    {
                        prreturn.Add(item);
                    }
                }
                
            }
            return prreturn;
        }

        public String returnDoctorCompatible(int id_profesional)
        {
            string aux = "";

            using(EntitiesDaBa bd = new EntitiesDaBa()){
                try
                {
                    aux = Convert.ToString((from per in bd.PERSONAS join 
                           pro in bd.PROFESIONAL on per.ID_PERSONA 
                           equals pro.PERSONAS_PERSONAID
                           select per.NOMBRE));
                    return aux;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
        }

        public List<ENProfesional> listarDoctores()
        {
            List<PROFESIONAL> bdlist = new List<PROFESIONAL>();
            List<ENProfesional> auxlist = new List<ENProfesional>();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    bdlist = (from p in bd.PROFESIONAL
                              select p).ToList<PROFESIONAL>();
                    foreach (PROFESIONAL item in bdlist)
                    {
                        ENProfesional np = this.buscarDoctor(Convert.ToInt16(item.ID));
                        auxlist.Add(np);
                    }
                    return auxlist;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
        }

        public ENProfesional buscarDoctor(int id)
        {
            ENProfesional np = new ENProfesional();
            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PROFESIONAL pb = (from p in bd.PROFESIONAL
                              where p.ID == id
                              select p).FirstOrDefault();

                    np.Id = Convert.ToInt16(pb.ID);
                    np.especialidad = pb.ESPECIALIDAD;
                    
                    ENPersona per = new DPersona().buscarPersona( Convert.ToInt16(pb.ID));
                    np.tipoPersona = per.tipoPersona;
                    np.rut = per.rut;
                    np.telefono = per.telefono;
                    np.nombre = per.nombre;
                    np.id = per.id;
                    np.apellido = per.apellido;
                    np.edad = per.edad;
                    np.persona = per;

                    return np;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
        }

    }

}
