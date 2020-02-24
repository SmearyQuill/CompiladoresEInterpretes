using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladoresInterpretes
{
    public class Transicion
    {
        public Edo origen { get; set; }
        public Edo destino { get; set; }
        public string etiqueta { get; set; }
        public Transicion()
        {
            origen = new Edo();
            destino = new Edo();
            etiqueta = "ε";
        }
    }
}
