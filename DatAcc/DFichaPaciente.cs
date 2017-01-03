using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
    
namespace DatAcc
{
    public class DFichaPaciente
    {
        public bool insertar(ENFichaPaciente eFichaPaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    FICHAPACIENTE objFichaPac = new FICHAPACIENTE();
                    objFichaPac.IDFICHAPACIENTE = eFichaPaciente.id;
                    objFichaPac.FECHAINICIO = eFichaPaciente.fechaInicio;
                    objFichaPac.TRATAMIENTO_IDTRATAMIENTO = eFichaPaciente.tratamiento.id;
                    objFichaPac.PATOLOGIA_IDPATOLOGIA = eFichaPaciente.patologia.id;
                    objFichaPac.PACIENTE_RUTPACIENTE = eFichaPaciente.rut;
                    ctx.AddToFICHAPACIENTE(objFichaPac);
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
        public bool eliminar(ENFichaPaciente eFichaPaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    FICHAPACIENTE objFichaPac = (from FICHAPACIENTE in ctx.FICHAPACIENTE
                                                 where FICHAPACIENTE.IDFICHAPACIENTE == eFichaPaciente.id
                                                 select FICHAPACIENTE).FirstOrDefault();
                    ctx.FICHAPACIENTE.DeleteObject(objFichaPac);
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
        public bool modificar(ENFichaPaciente eFichaPaciente)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    FICHAPACIENTE objFichaPac = (from FICHAPACIENTE in ctx.FICHAPACIENTE
                                                 where FICHAPACIENTE.IDFICHAPACIENTE == eFichaPaciente.id
                                                 select FICHAPACIENTE).FirstOrDefault();
                    ctx.FICHAPACIENTE.DeleteObject(objFichaPac);

                    objFichaPac.IDFICHAPACIENTE = eFichaPaciente.id;
                    objFichaPac.FECHAINICIO = new DateTime();
                    objFichaPac.TRATAMIENTO_IDTRATAMIENTO = eFichaPaciente.tratamiento.id;
                    objFichaPac.PATOLOGIA_IDPATOLOGIA = eFichaPaciente.patologia.id;
                    objFichaPac.PACIENTE_RUTPACIENTE = eFichaPaciente.rut;
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
        public List<ENFichaPaciente> listarFichaPaciente()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENFichaPaciente> lista = new List<ENFichaPaciente>();
                    foreach (FICHAPACIENTE  fPac in ctx.FICHAPACIENTE.ToList())
                    {
                        ENFichaPaciente objFicha = new ENFichaPaciente();
                        

                        objFicha.id = Convert.ToInt32(fPac.IDFICHAPACIENTE);

                        objFicha.patologia = new DPatologia().buscar(Convert.ToInt32(fPac.PATOLOGIA_IDPATOLOGIA));
                        objFicha.tratamiento = new DTratamiento().buscar(Convert.ToInt32(fPac.TRATAMIENTO_IDTRATAMIENTO));
                        

                        objFicha.rut = fPac.PACIENTE_RUTPACIENTE;
                        objFicha.fechaInicio = fPac.FECHAINICIO;
                   

                        lista.Add(objFicha);
                    }
                   
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ENFichaPaciente buscarFichaID(int id)
        {
            ENFichaPaciente fi = new ENFichaPaciente();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    FICHAPACIENTE fb = (from f in bd.FICHAPACIENTE
                              where f.IDFICHAPACIENTE == id
                              select f).FirstOrDefault();

                    fi.fechaInicio = fb.FECHAINICIO;
                    fi.id = Convert.ToInt32(fb.IDFICHAPACIENTE);
                    fi.patologia = new DPatologia().buscar(Convert.ToInt32(fb.PATOLOGIA_IDPATOLOGIA));
                    fi.tratamiento = new DTratamiento().buscar(Convert.ToInt32(fb.TRATAMIENTO_IDTRATAMIENTO));
                    fi.rut = fb.PACIENTE_RUTPACIENTE;

                    return fi;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public ENFichaPaciente buscarFichaPaciente(String rut)
        {
            ENFichaPaciente efb = new ENFichaPaciente();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    FICHAPACIENTE fp = (from f in bd.FICHAPACIENTE
                                        join pa in bd.PACIENTE
                                        on f.PACIENTE_RUTPACIENTE
                                        equals pa.RUTPACIENTE
                                        where pa.RUTPACIENTE == rut
                                        select f).FirstOrDefault();

                    efb.fechaInicio = fp.FECHAINICIO;
                    efb.id = Convert.ToInt16(fp.IDFICHAPACIENTE);
                //    efb.paciente = new DPaciente().buscarPacienteRut(fp.PACIENTE_RUTPACIENTE);
                    efb.patologia = new DPatologia().buscar(Convert.ToInt16(fp.PATOLOGIA_IDPATOLOGIA));
                    efb.tratamiento = new DTratamiento().buscar(Convert.ToInt16(fp.TRATAMIENTO_IDTRATAMIENTO));

                    //FALTA RETORNAR LA PERSONA COMPLETA
                    return efb;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }   
    }
}
