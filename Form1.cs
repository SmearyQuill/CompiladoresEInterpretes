
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladoresInterpretes
{
    public partial class Form1 : Form
    {
        ExprecionRegular exprecion;
        public Form1()
        {
            InitializeComponent();
            exprecion = new ExprecionRegular();
        }

        private void bPostfija_Click(object sender, EventArgs e)
        {
            exprecion.exprecionRegular = tbExprecion.Text;
            bool convercionExitosa = exprecion.convertirPostfija();
            if (convercionExitosa)
            {
                tbPostfija.Clear();
                tbPostfija.Text = exprecion.exprecionPostfija;

            }
            else
            {
                MessageBox.Show("La exprecion regular contiene un caracter fuera del lenguaje {a - z} o {0 - 9}");
            }
        }

    }
}