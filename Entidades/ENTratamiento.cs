using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENTratamiento
    {
        public Int32 id { get; set; }
        public String tipoTratamiento { get; set; }
        public String descripcion { get; set; }
        public int cantidadSesiones { get; set; }
        public int sesionesFinalizadas { get; set; }
    }
}
