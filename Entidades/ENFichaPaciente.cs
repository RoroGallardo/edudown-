using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENFichaPaciente
    {
        public Int32 id { get; set; }
        public DateTime fechaInicio { get; set; }
        public ENTratamiento tratamiento { get; set; }
        public String rut { get; set; }
        public ENPatologia patologia { get; set; }
       // public ENPaciente paciente { get; set; }

    }
}
