using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;

namespace DatAcc
{
    public class DPaciente
    {


        public bool insertar(ENPaciente ePaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PACIENTE objPaciente = new PACIENTE();
                    objPaciente.APELLIDO = ePaciente.apellido;
                    objPaciente.NOMBRE = ePaciente.nombre;
                    objPaciente.EDAD = ePaciente.edad;
                    objPaciente.ETAPA_IDETAPA = ePaciente.etapa;
                    objPaciente.RUTPACIENTE = ePaciente.rut;
                   

                    ctx.AddToPACIENTE(objPaciente);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

                throw new Exception(ex.Message);
            }


        }
        public bool eliminar(ENPaciente ePaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PACIENTE objPaciente = (from p in ctx.PACIENTE
                                          where p.RUTPACIENTE == ePaciente.rut
                                          select p).FirstOrDefault();
                    ctx.PACIENTE.DeleteObject(objPaciente);
                    ctx.SaveChanges();


                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

                throw new Exception(ex.Message);
            }


        }
        public bool modificar(ENPaciente ePaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {

                    PACIENTE pa = (from p in ctx.PACIENTE
                                   where p.RUTPACIENTE == ePaciente.rut
                                   select p).FirstOrDefault();

                    pa.NOMBRE = ePaciente.nombre;
                    pa.APELLIDO = ePaciente.apellido;
                    pa.EDAD = ePaciente.edad;
                    pa.ETAPA_IDETAPA = ePaciente.etapa;
                    


                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }


        }
        public String returnNombre(String rut)
        {

            String aux = "";


            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    aux = (from p in bd.PACIENTE
                           where p.RUTPACIENTE == rut
                           select p.NOMBRE).FirstOrDefault();
                   
                    return aux;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public String returnApellido(String rut)
        {
            String aux = "";

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    aux = (from p in bd.PACIENTE
                           where p.RUTPACIENTE == rut
                           select p.APELLIDO).FirstOrDefault();
                    
                    return aux;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int returnEdad(String rut)
        {
            int aux;
            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PACIENTE pa = (from p in bd.PACIENTE
                           where p.RUTPACIENTE == rut
                           select p).FirstOrDefault();
                    aux = Convert.ToInt16(pa.EDAD);
                    return aux;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<ENPaciente> listar()
        {
            List<PACIENTE> bdlist = new List<PACIENTE>();
            List<ENPaciente> auxlist = new List<ENPaciente>();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    bdlist = (from b in bd.PACIENTE
                              select b).ToList<PACIENTE>();
                    foreach (PACIENTE item in bdlist)
                    {
                        ENPaciente np = this.buscarPacienteRut(Convert.ToString(item.RUTPACIENTE));
                        auxlist.Add(np);
                    }
                    return auxlist;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<ENPaciente> listarPorEtapa(int x)
        {
            List<PACIENTE> bdlist = new List<PACIENTE>();
            List<ENPaciente> auxlist = new List<ENPaciente>();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    
                    bdlist = (from b in bd.PACIENTE where b.ETAPA_IDETAPA == x
                              select b).ToList<PACIENTE>();
                    foreach (PACIENTE item in bdlist)
                    {
                        ENPaciente np = this.buscarPacienteRut(Convert.ToString(item.RUTPACIENTE));
                        auxlist.Add(np);
                    }
                    return auxlist;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public ENPaciente buscarPacienteRut(String rut)
        {
            ENPaciente pa = new ENPaciente();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PACIENTE bp = (from b in bd.PACIENTE
                              where b.RUTPACIENTE == rut
                              select b).FirstOrDefault();

                    pa.rut = Convert.ToString(bp.RUTPACIENTE);
                    pa.nombre = bp.NOMBRE;
                    //pa.etapa = Convert.ToInt32(bp.ETAPA_IDETAPA);
                    pa.apellido = bp.APELLIDO;
                    pa.edad = Convert.ToInt32(bp.EDAD);
                

                    //FALTA RETORNAR LA PERSONA COMPLETA


                    return pa;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

       
    }
}