using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
   public class DTratamiento
    {
        public bool insertar(ENTratamiento eTratamiento)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    TRATAMIENTO objTratamiento = new TRATAMIENTO();
                    objTratamiento.IDTRATAMIENTO = eTratamiento.id+1;
                    objTratamiento.TIPOTRATAMIENTO = eTratamiento.tipoTratamiento;
                    objTratamiento.CANTIDADSESIONES = eTratamiento.cantidadSesiones;
                    objTratamiento.SESIONESFINALIZADAS = eTratamiento.sesionesFinalizadas;
                    objTratamiento.DESCRIPCION = eTratamiento.descripcion;
                    ctx.AddToTRATAMIENTO(objTratamiento);
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
        public bool eliminar(ENTratamiento eTratamiento)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    TRATAMIENTO objTratamiento = (from TRATAMIENTO in ctx.TRATAMIENTO
                                                  where TRATAMIENTO.IDTRATAMIENTO == eTratamiento.id
                                                  select TRATAMIENTO).FirstOrDefault();
                    ctx.TRATAMIENTO.DeleteObject(objTratamiento);
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
        public bool modificar(ENTratamiento eTratamiento)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    TRATAMIENTO objTratamiento = (from TRATAMIENTO in ctx.TRATAMIENTO
                                                  where TRATAMIENTO.IDTRATAMIENTO == eTratamiento.id
                                                  select TRATAMIENTO).FirstOrDefault();

                    objTratamiento.IDTRATAMIENTO = eTratamiento.id;
                    objTratamiento.TIPOTRATAMIENTO = eTratamiento.tipoTratamiento;
                    objTratamiento.CANTIDADSESIONES = eTratamiento.cantidadSesiones;
                    objTratamiento.SESIONESFINALIZADAS = eTratamiento.sesionesFinalizadas;
                    objTratamiento.DESCRIPCION = eTratamiento.descripcion;
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
        public List<ENTratamiento> listarEtapa()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENTratamiento> lista = new List<ENTratamiento>();
                    foreach (TRATAMIENTO pac in ctx.TRATAMIENTO.ToList())
                    {
                        ENTratamiento objTratamiento = new ENTratamiento();

                        objTratamiento.id = Decimal.ToInt32(pac.IDTRATAMIENTO);
                        objTratamiento.tipoTratamiento = pac.TIPOTRATAMIENTO;
                        objTratamiento.cantidadSesiones = Decimal.ToInt32(pac.CANTIDADSESIONES);
                        objTratamiento.sesionesFinalizadas = Decimal.ToInt32(pac.SESIONESFINALIZADAS);
                        objTratamiento.descripcion = pac.DESCRIPCION;

                        lista.Add(objTratamiento);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ENTratamiento buscar(int id)
        {
            ENTratamiento tra = new ENTratamiento();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    TRATAMIENTO tb = (from t in bd.TRATAMIENTO
                              where t.IDTRATAMIENTO == id
                              select t).FirstOrDefault();

                    tra.id = Convert.ToInt32(tb.IDTRATAMIENTO);
                    tra.cantidadSesiones = Convert.ToInt32(tb.CANTIDADSESIONES);
                    tra.descripcion = tb.DESCRIPCION;
                    tra.sesionesFinalizadas = Convert.ToInt32(tb.SESIONESFINALIZADAS);
                    tra.tipoTratamiento = tb.TIPOTRATAMIENTO;

                    return tra;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
