using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class EPersona
    {

        public int id { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public int telefono { get; set; }

        public EPersona()
        {

        }

    }
}
