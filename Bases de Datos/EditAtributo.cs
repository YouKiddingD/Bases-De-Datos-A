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
    public partial class EditAtributo : Form
    {
        public List<Atributo> atributos = new List<Atributo>();

        public EditAtributo(List<Atributo> atributos)
        {
            this.atributos = atributos;
            InitializeComponent();
            fillCbAtributos();
        }

        public void fillCbAtributos()
        {
            foreach(Atributo a in atributos)
            {
                cboAtributosEdit.Items.Add(a.Nombre);
            }
        }

        private void cboAtributosEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Atributo actual = atributos.Find(x => x.Nombre == cboAtributosEdit.SelectedItem.ToString());
            txtNombre.Text = actual.Nombre;
            txtAncho.Value = actual.Size;

        }
    }
}
