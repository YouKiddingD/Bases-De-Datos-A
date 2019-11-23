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
using Newtonsoft.Json;

namespace Bases_de_Datos
{
    public partial class Form1 : Form
    {
        private string currentFullPath = string.Empty;
        private string currentPath = string.Empty;
        private Dictionary<string, List<Atributo>> dicAtributos = new Dictionary<string, List<Atributo>>();
        private string[] strTiposDato = { "int", "float", "string" };
        private List<string> tuplas = new List<string>();

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
                        using (NewDataBase NDB = new NewDataBase("Insert the name of the database that will be created:"))
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
                MessageBox.Show("There was an error creating the database");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBaseDatos.Text == string.Empty)
                {
                    MessageBox.Show("You are not connected to any database");
                }
                else
                {
                    txtBaseDatos.Text = string.Empty;
                    DeleteDirectory(currentFullPath);
                    MessageBox.Show("Database removed correctly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting the databse");
            }
        }

        private static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtBaseDatos.Text != string.Empty)
                reiniciarBotones(false);
            else
                MessageBox.Show("You are not connected to any database");
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
                    MessageBox.Show("Database renamed correctly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming the database");
            }
            reiniciarBotones(true);
        }

        private void reiniciarBotones(bool reinicio)
        {
            tuplas.Clear();
            gridAtributos.Columns.Clear();
            cboTablas.Enabled = false;
            cboTablas.Items.Clear();
            cboTablas.Text = string.Empty;
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
                reiniciarBotones(true);
                dicAtributos.Clear();
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
                        foreach (string s in strArrFiles)
                        {
                            strAdd = s.Substring(currentFullPath.Length + 1);
                            cboTablas.Items.Add(strAdd);
                        }
                        if (cboTablas.Items.Count != 0)
                        {
                            cboTablas.SelectedIndex = 0;
                            cboTablas.Enabled = true;
                        }
                        else
                            cboTablas.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error connecting to the database");
            }
        }

        private void optDisconnect_Click(object sender, EventArgs e)
        {
            tuplas.Clear();
            gridAtributos.Columns.Clear();
            dicAtributos.Clear();
            cboTablas.Enabled = false;
            cboTablas.Items.Clear();
            currentFullPath = string.Empty;
            currentPath = string.Empty;
            txtBaseDatos.Text = string.Empty;
            cboTablas.Text = string.Empty;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAddAtributo.Enabled = false;
            btnEditarAtributo.Enabled = false;
            btnRemoveAtributo.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (NewDataBase NDB = new NewDataBase("Insert the name of the file that will be created:"))
                {
                    if (NDB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string filePath = currentFullPath + '\\' + NDB.strNewBase;
                        if (File.Exists(filePath))
                        {
                            MessageBox.Show("The specified name already exists");
                        }
                        else
                        {
                            using (FileStream fs = File.Create(filePath))
                            {
                                cboTablas.Items.Add(NDB.strNewBase);
                            }
                            cboTablas.Enabled = true;
                            cboTablas.SelectedIndex = cboTablas.Items.Count - 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating file in the database");
            }
        }

        private void GuardarAtributo(string strNombreArchivo)
        {
            string jRes = string.Empty;

            System.IO.File.WriteAllText(currentFullPath + "\\" + strNombreArchivo, string.Empty);
            foreach (Atributo attr in dicAtributos[strNombreArchivo])
            {
                jRes = JsonConvert.SerializeObject(attr);
                System.IO.File.AppendAllText(currentFullPath + "\\" + strNombreArchivo, jRes);
                System.IO.File.AppendAllText(currentFullPath + "\\" + strNombreArchivo, "\n");
            }
            foreach (string s in tuplas)
            {
                System.IO.File.AppendAllText(currentFullPath + "\\" + strNombreArchivo, s);
                System.IO.File.AppendAllText(currentFullPath + "\\" + strNombreArchivo, "\n");
            }
        }

        private void LeerAtributos(string strNombreArchivo)
        {
            try
            {
                if (dicAtributos.ContainsKey(strNombreArchivo)) dicAtributos[strNombreArchivo].Clear();
                gridAtributos.Columns.Clear(); tuplas.Clear();
                string[] lines = File.ReadAllLines(currentFullPath + "\\" + strNombreArchivo);
                List<string> columnas = lines.Where(x => x[0] != 'A').ToList();
                List<string> registros = lines.Where(x => x[0] == 'A').ToList();
                List<Atributo> atributos = columnas.Select(x => JsonConvert.DeserializeObject<Atributo>(x)).ToList();
                foreach (Atributo item in atributos)
                {
                    if (!dicAtributos.Keys.Contains(strNombreArchivo))
                    {
                        dicAtributos.Add(strNombreArchivo, new List<Atributo>());
                    }
                    dicAtributos[strNombreArchivo].Add(item);
                }
                fillGridAtributos(atributos);
                DataGridViewRow newRow = null;
                string[] arrValores = null;
                int i = 0;
                foreach (string s in registros)
                {
                    newRow = (DataGridViewRow)gridAtributos.Rows[0].Clone();
                    tuplas.Add(s);
                    arrValores = s.Substring(2).Split('/');
                    i = 0;
                    foreach (string s2 in arrValores)
                    {
                        newRow.Cells[i].Value = s2;
                        i++;
                    }
                    gridAtributos.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error leyendo los atributos del archivo " + strNombreArchivo);
            }
        }

        private void fillGridAtributos(List<Atributo> atributos)
        {
            string strInfo = string.Empty;
            foreach (Atributo a in atributos)
            {
                strInfo = a.Nombre + " (" + strTiposDato[a.TipoDato - 1] + ", " + a.Size + ")";
                gridAtributos.Columns.Add(a.Nombre, strInfo);
            }
        }

        private void cboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTablas.SelectedItem.ToString() != string.Empty)
            {
                LeerAtributos(cboTablas.SelectedItem.ToString());
                btnAddAtributo.Enabled = true;
                btnEditarAtributo.Enabled = true;
                btnRemoveAtributo.Enabled = true;
            }
        }

        private void btnAddAtributo_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Tabla = cboTablas.SelectedItem.ToString();
                Dictionary<string, int> archivos = new Dictionary<string, int>();
                foreach (string s in dicAtributos.Keys)
                {
                    if (s != Tabla)
                        foreach (Atributo a in dicAtributos[s])
                        {
                            if (a.Key == 1)
                            {
                                if (!archivos.Keys.Contains(s))
                                    archivos.Add(s, a.Size);
                            }
                        }
                }
                using (NewAtributo NewAttr = new NewAtributo(archivos))
                {
                    if (NewAttr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (NewAttr.key == 1 && VerificarPK(Tabla))
                        {
                            if (!dicAtributos.Keys.Contains(Tabla))
                            {
                                dicAtributos.Add(Tabla, new List<Atributo>());
                            }
                            Atributo attr = new Atributo(NewAttr.strNombre, NewAttr.tipoDato, NewAttr.tam, NewAttr.key, NewAttr.FK);
                            dicAtributos[Tabla].Add(attr);
                            GuardarAtributo(Tabla);
                            LeerAtributos(cboTablas.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("There can only be 1 primary key for table");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating the attribute");
            }
        }

        private void btnAddAtributo_Click(object sender, EventArgs e)
        {
            try
            {
                string Tabla = cboTablas.SelectedItem.ToString();
                Dictionary<string, int> archivos = new Dictionary<string, int>();
                foreach (string s in dicAtributos.Keys)
                {
                    if (s != Tabla)
                        foreach (Atributo a in dicAtributos[s])
                        {
                            if (a.Key == 1)
                            {
                                if (!archivos.Keys.Contains(s))
                                    archivos.Add(s, a.Size);
                            }
                        }
                }
                using (NewAtributo NewAttr = new NewAtributo(archivos))
                {
                    if (NewAttr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (NewAttr.key == 1 && !VerificarPK(Tabla))
                        {
                            MessageBox.Show("There can only be 1 primary key for table");
                        }
                        else
                        {
                            if (!dicAtributos.Keys.Contains(Tabla))
                            {
                                dicAtributos.Add(Tabla, new List<Atributo>());
                            }
                            Atributo attr = new Atributo(NewAttr.strNombre, NewAttr.tipoDato, NewAttr.tam, NewAttr.key, NewAttr.FK);
                            dicAtributos[Tabla].Add(attr);
                            GuardarAtributo(Tabla);
                            LeerAtributos(cboTablas.SelectedItem.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating the attribute");
            }

        }

        private bool VerificarPK(string strNombreTabla)
        {
            if (dicAtributos.ContainsKey(strNombreTabla))
            {
                foreach (Atributo a in dicAtributos[strNombreTabla])
                {
                    if (a.Key == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private void btnEditarAtributo_Click(object sender, EventArgs e)
        {
            try
            {
                string strTabla = cboTablas.SelectedItem.ToString();
                Dictionary<string, int> archivos = new Dictionary<string, int>();
                foreach (string s in dicAtributos.Keys)
                {
                    if (s != strTabla)
                        foreach (Atributo a in dicAtributos[s])
                        {
                            if (a.Key == 1)
                            {
                                if (!archivos.Keys.Contains(s))
                                    archivos.Add(s, a.Size);
                            }
                        }
                }
                using (EditAtributo edit = new EditAtributo(dicAtributos[strTabla], archivos))
                {
                    if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int index = dicAtributos[strTabla].FindIndex(x => x.Nombre == edit.strOriginal);
                        if (dicAtributos[strTabla][index].Key == 1 && checarFK(strTabla))
                        {
                            MessageBox.Show("Could not modify the primary key because it is being referenced by another table");
                        }
                        else
                        {
                            dicAtributos[strTabla].RemoveAt(index);
                            Atributo attr = new Atributo(edit.strNombre, edit.tipoDato, edit.tam, edit.key, edit.FK);
                            dicAtributos[strTabla].Insert(index, attr);
                            GuardarAtributo(strTabla);
                            LeerAtributos(strTabla);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modifying the attribute");
            }
        }

        private void btnRemoveAtributo_Click(object sender, EventArgs e)
        {
            try
            {
                string strTabla = cboTablas.SelectedItem.ToString();
                using (DeleteAtributo delete = new DeleteAtributo(dicAtributos[strTabla]))
                {
                    if (delete.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int index = dicAtributos[strTabla].FindIndex(x => x.Nombre == delete.selectedAttr);
                        if (dicAtributos[strTabla][index].Key == 1 && checarFK(strTabla))
                        {
                            MessageBox.Show("Could not remove the primary key because it is being referenced by another table");
                        }
                        else
                        {
                            dicAtributos[strTabla].RemoveAt(index);
                            GuardarAtributo(strTabla);
                            LeerAtributos(strTabla);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing the attribute");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checarFK(cboTablas.SelectedItem.ToString()))
                {
                    if (dicAtributos.ContainsKey(cboTablas.SelectedItem.ToString())) dicAtributos.Remove(cboTablas.SelectedItem.ToString());
                    string strRemove = currentFullPath + "\\" + cboTablas.SelectedItem.ToString();
                    File.Delete(strRemove);
                    cboTablas.Items.RemoveAt(cboTablas.SelectedIndex);
                    cboTablas.Text = string.Empty;
                    gridAtributos.Columns.Clear();
                }
                else
                {
                    MessageBox.Show("Could not modify the table because it is being referenced by another table");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing the table");
            }
        }

        private bool checarFK(string strTabla)
        {
            foreach (string s in dicAtributos.Keys)
            {
                foreach (Atributo a in dicAtributos[s])
                {
                    if (a.Key == 2)
                        if (a.TablaOrigen == strTabla)
                            return true;
                }
            }
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string strTableOg = cboTablas.SelectedItem.ToString();
                using (NewDataBase NDB = new NewDataBase("Insert the new table name: "))
                {
                    if (NDB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string filePath = currentFullPath + '\\' + NDB.strNewBase;
                        if (File.Exists(filePath))
                        {
                            MessageBox.Show("The specified file already exists");
                        }
                        else
                        {
                            using (FileStream fs = File.Create(filePath))
                            {
                                cboTablas.Items.Add(NDB.strNewBase);
                            }
                            dicAtributos.Add(NDB.strNewBase, new List<Atributo>());
                            if (dicAtributos.ContainsKey(strTableOg))
                            {
                                foreach (Atributo a in dicAtributos[strTableOg])
                                {
                                    dicAtributos[NDB.strNewBase].Add(a);
                                }
                                dicAtributos.Remove(strTableOg);
                                GuardarAtributo(NDB.strNewBase);
                                LeerAtributos(NDB.strNewBase);
                            }
                            string strRemove = currentFullPath + "\\" + strTableOg;
                            File.Delete(strRemove);
                            cboTablas.Items.RemoveAt(cboTablas.SelectedIndex);
                            cboTablas.Enabled = true;
                            cboTablas.SelectedIndex = cboTablas.Items.Count - 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modifying the table");
            }
        }

        private void btnInsertTupla_Click(object sender, EventArgs e)
        {
            List<string> listaValores = new List<string>();
            string Tabla = cboTablas.SelectedItem.ToString();
            DataGridViewRow newRow = (DataGridViewRow)gridAtributos.Rows[0].Clone();
            int i = 0;
            try
            {
                foreach (Atributo a in dicAtributos[Tabla])
                {
                    using (NewDataBase NDB = new NewDataBase("Insert the value of the attribute " + a.Nombre + ": "))
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
                                listaValores.Add(txtNewName);
                                newRow.Cells[i].Value = txtNewName;
                            }
                        }
                    }
                    i++;
                }
                gridAtributos.Rows.Add(newRow);
                saveTupla(listaValores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting row");
            }
        }

        private void saveTupla(List<string> listaValores)
        {
            string txtAtributos = "A:";
            foreach (string s in listaValores)
            {
                txtAtributos += s + "/";
            }
            txtAtributos = txtAtributos.Substring(0, txtAtributos.Length - 1);
            tuplas.Add(txtAtributos);
            GuardarAtributo(cboTablas.SelectedItem.ToString());
        }

        private void BtnDeleteTupla_Click(object sender, EventArgs e)
        {
            try
            {
                int row = gridAtributos.SelectedCells[0].RowIndex;
                gridAtributos.Rows.RemoveAt(row);
                tuplas.RemoveAt(row);
                GuardarAtributo(cboTablas.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing row");
            }
        }

        private void SQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strQuery = string.Empty, strTabla = string.Empty;
            List<string> Columns = new List<string>();
            List<string> Condiciones = new List<string>();
            string ColumnsFalse = string.Empty;
            int auxIndex = 0;
            bool allColumns = false;
            try
            {
                using (SQL sql = new SQL())
                {
                    if (sql.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        strQuery = sql.strQuery;
                        if (strQuery.Substring(0, 6).Equals("SELECT"))
                        {
                            strQuery = strQuery.Substring(7);
                            auxIndex = strQuery.IndexOf("FROM");
                            if (auxIndex != -1)
                            {
                                if (strQuery[0] == '*')
                                {
                                    allColumns = true;
                                }
                                else
                                {
                                    allColumns = false;
                                    Columns = strQuery.Substring(0, auxIndex).Split(',', ' ').Where(x => x != string.Empty).ToList();
                                }
                                strQuery = strQuery.Substring(auxIndex + 5);
                            }
                            else
                            {
                                MessageBox.Show("FROM clause was not found");
                                return;
                            }
                            auxIndex = strQuery.IndexOf(' ');
                            if (auxIndex != -1)
                            {
                                strTabla = strQuery.Substring(0, auxIndex);
                            }
                            else
                            {
                                strTabla = strQuery;
                            }
                            if (cboTablas.Items.Contains(strTabla))
                            {
                                auxIndex = strQuery.IndexOf("WHERE");
                                if (auxIndex == -1)
                                {
                                    cboTablas.SelectedItem = strTabla;
                                    foreach (string s in Columns)
                                    {
                                        if (!gridAtributos.Columns.Contains(s))
                                        {
                                            ColumnsFalse += s + ", ";
                                        }
                                    }
                                    if (ColumnsFalse != string.Empty)
                                    {
                                        MessageBox.Show("The attributes " + ColumnsFalse.Substring(0, ColumnsFalse.Length - 2) + " do not exists");
                                        return;
                                    }
                                    if(allColumns)
                                    {
                                        foreach (DataGridViewColumn c in gridAtributos.Columns)
                                        {
                                            c.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataGridViewColumn c in gridAtributos.Columns)
                                        {
                                            c.Visible = false;
                                        }
                                        foreach (string s in Columns)
                                        {
                                            gridAtributos.Columns[s].Visible = true;
                                        }
                                    }
                                }
                                else
                                {
                                    strQuery = strQuery.Substring(auxIndex + 6);
                                    Condiciones = strQuery.Split(' ').Where(x => x != string.Empty).ToList();
                                    if(Condiciones.Count == 3)
                                    {
                                        switch(Condiciones[1])
                                        {

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("The WHERE condition is not valid");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("The specified Table does not exists");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The only supported statement is SELECT");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing the query");
            }
        }
    }
}
