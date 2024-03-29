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
    //FORM UTILIZADO PARA PEDIRLE ALGUN TIPO DE DATO AL USUARIO
    public partial class NewDataBase : Form
    {
        public string strNewBase = string.Empty;

        //Constructor del form con el mensaje deseado
        public NewDataBase(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }

        //Constructor del form con el mensaje deseado y un texto en el textbox
        public NewDataBase(string message, string placeholder)
        {
            InitializeComponent();
            label1.Text = message;
            txtNuevaBase.Text = placeholder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNuevaBase.Text == string.Empty)
            {
                strNewBase = string.Empty;
            }
            strNewBase = txtNuevaBase.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            strNewBase = string.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
