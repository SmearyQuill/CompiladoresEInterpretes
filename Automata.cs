using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladoresInterpretes
{
    public class Automata
    {
        List<AFN> pilaR;

        public Automata()
        {
            pilaR = new List<AFN>();
        }

        public void construirAFN(string exprecionPostfija)
        {
            foreach(char caracter in exprecionPostfija)
            {
                if(caracter == '*')//(unario)
                {

                }
                else if (caracter == '+')//(unario)
                {

                }
                else if (caracter == '?')//(unario)
                {

                }
                else if (caracter == '|')//Union de automatas (binario)
                {
                    unionAFN();
                }
                else if (caracter == '&')//Concatenacion de automatas (binario)
                {
                    concatenaAFN();
                }
                else
                {
                    AFN nuevo = new AFN();
                    nuevo.automataSimple(caracter.ToString());
                    pilaR.Add(nuevo);
                }
            }
        }


        void unionAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];

            Edo inicio = new Edo();
            Edo aceptacion = new Edo();

            inicio.tipo = "Comienzo";
            aceptacion.tipo = "Aceptacion";

            foreach(Transicion t in derecha.LTransiciones)
            {
                izquierda.LTransiciones.Add(t);
            }

            foreach(Edo e in derecha.LEstados)
            {
                izquierda.LEstados.Add(e);
            }

            

            foreach(Edo e in izquierda.LEstados)
            {
                if(e.tipo == "Comienzo")
                {
                    Transicion nuevaPrincipio = new Transicion();
                    nuevaPrincipio.origen = inicio;
                    nuevaPrincipio.destino = e;
                    e.tipo = "Inicio";
                    izquierda.LTransiciones.Add(nuevaPrincipio);
                }
                else if(e.tipo == "Aceptacion")
                {
                    Transicion nuevaFinal = new Transicion();
                    nuevaFinal.destino = aceptacion;
                    nuevaFinal.origen = e;
                    e.tipo = "Inicio";
                    izquierda.LTransiciones.Add(nuevaFinal);
                }
            }

            izquierda.LEstados.Add(inicio);
            izquierda.LEstados.Add(aceptacion);

            pilaR.RemoveAt(topePila);
            pilaR[topePila - 1] = izquierda;
        }
        void concatenaAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];

            int comienzo;

            //busca el estado donde comiensa el automata de la derecha
            for(comienzo = 0; comienzo < derecha.LEstados.Count; comienzo++)
            {
                if(derecha.LEstados[comienzo].tipo == "Comienzo")
                {
                    //busca las tranciciones del automata izquierdo que tengan como destino un estado de aceptacion 
                    //posteriormente si se encuentra pasan a tener un nuevo estado destino, que es el estado donde coienza el automata derecho
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

            //el donde antes comensaba el automata de la derecha ahora se convierte 
            //en un estado de inicio mas del automata de la iquierda
            derecha.LEstados[comienzo].tipo = "Inicio";

            //busca el estado de aceptacion del automata de la izquierda  lo elimina
            for(int i = 0; i < izquierda.LEstados.Count; i++)
            {
                if(izquierda.LEstados[i].tipo == "Aceptacion")
                {
                    izquierda.LEstados.RemoveAt(i);
                    break;
                }
            }

            //agrega todos los estados de la automata de la derecha al de la izquierda
            foreach (Edo e in derecha.LEstados)
                izquierda.LEstados.Add(e);
            //agrega todas las transiciones del automata de la derecha al de la izquierda
            foreach (Transicion t in derecha.LTransiciones)
                izquierda.LTransiciones.Add(t);

            pilaR.RemoveAt(topePila);
            pilaR[topePila - 1] = izquierda;

        }
    }
}
