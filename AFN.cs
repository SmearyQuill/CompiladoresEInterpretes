using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladoresInterpretes
{
    public class AFN
    { //φ phi
        public List<Edo> LEstados;
        public List<Transicion> LTransiciones;
        public AFN()
        {
            LEstados = new List<Edo>();
            LTransiciones = new List<Transicion>();
        }

        public void automataSimple(string trancicion)
        {
            Edo origen = new Edo();
            Edo destino = new Edo();
            origen.tipo = "Comienzo";
            destino.tipo = "Aceptacion";
            LEstados.Add(origen);
            LEstados.Add(destino);

            Transicion nueva = new Transicion();
            nueva.origen = origen;
            nueva.destino = destino;
            nueva.etiqueta = trancicion;
        }
    }
}
