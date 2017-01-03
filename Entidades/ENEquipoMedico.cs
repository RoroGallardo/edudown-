using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENEquipoMedico
    {
        public Int32 id { get; set; }
        public DateTime fechaCreacion { get; set; }
        public String descripcion { get; set; }
        public ENPersona persona { get; set; }
    }
}
