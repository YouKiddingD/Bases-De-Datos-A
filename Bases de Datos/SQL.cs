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
    //FORM UTILIZADO PARA PEDIRLE AL USUARIO QUE INSERTE SU SENTENCIA SQL DESEADA
    public partial class SQL : Form
    {
        public string strQuery = string.Empty;
        public SQL()
        {
            InitializeComponent();
        }

        private void BtnCancelarSQL_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BtnAceptarSQL_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text == string.Empty)
            {
                strQuery = string.Empty;
            }
            strQuery = txtQuery.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
