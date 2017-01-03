using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DPaqueteInsumo
    {
        public void insertar(ENPaqueteInsumo ePaqueteInsumo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PAQUETEINSUMO objPInsumo = new PAQUETEINSUMO();

                    objPInsumo.IDPAQUETEINSUMO = ePaqueteInsumo.id;
                    objPInsumo.NOMBRE = ePaqueteInsumo.nombre;
                    objPInsumo.CANTIDAD = ePaqueteInsumo.cantidad;
                    objPInsumo.DESCRIPCION = ePaqueteInsumo.descripcion;


                    ctx.AddToPAQUETEINSUMO(objPInsumo);
                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public void eliminar(ENPaqueteInsumo ePaqueteInsumo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PAQUETEINSUMO objPInsumo = (from PAQUETEINSUMO in ctx.PAQUETEINSUMO
                                                where PAQUETEINSUMO.IDPAQUETEINSUMO == ePaqueteInsumo.id
                                                select PAQUETEINSUMO).FirstOrDefault();
                    ctx.PAQUETEINSUMO.DeleteObject(objPInsumo);
                    ctx.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public void modificar(ENPaqueteInsumo ePaqueteInsumo)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    PAQUETEINSUMO objPInsumo = (from PAQUETEINSUMO in ctx.PAQUETEINSUMO
                                                where PAQUETEINSUMO.IDPAQUETEINSUMO == ePaqueteInsumo.id
                                                select PAQUETEINSUMO).FirstOrDefault();

                    objPInsumo.IDPAQUETEINSUMO = ePaqueteInsumo.id;
                    objPInsumo.NOMBRE = ePaqueteInsumo.nombre;
                    objPInsumo.CANTIDAD = ePaqueteInsumo.cantidad;
                    objPInsumo.DESCRIPCION = ePaqueteInsumo.descripcion;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public List<ENPaqueteInsumo> listarPaqueteIns()
        {
            using (var ctx = new EntitiesDaBa())
            {
                List<ENPaqueteInsumo> lista = new List<ENPaqueteInsumo>();
                foreach (PAQUETEINSUMO pac in ctx.PAQUETEINSUMO.ToList())
                {
                    ENPaqueteInsumo objPInsumo = new ENPaqueteInsumo();
                    objPInsumo.id = Decimal.ToInt32(pac.IDPAQUETEINSUMO);
                    objPInsumo.nombre = pac.NOMBRE;
                    objPInsumo.cantidad = Decimal.ToInt32(pac.CANTIDAD);
                    objPInsumo.descripcion = pac.DESCRIPCION;
                    lista.Add(objPInsumo);
                }

                return lista;
            }
        }
    }
}
