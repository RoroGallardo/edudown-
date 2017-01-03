using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DatAcc
{
    public class DPersona
    {
        public ENPersona buscarPersona(int id)
        {
            ENPersona pa = new ENPersona();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    PERSONAS bp = (from b in bd.PERSONAS
                                   where b.ID_PERSONA == id
                                   select b).FirstOrDefault();

                    pa.rut = Convert.ToString(bp.RUT);
                    pa.nombre = bp.NOMBRE;
                    pa.edad = Convert.ToInt16(bp.EDAD);
                    pa.telefono = Convert.ToString(bp.TELEFONO);
                    ENTipoPersona tp = new ENTipoPersona();
                    tp.id = 1; tp.profesion="medico";
                    pa.tipoPersona = tp;// SOLUCIONAR
                    
                    pa.apellido = bp.APELLIDO;
                    return pa;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;

                }
            }

        }

        public int returnIdPersona(string rut)
        {
            int pa = 0;

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    pa = Convert.ToInt16((from b in bd.PERSONAS
                                          where b.RUT == rut
                                          select b.ID_PERSONA).FirstOrDefault());
                    return pa;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;

                }
            }
        }
    }
}
