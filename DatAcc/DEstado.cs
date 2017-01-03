using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
   public class DEstado
    {
        public void insertar(ENEstado eEstado)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ESTADO objEstado = new ESTADO();
                    objEstado.IDESTADO = eEstado.id;
                    objEstado.NOMBRE = eEstado.nombre;
                    objEstado.DESCRIPCION = eEstado.descripcion;
                    ctx.AddToESTADO(objEstado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void eliminar(ENEstado eEstado)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ESTADO objEstado = (from ESTADO in ctx.ESTADO
                                        where ESTADO.IDESTADO == eEstado.id
                                        select ESTADO).FirstOrDefault();
                    ctx.ESTADO.DeleteObject(objEstado);
                    ctx.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void modificar(ENEstado eEstado)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    ESTADO objEstado = (from ESTADO in ctx.ESTADO
                                        where ESTADO.IDESTADO == eEstado.id
                                        select ESTADO).FirstOrDefault();

                    objEstado.IDESTADO = eEstado.id;
                    objEstado.NOMBRE = eEstado.nombre;
                    objEstado.DESCRIPCION = eEstado.descripcion;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public List<ENEstado> listarEstado()
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENEstado> lista = new List<ENEstado>();
                    foreach (ESTADO pac in ctx.ESTADO.ToList())
                    {
                        ENEstado objEstado = new ENEstado();

                        objEstado.id = Decimal.ToInt32(pac.IDESTADO);
                        objEstado.nombre = pac.NOMBRE;
                        objEstado.descripcion = pac.DESCRIPCION;
                        lista.Add(objEstado);
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
