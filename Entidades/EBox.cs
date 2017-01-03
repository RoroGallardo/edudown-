using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EBox
    {
        public int idbox { get; set; }
        public String tamaño { get; set; }
        public String  tipo { get; set; }
        public String descripcion { get; set; }
        public int id_paqueteInsumo { get; set; }
        public int id_centro { get; set; }
        public int id_estado { get; set; }
    }
}
