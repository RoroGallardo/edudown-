using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DPatologia
    {
        public void insertar(ENPatologia ePatologia)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {

                    PATOLOGIA objPatologia = new PATOLOGIA();
                    objPatologia.IDPATOLOGIA = ePatologia.id;
                    objPatologia.NOMBRE = ePatologia.nombre;
                    objPatologia.DESCRIPCION = ePatologia.descripcion;
                    ctx.AddToPATOLOGIA(objPatologia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void eliminar(ENPatologia ePatologia)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PATOLOGIA objPatologia = (from PATOLOGIA in ctx.PATOLOGIA
                                              where PATOLOGIA.IDPATOLOGIA == ePatologia.id
                                              select PATOLOGIA).FirstOrDefault();
                    ctx.PATOLOGIA.DeleteObject(objPatologia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void modificar(ENPatologia ePatologia)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PATOLOGIA objPatologia = (from PATOLOGIA in ctx.PATOLOGIA
                                              where PATOLOGIA.IDPATOLOGIA == ePatologia.id
                                              select PATOLOGIA).FirstOrDefault();
                    objPatologia.IDPATOLOGIA = ePatologia.id;
                    objPatologia.NOMBRE = ePatologia.nombre;
                    objPatologia.DESCRIPCION = ePatologia.descripcion;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<ENPatologia> listar()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENPatologia> lista = new List<ENPatologia>();
                    foreach (PATOLOGIA pac in ctx.PATOLOGIA.ToList())
                    {
                        ENPatologia objPatologia = new ENPatologia();

                        objPatologia.id = Decimal.ToInt32(pac.IDPATOLOGIA);
                        objPatologia.nombre = pac.NOMBRE;
                        objPatologia.descripcion = pac.DESCRIPCION;
                        lista.Add(objPatologia);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ENPatologia buscar(int id)
        {
            ENPatologia pa = new ENPatologia();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PATOLOGIA pb = (from p in bd.PATOLOGIA
                              where p.IDPATOLOGIA== id
                              select p).FirstOrDefault();

                    pa.id = Convert.ToInt32(pb.IDPATOLOGIA);
                    pa.nombre = pb.NOMBRE;
                    pa.descripcion = pb.DESCRIPCION;

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
