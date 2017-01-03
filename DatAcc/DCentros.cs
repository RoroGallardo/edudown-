using System;
using System.Collections.Generic;
using System.Linq;
    
using Entidades;
namespace DatAcc
{
    public class DCentros
    {
        public bool insertar(ENCentros eCentro)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    CENTROS objCentro = new CENTROS();
                    objCentro.IDCENTRO = eCentro.id;
                    objCentro.NOMBRE = eCentro.nombre;
                    objCentro.DIRECCION = eCentro.direccion;
                    objCentro.TELEFONO = eCentro.telefono;
                    ctx.AddToCENTROS(objCentro);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                return false;
            }
        }

        public bool eliminar(int idCentro)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    CENTROS objCentro = (from CENTROS in ctx.CENTROS
                                        where CENTROS.IDCENTRO == idCentro
                                        select CENTROS).FirstOrDefault();
                    ctx.CENTROS.DeleteObject(objCentro);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                return false;
            }
        }

        public bool modificar(ENCentros eCentro)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    CENTROS objCentro = (from CENTROS in ctx.CENTROS
                                        where CENTROS.IDCENTRO == eCentro.id
                                        select CENTROS).FirstOrDefault();

                    objCentro.IDCENTRO = eCentro.id;
                    objCentro.NOMBRE = eCentro.nombre;
                    objCentro.DIRECCION = eCentro.direccion;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                return false;
            }

        }

        public List<ENCentros> listar()
        {
            List<ENCentros> lista = new List<ENCentros>();
          
            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    List<CENTROS> bdlist = (from c in bd.CENTROS
                                        select c).ToList<CENTROS>();
                    foreach (CENTROS item in bdlist)
                    {
                        ENCentros nb = buscar(Convert.ToInt16(item.IDCENTRO));
                        lista.Add(nb);
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
     
        }

        public ENCentros buscar(int id){
            ENCentros centro = new ENCentros();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    CENTROS cb = (from c in bd.CENTROS
                              where c.IDCENTRO == id
                              select c).FirstOrDefault();


                    centro.id = Convert.ToInt16(cb.IDCENTRO);
                    centro.telefono = Convert.ToString(cb.TELEFONO);
                    centro.nombre = cb.NOMBRE;
                    centro.direccion = cb.DIRECCION;

                    return centro;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return null;
                }
            }
        }

        public int returnIdNombre(String nombre)
        {
            int centro =0;

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                     centro =Convert.ToInt16( (from c in bd.CENTROS
                                  where c.NOMBRE == nombre
                                  select c.IDCENTRO).FirstOrDefault());
                    return centro;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
                    return 0;
                }
            }
        }

    }
}
