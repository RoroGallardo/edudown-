using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DEtapa
    {
        public void insertar(ENEtapa eEtapa)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ETAPA objEtapa = new ETAPA();
                    objEtapa.IDETAPA = eEtapa.id;
                    objEtapa.NOMBRE = eEtapa.nombre;
                    objEtapa.DESCRIPCION = eEtapa.descripcion;
                    ctx.AddToETAPA(objEtapa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void eliminar(ENEtapa eEtapa)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ETAPA objEtapa = (from ETAPA in ctx.ETAPA
                                      where ETAPA.IDETAPA == eEtapa.id
                                      select ETAPA).FirstOrDefault();
                    ctx.ETAPA.DeleteObject(objEtapa);
                    ctx.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public void modificar(ENEtapa eEtapa)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ETAPA objEtapa = (from ETAPA in ctx.ETAPA
                                      where ETAPA.IDETAPA == eEtapa.id
                                      select ETAPA).FirstOrDefault();

                    objEtapa.IDETAPA = eEtapa.id;
                    objEtapa.NOMBRE = eEtapa.nombre;
                    objEtapa.DESCRIPCION = eEtapa.descripcion;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public List<ENEtapa> listarEtapa()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENEtapa> lista = new List<ENEtapa>();
                    foreach (ETAPA pac in ctx.ETAPA.ToList())
                    {
                        ENEtapa objEtapa = new ENEtapa();

                        objEtapa.id = Decimal.ToInt32(pac.IDETAPA);
                        objEtapa.nombre = pac.NOMBRE;
                        objEtapa.descripcion = pac.DESCRIPCION;
                        lista.Add(objEtapa);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
      
    }
}
