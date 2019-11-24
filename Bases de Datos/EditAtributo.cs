using System;
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
    //FORM UTILIZADO PARA LA EDICION DEL ATRIBUTO, LLENANDO ALGUNOS CAMPOS Y RECUPERANDO LA NUEVA INFORMACION
    public partial class EditAtributo : Form
    {
        public List<Atributo> atributos = new List<Atributo>();
        public string strOriginal = string.Empty;
        public string strNombre = string.Empty;
        public int tipoDato = 0;
        public int tam = 0;
        public int key = 0;
        public string FK = string.Empty;
        public Dictionary<string, int> Tablas = new Dictionary<string, int>();

        public EditAtributo(List<Atributo> atributos, Dictionary<string, int> Archivos)
        {
            this.atributos = atributos;
            InitializeComponent();
            fillCbAtributos();
        }

        //Llena el combobox con los atributos editables de la tabla seleccionada
        public void fillCbAtributos()
        {
            foreach(Atributo a in atributos)
            {
                cboAtributosEdit.Items.Add(a.Nombre);
            }
        }

        //Se cambian los valores de los campos de la ventana para que concuerden con los actuales en el atributo
        private void cboAtributosEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Atributo actual = atributos.Find(x => x.Nombre == cboAtributosEdit.SelectedItem.ToString());
            txtNombre.Text = actual.Nombre;
            txtAncho.Value = actual.Size;
            switch(actual.Key)
            {
                case 1:
                    cbKey.Text = "PK";
                    break;
                case 2:
                    cbKey.Text = "FK";
                    break;
                case 3:
                    cbKey.Text = "None";
                    break;
            }
            switch(actual.TipoDato)
            {
                case 1:
                    cbTipoDato.Text = "int";
                    break;
                case 2:
                    cbTipoDato.Text = "float";
                    break;
                case 3:
                    cbTipoDato.Text = "string";
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strOriginal = cboAtributosEdit.SelectedItem.ToString();
            strNombre = txtNombre.Text;
            tam = Convert.ToInt32(txtAncho.Value);
            FK = cbFK.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
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

        private void cbFK_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAncho.Enabled = false;
            txtAncho.Value = Tablas[cbFK.Text];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
