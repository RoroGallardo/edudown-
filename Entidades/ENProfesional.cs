using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ENProfesional : ENPersona
    {
        public int Id { get; set; }
        public String especialidad { get; set; }
        public ENPersona persona { get; set; }

    }
}
