using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladoresInterpretes
{
    public class Edo
    {
        public int id { get; set; }
        public List<List<int>> conjuntoRelaciones;
        public string tipo { get; set; }//Estado de "Inicio" o "Aceptacion", Comienzo(solo uno)
        //public bool comienzo { get; set; }
        public Edo()
        {
            conjuntoRelaciones = new List<List<int>>();
            id = -1;
            tipo = "Inicio";
            //comienzo = true;
        }
    }
}
