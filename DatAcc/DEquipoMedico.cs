using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DEquipoMedico
    {
        public void insertar(ENEquipoMedico eEquipoMedico)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    EQUIPOMEDICO objEquipoMed = new EQUIPOMEDICO();
                    objEquipoMed.IDEQUIPOMEDICO = eEquipoMedico.id;
                    objEquipoMed.FECHACREACION = eEquipoMedico.fechaCreacion;
                    objEquipoMed.PERSONAS_ID_PERSONA = eEquipoMedico.persona.id;
                    objEquipoMed.DESCRIPCIONEQUIPO = eEquipoMedico.descripcion;
                    ctx.AddToEQUIPOMEDICO(objEquipoMed);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }


        }
        public void eliminar(ENEquipoMedico eEquipoMedico)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    EQUIPOMEDICO objEtapa = (from EQUIPOMEDICO in ctx.EQUIPOMEDICO
                                             where EQUIPOMEDICO.IDEQUIPOMEDICO == eEquipoMedico.id
                                             select EQUIPOMEDICO).FirstOrDefault();
                    ctx.EQUIPOMEDICO.DeleteObject(objEtapa);
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);            }

        }
        public void modificar(ENEquipoMedico eEquipoMedico)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    EQUIPOMEDICO objEtapa = (from EQUIPOMEDICO in ctx.EQUIPOMEDICO
                                             where EQUIPOMEDICO.IDEQUIPOMEDICO == eEquipoMedico.id
                                             select EQUIPOMEDICO).FirstOrDefault();

                    EQUIPOMEDICO objEquipoMed = new EQUIPOMEDICO();
                    objEquipoMed.IDEQUIPOMEDICO = eEquipoMedico.id;
                    objEquipoMed.FECHACREACION = eEquipoMedico.fechaCreacion;
                    objEquipoMed.PERSONAS_ID_PERSONA = eEquipoMedico.persona.id;
                    objEquipoMed.DESCRIPCIONEQUIPO = eEquipoMedico.descripcion;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }


        }
        public List<ENEquipoMedico> listarEquipoMed()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENEquipoMedico> lista = new List<ENEquipoMedico>();
                    foreach (EQUIPOMEDICO pac in ctx.EQUIPOMEDICO.ToList())
                    {
                        ENEquipoMedico objEquipoMed = new ENEquipoMedico();

                        objEquipoMed.id = Decimal.ToInt32(pac.IDEQUIPOMEDICO);
                        objEquipoMed.fechaCreacion = pac.FECHACREACION;
                        objEquipoMed.persona.id =Decimal.ToInt32(pac.PERSONAS_ID_PERSONA) ;
                        objEquipoMed.descripcion =pac.DESCRIPCIONEQUIPO;
                        lista.Add(objEquipoMed);
                    }
                    return lista;

                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }
        public ENEquipoMedico buscar(int id)
        {
            ENEquipoMedico eq = new ENEquipoMedico();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    EQUIPOMEDICO eb = (from e in bd.EQUIPOMEDICO
                              where e.IDEQUIPOMEDICO == id
                              select e).FirstOrDefault();

                    eq.id = Convert.ToInt32(eb.IDEQUIPOMEDICO);
                 //   eq.persona = new DPersona().buscar(Convert.ToInt32(eb.PERSONAS_ID_PERSONA) ;
                    eq.descripcion = eb.DESCRIPCIONEQUIPO;
                    return eq ;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                    throw;
                }
            }
        }
    }
}
