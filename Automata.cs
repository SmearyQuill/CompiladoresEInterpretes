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
                    cerraduraKleenAFN();
                }
                else if (caracter == '+')//(unario)
                {
                    cerraduraPositivaAFN();
                }
                else if (caracter == '?')//(unario)
                {
                    ceroUnaInstanciaAFN();
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

        public void cerraduraKleenAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];

            AFN nuevo = new AFN(tope, null, "*");

            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        public void cerraduraPositivaAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];

            AFN nuevo = new AFN(tope, null, "+");

            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        public void ceroUnaInstanciaAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];

            AFN nuevo = new AFN(tope, null, "?");

            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        void unionAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];

            AFN nuevo = new AFN(izquierda, derecha, "union");

            pilaR.RemoveAt(topePila);
            pilaR.RemoveAt(topePila - 1);
            pilaR.Add(nuevo);
        }
        void concatenaAFN()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];

            AFN nuevo = new AFN(izquierda, derecha, "concatenacion");

            pilaR.RemoveAt(topePila);
            pilaR.RemoveAt(topePila - 1);
            pilaR.Add(nuevo);
        }

        public void enumeraEstados()
        {
            int cont = 0;
            foreach(Edo unEstado in pilaR[0].LEstados)
            {
                if (unEstado.tipo == "Comienzo")
                {
                    unEstado.id = 0;
                    continue;
                }
                if (unEstado.tipo == "Aceptacion")
                {
                    unEstado.id = pilaR[0].LEstados.Count - 1;
                    continue;
                }
                else
                {
                    unEstado.id = ++cont;
                }
            }
            pilaR[0].LEstados = pilaR[0].LEstados.OrderBy(x => x.id).ToList();
        }

        public void obtenConjuntos(string exprecion)
        {
            string lenguaje2 = exprecion.Replace("&", "");
            lenguaje2 = lenguaje2.Replace("|", "");
            lenguaje2 = lenguaje2.Replace("?", "");
            lenguaje2 = lenguaje2.Replace("+", "");
            lenguaje2 = lenguaje2.Replace("*", "");
            lenguaje2 += "ε";
            var lenguajetemp = new HashSet<char>(lenguaje2);

            AFN lastAFN = pilaR[0];
            
            foreach(Edo unEstado in lastAFN.LEstados)
            {
                foreach(char unCaracter in lenguajetemp)
                {
                    List<int> temp = new List<int>();
                    foreach (Transicion unaTransicion in lastAFN.LTransiciones)
                    {
                        if(unaTransicion.etiqueta == unCaracter.ToString())
                        {
                            if(unEstado.id == unaTransicion.origen.id)
                            {
                                temp.Add(unaTransicion.destino.id);
                            }
                        }
                    }
                    unEstado.conjuntoRelaciones.Add(temp);
                }
            }
        }
    }
}
