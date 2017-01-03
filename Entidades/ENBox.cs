using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENBox
    {
        public Int32 id { get; set; }
        public int tamaño { get; set; }
        public String tipoBox { get; set; }
        public String descripcion { get; set; }
        public ENCentros centroMedico { get; set; }
        public ENEstado estado { get; set; }
        public ENPaqueteInsumo paqueteInsumo { get; set; }


    }
}
