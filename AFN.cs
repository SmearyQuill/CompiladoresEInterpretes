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

        public AFN(AFN izquierda, AFN derecha, string accion)
        {
            LEstados = new List<Edo>();
            LTransiciones = new List<Transicion>();
            if (accion == "*")
            {
                Edo inicio = new Edo();
                Edo aceptacion = new Edo();

                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                foreach (Edo e in izquierda.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        inicio = e;
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        aceptacion = e;
                    }
                }

                Transicion paTraz = new Transicion();
                paTraz.origen = aceptacion;
                paTraz.destino = inicio;
                this.LTransiciones.Add(paTraz);

                inicio = new Edo();
                aceptacion = new Edo();
                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                Transicion epcilon = new Transicion();
                epcilon.origen = inicio;
                epcilon.destino = aceptacion;
                this.LTransiciones.Add(epcilon);

                foreach (Edo e in izquierda.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        Transicion nuevaPrincipio = new Transicion();
                        nuevaPrincipio.origen = inicio;
                        nuevaPrincipio.destino = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaPrincipio);
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        Transicion nuevaFinal = new Transicion();
                        nuevaFinal.destino = aceptacion;
                        nuevaFinal.origen = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaFinal);
                    }
                }
                this.LEstados.Add(inicio);
                this.LEstados.Add(aceptacion);
                this.LTransiciones.AddRange(izquierda.LTransiciones);
                this.LEstados.AddRange(izquierda.LEstados);
            }
            if (accion == "+")
            {
                Edo inicio = new Edo();
                Edo aceptacion = new Edo();

                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                foreach (Edo e in izquierda.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        inicio = e;
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        aceptacion = e;
                    }
                }

                Transicion paTraz = new Transicion();
                paTraz.origen = aceptacion;
                paTraz.destino = inicio;
                this.LTransiciones.Add(paTraz);

                inicio = new Edo();
                aceptacion = new Edo();
                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                foreach (Edo e in izquierda.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        Transicion nuevaPrincipio = new Transicion();
                        nuevaPrincipio.origen = inicio;
                        nuevaPrincipio.destino = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaPrincipio);
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        Transicion nuevaFinal = new Transicion();
                        nuevaFinal.destino = aceptacion;
                        nuevaFinal.origen = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaFinal);
                    }
                }
                this.LEstados.Add(inicio);
                this.LEstados.Add(aceptacion);
                this.LTransiciones.AddRange(izquierda.LTransiciones);
                this.LEstados.AddRange(izquierda.LEstados);
            }
            if (accion == "?")
            {
                Edo inicio = new Edo();
                Edo aceptacion = new Edo();

                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                Transicion epcilon = new Transicion();
                epcilon.origen = inicio;
                epcilon.destino = aceptacion;
                this.LTransiciones.Add(epcilon);

                foreach (Edo e in izquierda.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        Transicion nuevaPrincipio = new Transicion();
                        nuevaPrincipio.origen = inicio;
                        nuevaPrincipio.destino = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaPrincipio);
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        Transicion nuevaFinal = new Transicion();
                        nuevaFinal.destino = aceptacion;
                        nuevaFinal.origen = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaFinal);
                    }
                }
                this.LEstados.Add(inicio);
                this.LEstados.Add(aceptacion);
                this.LTransiciones.AddRange(izquierda.LTransiciones);
                this.LEstados.AddRange(izquierda.LEstados);
            }
            if (accion == "union")
            {
                Edo inicio = new Edo();
                Edo aceptacion = new Edo();

                inicio.tipo = "Comienzo";
                aceptacion.tipo = "Aceptacion";

                foreach (Transicion t in derecha.LTransiciones)
                {
                    this.LTransiciones.Add(t);
                }
                foreach (Edo e in derecha.LEstados)
                {
                    this.LEstados.Add(e);
                }
                foreach (Transicion t in izquierda.LTransiciones)
                {
                    this.LTransiciones.Add(t);
                }
                foreach (Edo e in izquierda.LEstados)
                {
                    this.LEstados.Add(e);
                }
                foreach (Edo e in this.LEstados)
                {
                    if (e.tipo == "Comienzo")
                    {
                        Transicion nuevaPrincipio = new Transicion();
                        nuevaPrincipio.origen = inicio;
                        nuevaPrincipio.destino = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaPrincipio);
                    }
                    else if (e.tipo == "Aceptacion")
                    {
                        Transicion nuevaFinal = new Transicion();
                        nuevaFinal.destino = aceptacion;
                        nuevaFinal.origen = e;
                        e.tipo = "Inicio";
                        this.LTransiciones.Add(nuevaFinal);
                    }
                }
                this.LEstados.Add(inicio);
                this.LEstados.Add(aceptacion);
            }
            if (accion == "concatenacion")
            {
                LEstados = new List<Edo>();
                LTransiciones = new List<Transicion>();
                int comienzo;

                //busca el estado donde comiensa el automata de la derecha
                for (comienzo = 0; comienzo < derecha.LEstados.Count; comienzo++)
                {
                    if (derecha.LEstados[comienzo].tipo == "Comienzo")
                    {
                        //busca las tranciciones del automata izquierdo que tengan como destino un estado de aceptacion 
                        //posteriormente si se encuentra pasan a tener un nuevo estado destino, que es el estado donde comienza el automata derecho
                        for (int i = izquierda.LTransiciones.Count - 1; i >= 0; i--)
                        {
                            if (izquierda.LTransiciones[i].destino.tipo == "Aceptacion")
                            {
                                izquierda.LTransiciones[i].destino = derecha.LEstados[comienzo];
                            }
                        }
                        break;
                    }
                }

                //el donde antes comenzaba el automata de la derecha ahora se convierte 
                //en un estado de inicio mas del automata de la iquierda
                derecha.LEstados[comienzo].tipo = "Inicio";

                //busca el estado de aceptacion del automata de la izquierda  lo elimina
                for (int i = 0; i < izquierda.LEstados.Count; i++)
                {
                    if (izquierda.LEstados[i].tipo == "Aceptacion")
                    {
                        izquierda.LEstados.RemoveAt(i);
                        break;
                    }
                }
                //agrega todos los estados de la automata de la derecha
                foreach (Edo e in derecha.LEstados)
                    this.LEstados.Add(e);
                //agrega todas las transiciones del automata de la derecha
                foreach (Transicion t in derecha.LTransiciones)
                    this.LTransiciones.Add(t);
                //agrega todos los estados de la automata de la izq
                foreach (Edo e in izquierda.LEstados)
                    this.LEstados.Add(e);
                //agrega todas las transiciones del automata de la izquierda
                foreach (Transicion t in izquierda.LTransiciones)
                    this.LTransiciones.Add(t);
            }
        }

        public void automataSimple(string transicion)
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
            nueva.etiqueta = transicion;
            LTransiciones.Add(nueva);
        }

    }
}
