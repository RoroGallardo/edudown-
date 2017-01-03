using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EAgendarHora
    {
        public int id { get; set; }
        public DateTime fechaTratamiento { get; set; }
        public DateTime tiempoTratamiento { get; set; }
        public ENBox box { get; set; }
        public ENFichaPaciente fichapaciente { get; set; }
        public ENEquipoMedico equipomedico { get; set; }
        public ENProfesional doctor { get; set; }
        public ENPeriodo periodo { get; set; }
        public ENTratamiento tratamiento { get; set; }
        public ENProfesional enfermera { get; set; }
        public String tipo { get; set; }




    }
}
