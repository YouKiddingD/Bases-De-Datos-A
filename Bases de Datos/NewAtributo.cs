﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bases_de_Datos
{
    public partial class NewAtributo : Form
    {
        public string strNombre = string.Empty;
        public int tipoDato = 0;
        public int tam = 0;
        public int key = 0;
        public string FK = string.Empty;
        public Dictionary<string, int> Tablas = new Dictionary<string, int>();


        //RECIBIR ARREGLO CON TABLAS, PARA PODER ELEGIR FK
        public NewAtributo(Dictionary<string, int> Archivos)
        {
            this.Tablas = Archivos;
            InitializeComponent();
            fillCbTablas();
        }

        //Metodo que llena el combobox de Tablas para seleccionar la llave foranea.
        private void fillCbTablas()
        {
            cbFK.Items.Clear();
            foreach(string s in Tablas.Keys)
            {
                cbFK.Items.Add(s);
            }
        }

        //Metodo que regresa las opciones escogidas por el usuario.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty && txtAncho.Value != 0)
            {
                strNombre = txtNombre.Text;
                tam = Convert.ToInt32(txtAncho.Value);
                FK = cbFK.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Todos los campos tienen que estar en orden");
            }
        }

        //Asignacion del tipo de dato dependiendo de la opcion que escogio el usuario en el combobox
        private void cbTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTipoDato.Text)
            {
                case "int":
                    tipoDato = 1;
                    txtAncho.Value = 4;
                    txtAncho.Enabled = false;
                    break;
                case "float":
                    tipoDato = 2;
                    txtAncho.Value = 4;
                    txtAncho.Enabled = false;
                    break;
                case "string":
                    tipoDato = 3;
                    txtAncho.Value = 0;
                    txtAncho.Enabled = true;
                    break;
            }
        }

        //Asignacion del tipo de llave dependiendo de la opcion que escogio el usuario en el combobox
        private void cbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbKey.Text)
            {
                case "PK":
                    key = 1;
                    cbFK.Enabled = false;
                    cbFK.Text = string.Empty;
                    break;
                case "FK":
                    key = 2;
                    cbFK.Enabled = true;
                    break;
                case "None":
                    key = 3;
                    cbFK.Enabled = false;
                    cbFK.Text = string.Empty;
                    break;
            }
        }

        //Metodo que activa el texto de ancho dependiendo del tipo de dato.
        private void cbFK_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAncho.Enabled = false;
            txtAncho.Value = Tablas[cbFK.Text];
        }

        //Metodo para cancelar la operacion en proceso.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
