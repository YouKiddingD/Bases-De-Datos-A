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
    public partial class DeleteAtributo : Form
    {
        public List<Atributo> atributos = new List<Atributo>();
        public string selectedAttr = string.Empty;

        public DeleteAtributo(List<Atributo> atributos)
        {
            this.atributos = atributos;
            InitializeComponent();
            fillCbAtributos();
        }

        public void fillCbAtributos()
        {
            foreach (Atributo a in atributos)
            {
                cboAtributosDelete.Items.Add(a.Nombre);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            selectedAttr = cboAtributosDelete.SelectedItem.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
