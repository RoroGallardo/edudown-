using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DPeriodo
    {
        public void insertar(ENPeriodo ePeriodo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PERIODO objPeriodo = new PERIODO();
                    objPeriodo.IDPERIODO = ePeriodo.id;
                    objPeriodo.DESDE = ePeriodo.desde;
                    objPeriodo.HASTA = ePeriodo.hasta;
                    ctx.AddToPERIODO(objPeriodo);
                    ctx.SaveChanges();
                }
            }
        catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void eliminar(ENPeriodo ePeriodo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PERIODO objPeriodo = (from PERIODO in ctx.PERIODO
                                          where PERIODO.IDPERIODO == ePeriodo.id
                                          select PERIODO).FirstOrDefault();
                    ctx.PERIODO.DeleteObject(objPeriodo);
                    ctx.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void modificar(ENPeriodo ePeriodo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {

                    PERIODO objPeriodo = (from PERIODO in ctx.PERIODO
                                          where PERIODO.IDPERIODO == ePeriodo.id
                                          select PERIODO).FirstOrDefault();

                    objPeriodo.IDPERIODO = ePeriodo.id;
                    objPeriodo.DESDE = ePeriodo.desde;
                    objPeriodo.HASTA = ePeriodo.hasta;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public List<ENPeriodo> listarPeriodo()
        {

            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENPeriodo> lista = new List<ENPeriodo>();
                    foreach (PERIODO pac in ctx.PERIODO.ToList<PERIODO>())
                    {
                        ENPeriodo objPeriodo = new ENPeriodo();

                        objPeriodo.id = Decimal.ToInt32(pac.IDPERIODO);
                        objPeriodo.desde = pac.DESDE;
                        objPeriodo.hasta = pac.HASTA;
                        lista.Add(objPeriodo);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int count()
        {
            try
            {
                    return listarPeriodo().Count+1;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ENPeriodo buscar(int id)
        {
            ENPeriodo per = new ENPeriodo();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PERIODO pb = (from p in bd.PERIODO
                              where p.IDPERIODO == id
                              select p).FirstOrDefault();

                    per.id =Convert.ToInt32(pb.IDPERIODO);
                    per.desde = pb.DESDE;
                    per.hasta = pb.HASTA;

                    return per;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
