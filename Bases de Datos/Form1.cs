using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bases_de_Datos
{
    public partial class Form1 : Form
    {
        private string currentFullPath = string.Empty;
        private string currentPath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        using (NewDataBase NDB = new NewDataBase("Inserta el nombre de la base de datos que sera creada:"))
                        {
                            if (NDB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string txtNewName = NDB.strNewBase;
                                if (txtNewName == string.Empty)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    currentPath = fbd.SelectedPath;
                                    currentFullPath = currentPath + '\\' + txtNewName;
                                    System.IO.Directory.CreateDirectory(currentFullPath);
                                    txtBaseDatos.Text = txtNewName;
                                }
                            }
                        }
                    }
                }
                reiniciarBotones(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error creando la base de datos");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBaseDatos.Text == string.Empty)
                {
                    MessageBox.Show("No te encuentras conectado a ninguna Base de Datos");
                }
                else
                {
                    txtBaseDatos.Text = string.Empty;
                    Directory.Delete(currentFullPath);
                    MessageBox.Show("Base de datos eliminada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando la base de datos");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtBaseDatos.Text != string.Empty)
                reiniciarBotones(false);
            else
                MessageBox.Show("No te encuentras conectado a ninguna Base de Datos");
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBaseDatos.Text == string.Empty)
                {
                    throw new Exception();
                }
                else
                {
                    Directory.Move(currentFullPath, currentPath + '\\' + txtBaseDatos.Text);
                    MessageBox.Show("Base de datos renombrada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renombrando la base de datos");
            }
            reiniciarBotones(true);
        }

        private void reiniciarBotones(bool reinicio)
        {
            txtBaseDatos.Enabled = !reinicio;
            if (reinicio)
            {
                btnModify.Show();
                btnOkay.Hide();
                btnCancel.Hide();
            }
            else
            {
                btnModify.Hide();
                btnOkay.Show();
                btnCancel.Show();
            }
            btnInsert.Enabled = reinicio;
            btnRemove.Enabled = reinicio;
            btnUpdate.Enabled = reinicio;
            btnDelete.Enabled = reinicio;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reiniciarBotones(true);
            txtBaseDatos.Text = currentFullPath.Substring(currentPath.Length + 1);
        }

        private void optConnect_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string aux = "\\";
                        currentFullPath = fbd.SelectedPath;
                        txtBaseDatos.Text = fbd.SelectedPath.Split(aux[0]).Last<string>();
                        currentPath = currentFullPath.Substring(0, currentFullPath.Length - txtBaseDatos.Text.Length);
                        string[] strArrFiles = System.IO.Directory.GetFiles(currentFullPath);
                        string strAdd = string.Empty;
                        foreach(string s in strArrFiles)
                        {
                            strAdd = s.Substring(currentFullPath.Length+1);
                            gridArchivos.Columns.Add(strAdd, strAdd);
                        }
                    }
                }
                reiniciarBotones(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error conectandose a la base de datos");
            }
        }

        private void optDisconnect_Click(object sender, EventArgs e)
        {
            currentFullPath = string.Empty;
            currentPath = string.Empty;
            txtBaseDatos.Text = string.Empty;
            gridArchivos.Columns.Clear();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (NewDataBase NDB = new NewDataBase("Inserta el nombre del nuevo archivo que sera creado:"))
                {
                    if (NDB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string filePath = currentFullPath + '\\' + NDB.strNewBase;
                        if (File.Exists(filePath))
                        {
                            MessageBox.Show("El nombre de archivo especificado ya existe");
                        }
                        else
                        {
                            using (FileStream fs = File.Create(filePath))
                            {
                                gridArchivos.Columns.Add(NDB.strNewBase, NDB.strNewBase);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando el archivo en la BD");
            }
        }
    }
}
