using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENPersona
    {
        public Int32 id { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public String telefono { get; set; }
        public ENTipoPersona tipoPersona { get; set; }

    }
}
