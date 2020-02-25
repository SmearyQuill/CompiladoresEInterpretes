
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladoresInterpretes
{
    public class ExprecionRegular
    {
        string[] alfabeto = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
                                "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."};

        public string exprecionRegular { get; set; }
        public string exprecionPostfija { get; set; }
        public ExprecionRegular()
        {
            exprecionPostfija = "";
            exprecionRegular = "";
        }

        public void unMetodo(List<String> pila, char operador)
        {
            //COMPARATOPE:
            int numElementosPila = pila.Count;
            if (numElementosPila == 0)
            {
                pila.Add(operador.ToString());
            }
            else
            {
                if (operador == ')')
                {
                    for (int k = numElementosPila - 1; k >= 0; k--)
                    {
                        if (pila[k] == "(")
                        {
                            pila.RemoveAt(k);
                            break;
                        }
                        exprecionPostfija += pila[pila.Count - 1];
                        pila.RemoveAt(pila.Count - 1);
                    }
                }
                else
                {

                    int valorTope = 0;
                    switch (pila[numElementosPila - 1])
                    {
                        case "(": valorTope = 0; break;
                        case "&": valorTope = 2; break;
                        case "|": valorTope = 1; break;
                        case "*": valorTope = 3; break;
                        case "+": valorTope = 3; break;
                        case "?": valorTope = 3; break;
                        default: break;
                    }
                    if (operador == '|' && valorTope < 1)
                        pila.Add(operador.ToString());
                    else if (operador == '&' && valorTope < 2)
                        pila.Add(operador.ToString());
                    else if (operador == '+' && valorTope < 3)
                        pila.Add(operador.ToString());
                    else if (operador == '*' && valorTope < 3)
                        pila.Add(operador.ToString());
                    else if (operador == '?' && valorTope < 3)
                        pila.Add(operador.ToString());
                    else if (operador == '(')
                        pila.Add(operador.ToString());
                    else
                    {
                        exprecionPostfija += pila[numElementosPila - 1];
                        pila.RemoveAt(numElementosPila - 1);
                        unMetodo(pila, operador);
                    }
                }
            }
        }

        public bool convertirPostfija()
        {
            exprecionPostfija = "";

            exprecionRegular = buscaRango(exprecionRegular);
            exprecionRegular = exprecionRegular.Replace(" ", "");
            exprecionRegular = meteConcatenaciones(exprecionRegular);

            List<String> pila = new List<string>();
            int longitud = exprecionRegular.Length;
            for (int i = 0; i < longitud; i++)
            {
                char operador = new char();
                operador = exprecionRegular[i];
                if (operador == '+' || operador == '*' || operador == '&' ||
                    operador == '(' || operador == ')' || operador == '|' || operador == '?')
                {
                    unMetodo(pila, operador);
                }
                else
                {
                    Boolean exiteOperando = false;
                    foreach (string operando in alfabeto)
                    {
                        if (operando == operador.ToString())
                        {
                            exiteOperando = true;
                            break;
                        }
                    }
                    if (exiteOperando)
                    {
                        exprecionPostfija += operador;
                    }
                    else
                    {
                        //no encuentra el simbolo dentro del alfabeto u operadores
                        return false;
                    }
                }
            }
            for (int i = pila.Count - 1; i >= 0; i--)
            {
                exprecionPostfija += pila[i];
                pila.RemoveAt(i);
            }
            //termina la convercion exitosamente
            return true;
        }

        public string meteConcatenaciones(string exprecion)
        {
            string nuevaExprecion = "";
            int b = 0;
            nuevaExprecion += exprecion[b];
            for (int f = 1; f < exprecion.Length; f++)
            {
                Boolean existeb = false;
                Boolean existef = false;
                foreach (string operando in alfabeto)
                {
                    if (operando == exprecion[b].ToString())
                    {
                        existeb = true;
                    }
                    if (operando == exprecion[f].ToString())
                    {
                        existef = true;
                    }
                }
                if (existeb)
                {
                    if (existef)
                    {
                        nuevaExprecion += "&";
                    }
                }

                if (existeb && exprecion[f] == '(')
                {
                    nuevaExprecion += "&";
                }
                if (existef && exprecion[b] == ')')
                {
                    nuevaExprecion += "&";
                }
                ///-------------------------
                if (existef)
                {
                    if ((exprecion[b] == '+' || exprecion[b] == '*' || exprecion[b] == '?'))
                    {
                        nuevaExprecion += "&";
                    }
                }
                if (exprecion[b] == ')' && exprecion[f] == '(')
                {
                    nuevaExprecion += "&";
                }
                if ((exprecion[b] == '+' || exprecion[b] == '*' || exprecion[b] == '?') && exprecion[f] == '(')
                {
                    nuevaExprecion += "&";
                }

                nuevaExprecion += exprecion[f];
                b = f;
            }
            return nuevaExprecion;
        }

        public String buscaRango(String exprecionRegular)
        {
            string cambios, corchete;
            cambios = corchete = "";
            int longitud = exprecionRegular.Length;
            Boolean rango = false;
            for (int i = 0; i < longitud; i++)
            {
                if (exprecionRegular[i] == ']')
                {
                    cambios += transformaCorchete(corchete);
                    corchete = "";
                    rango = false;
                }
                else if (exprecionRegular[i] == '[')
                    rango = true;
                else
                {
                    if (rango == false)
                        cambios += exprecionRegular[i];
                    else if (rango)
                        corchete += exprecionRegular[i];
                }
            }
            exprecionRegular = cambios;
            return exprecionRegular;
        }

        public String transformaCorchete(String corchete)
        {
            string c, f;
            c = f = "";
            Boolean existeGuion = false;
            for (int i = 0; i < corchete.Length; i++)
            {
                if (corchete[i] == '-')
                {
                    existeGuion = true;
                    break;
                }
            }
            if (existeGuion)
            {
                c = corchete[0].ToString();
                f = corchete[corchete.Length - 1].ToString();

                corchete = "";
                Boolean concatena = false;
                foreach (string s in alfabeto)
                {
                    if (s == c)
                        concatena = true;
                    if (concatena)
                        corchete += s;
                    if (s == f)
                    {
                        concatena = false;
                        break;
                    }
                }
            }
            string remplaza = "(";
            for (int i = 0; i < corchete.Length; i++)
            {
                remplaza += corchete[i];
                if (i + 1 < corchete.Length)
                    remplaza += "|";
            }
            remplaza += ")";
            corchete = remplaza;

            return corchete;
        }
    }
}