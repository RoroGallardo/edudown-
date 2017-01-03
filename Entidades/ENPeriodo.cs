using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENPeriodo
    {
        public Int32 id { get; set; }
        public String desde{ get; set; }
        public String hasta { get; set; }
     

        public ENPeriodo()
        {
            

        }
        public ENPeriodo(int id, String desde , String hasta)
        {
            this.id = id;
            this.desde = desde;
            this.hasta = hasta;
        }   
    }
}
