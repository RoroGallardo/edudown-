using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EUsuario
    {

        public int Id { get; set; }
        public String  username { get; set; }
        public String password { get; set; }
        public int id_persona { get; set; }
        public int id_tipousuario { get; set; } 

        public EUsuario()
        {


        }

    }
}
