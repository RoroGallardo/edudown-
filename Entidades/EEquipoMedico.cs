using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EEquipoMedico : EPersona
    {
        public int id { get; set; }
        public String especialidad { get; set; }
        public int id_persona { get; set; }


        public EEquipoMedico(int cid_persona)
        {
            this.id_persona = cid_persona;
        }

        public EEquipoMedico()
        {
      
        }



    }
}
