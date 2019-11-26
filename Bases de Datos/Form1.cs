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

        //Metodo para la creacion de una base de datos al darle click al boton de crear en la pestaña File
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

        //Metodo para eliminar una base de datos cuando se da click en el boton correspondiente
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

        //Metodo para eliminar la tabla de la base de datos al seleccionarla y darle click en el boton de eliminar
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

        //Metodo para modificar el nombre de la base de datos
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtBaseDatos.Text != string.Empty)
                reiniciarBotones(false);
            else
                MessageBox.Show("You are not connected to any database");
        }

        //Boton que se activa al realizar la accion de renombrar la base de datos y realiza lo antes mencionado
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

        //Metodo para reestablecer todos los botones y pestañas a su estado original al desconectarse de una base de datos o al estado contrario si se conecto a alguna
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
            tsQuery.Enabled = reinicio;
            btnModify.Enabled = reinicio;
            btnRemove.Enabled = reinicio;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reiniciarBotones(true);
            txtBaseDatos.Text = currentFullPath.Substring(currentPath.Length + 1);
        }

        //Metodo utilizado para conectarse a una base de datos creada anteriormente y guardada en el sistema.
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
                LeerAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error connecting to the database");
            }
        }

        //Metodo utilizado para desconectarse de una base de datos y restablecer varios de los parametros a su valor original.
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
            btnInsertTupla.Enabled = false;
            btnUpdateTupla.Enabled = false;
            btnDeleteTupla.Enabled = false;
        }

        //Metodo que controla las acciones a realizar cuando se quiera crear una nueva tabla
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

        //Metodo que guarda en un archivo todos los atributos que conformaran las columnas de las bases de datos, con sus respectivos tipos de datos, tamaños, nombres, etc.
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

        //Metodo que lee los atributos de la tabla que este seleccionada, y los muestra en pantalla consultando todos los datos actualmente guardados
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

        //Metodo que llena las cabeceras del grid con los atributos que se agregaron anteriormente.
        private void fillGridAtributos(List<Atributo> atributos)
        {
            string strInfo = string.Empty;
            foreach (Atributo a in atributos)
            {
                strInfo = a.Nombre + " (" + strTiposDato[a.TipoDato - 1] + ", " + a.Size + ")";
                gridAtributos.Columns.Add(a.Nombre, strInfo);
            }
        }

        //Este metodo se activa cuando se cambia la tabla que se esta consultando, activando un par de botones y mandando leer los atributos correspondientes.
        private void cboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTablas.SelectedItem.ToString() != string.Empty)
            {
                LeerAtributos(cboTablas.SelectedItem.ToString());
                btnAddAtributo.Enabled = true;
                btnEditarAtributo.Enabled = true;
                btnRemoveAtributo.Enabled = true;
                btnInsertTupla.Enabled = true;
                btnUpdateTupla.Enabled = true;
                btnDeleteTupla.Enabled = true;
            }
        }

        //Metodo que lee internamente todos los atributos de cada tabla y los almacena para ser consultados por otras tablas cuando sea necesario.
        private void LeerAll()
        {
            try
            {
                foreach (string s in cboTablas.Items)
                {
                    LeerAtributos(s);
                }
                if(cboTablas.Items.Count > 1)
                {
                    cboTablas.SelectedItem = cboTablas.Items[1];
                    cboTablas.SelectedItem = cboTablas.Items[0];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error reading the table attributes");
            }
        }

        //Metodo para agregar un atributo a la tabla seleccionada.
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

        //Sobrecarga del metodo anterior, utilizados para basicamente lo mismo.
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

        //Metodo que verifica si ya existe una llave primaria en la tabla actual, evitando que se crea otra.
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

        //Metodo que se ejecuta cuando se quiera modificar la configuracion del atributo, modificando tambien el contenido del archivo para mantener las opciones correctas.
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

        //Metodo que remueve el atributo de la tabla seleccionada.
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

        //Metodo utilizado para borrar la tabla actualmente seleccionada evitando ser borrada si esque esta esta siendo referenciada.
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

        //Metodo que verifica si la tabla actual esta siendo referenciada por alguna otra tabla a traves de una llave foranea.
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

        //Metodo que cambia el nombre de la tabla actualmente seleccionada por el especificado.
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

        //Metodo para insertar una tupla con datos que se van a registrar en la base de datos, listos para poder ser consultados. Ademas, se validan ciertas cosas para asegurar la
        //integridad de datos.
        private void btnInsertTupla_Click(object sender, EventArgs e)
        {
            List<string> listaValores = new List<string>();
            string Tabla = cboTablas.SelectedItem.ToString();
            int i = 0, numColumn = 0;
            bool duplica = false;
            if (!dicAtributos.ContainsKey(Tabla) || dicAtributos[Tabla].Count == 0)
            {
                MessageBox.Show("There is no attributes on the table " + Tabla);
                return;
            }
            DataGridViewRow newRow = (DataGridViewRow)gridAtributos.Rows[0].Clone();
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
                                if (a.TipoDato == 3 && txtNewName.Length > a.Size)
                                {
                                    MessageBox.Show("The length of the string is bigger than the column size");
                                    return;
                                }
                                if (a.TipoDato == 1 && !Int32.TryParse(txtNewName, out int num))
                                {
                                    MessageBox.Show("The attribute must be a number");
                                    return;
                                }
                                if (a.Key == 1)
                                {
                                    numColumn = gridAtributos.Columns[a.Nombre].Index;
                                    DataGridViewRow r;
                                    for (int j = 0; j < gridAtributos.Rows.Count - 1; j++)
                                    {
                                        r = gridAtributos.Rows[j];
                                        if (r.Cells[numColumn].Value.ToString() == txtNewName)
                                            duplica = true;
                                    }
                                    if (duplica)
                                    {
                                        MessageBox.Show("The primary key cannot be duplicated");
                                        return;
                                    }
                                }
                                if (a.Key == 2)
                                {
                                    if (!GetPKTabla(a.TablaOrigen).Contains(txtNewName))
                                    {
                                        MessageBox.Show("The given Foreign Key does not exists");
                                        return;
                                    }
                                }
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

        //Metodo que forma la estructura de la tupla para poder ser guardada en el archivo correspondiente.
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

        //Sobrecarga del metodo anterior que inserta la tupla en el lugar de la que se va a reemplazar al editar algun atributo.
        private void saveTupla(List<string> listaValores, int index)
        {
            string txtAtributos = "A:";
            foreach (string s in listaValores)
            {
                txtAtributos += s + "/";
            }
            txtAtributos = txtAtributos.Substring(0, txtAtributos.Length - 1);
            tuplas.RemoveAt(index);
            tuplas.Insert(index, txtAtributos);
            GuardarAtributo(cboTablas.SelectedItem.ToString());
        }

        //Metodo utilizado para borrar una tupla seleccionada con todos sus datos.
        private void BtnDeleteTupla_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarReferenciaRow())
                {
                    MessageBox.Show("The row can not be removed because is being reference by another register");
                    return;
                }
                else
                {
                    int row = gridAtributos.SelectedCells[0].RowIndex;
                    gridAtributos.Rows.RemoveAt(row);
                    tuplas.RemoveAt(row);
                    GuardarAtributo(cboTablas.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing row");
            }
        }

        //Metodo que abre la ventana para realizar la consulta SQL la cual lee si la sentencia es correcta, y muestra en pantalla cada uno de los
        //registros que cumplen con las condiciones indicadas.
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
                                if (allColumns)
                                {
                                    foreach (DataGridViewColumn c in gridAtributos.Columns)
                                    {
                                        c.Visible = true;
                                        c.DisplayIndex = c.Index;
                                    }
                                }
                                else
                                {
                                    foreach (DataGridViewColumn c in gridAtributos.Columns)
                                    {
                                        c.Visible = false;
                                    }
                                    int i = 0;
                                    foreach (string s in Columns)
                                    {
                                        gridAtributos.Columns[s].Visible = true;
                                        gridAtributos.Columns[s].DisplayIndex = i;
                                        i++;
                                    }
                                }
                                if (auxIndex != -1)
                                {
                                    strQuery = strQuery.Substring(auxIndex + 6);
                                    Condiciones = strQuery.Split(' ').Where(x => x != string.Empty).ToList();
                                    if (Condiciones.Count == 3)
                                    {
                                        if (gridAtributos.Columns.Contains(Condiciones[0]))
                                        {
                                            int numColumn = gridAtributos.Columns[Condiciones[0]].Index;
                                            int numAttr = 0;
                                            int operando = 0;
                                            DataGridViewRow r;
                                            if (Int32.TryParse(gridAtributos.Rows[1].Cells[numColumn].Value.ToString(), out numAttr))
                                            {
                                                if (Int32.TryParse(Condiciones[2], out operando))
                                                {
                                                    for (int i = 0; i < gridAtributos.Rows.Count - 1; i++)
                                                    {
                                                        r = gridAtributos.Rows[i];
                                                        r.Visible = false;
                                                        if (Int32.TryParse(r.Cells[numColumn].Value.ToString(), out numAttr))
                                                        {
                                                            switch (Condiciones[1])
                                                            {
                                                                case "=":
                                                                    if (numAttr == operando) r.Visible = true;
                                                                    break;
                                                                case ">":
                                                                    if (numAttr > operando) r.Visible = true;
                                                                    break;
                                                                case "<":
                                                                    if (numAttr < operando) r.Visible = true;
                                                                    break;
                                                                case ">=":
                                                                    if (numAttr >= operando) r.Visible = true;
                                                                    break;
                                                                case "<=":
                                                                    if (numAttr <= operando) r.Visible = true;
                                                                    break;
                                                                case "<>":
                                                                    if (numAttr != operando) r.Visible = true;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("The attribute on the line " + i + " is not valid. It must be a number.");
                                                            return;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("The parameter " + Condiciones[2] + " is not valid. It must be a number.");
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("The attribute " + Condiciones[0] + " is not valid. It must be a number.");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("The attribute " + Condiciones[0] + " doest exists");
                                            return;
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

        //Metodo que obtiene una lista de las llaves primarias de cada uno de los registros que existen en la tabla actualmente seleccionada para su posterior uso.
        private List<string> GetPKTabla(string strTabla)
        {
            List<string> listPK = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(currentFullPath + "\\" + strTabla);
                List<string> columnas = lines.Where(x => x[0] != 'A').ToList();
                List<string> registros = lines.Where(x => x[0] == 'A').ToList();
                List<Atributo> atributos = columnas.Select(x => JsonConvert.DeserializeObject<Atributo>(x)).ToList();
                int index = atributos.IndexOf(atributos.Find(x => x.Key == 1));
                string[] arrValores = null;
                foreach (string s in registros)
                {
                    arrValores = s.Substring(2).Split('/');
                    listPK.Add(arrValores[index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying the foreign key");
            }
            return listPK;
        }

        //Metodo que obtiene una lista de las llaves foraneas de cada uno de los registros FK que existen en la tabla actualmente seleccionada para su posterior uso. 
        private List<string> GetFKTabla(string strTabla)
        {
            List<string> listFK = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(currentFullPath + "\\" + strTabla);
                List<string> columnas = lines.Where(x => x[0] != 'A').ToList();
                List<string> registros = lines.Where(x => x[0] == 'A').ToList();
                List<Atributo> atributos = columnas.Select(x => JsonConvert.DeserializeObject<Atributo>(x)).ToList();
                int index = atributos.IndexOf(atributos.Find(x => x.Key == 2));
                string[] arrValores = null;
                foreach (string s in registros)
                {
                    arrValores = s.Substring(2).Split('/');
                    listFK.Add(arrValores[index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying the foreign key");
            }
            return listFK;
        }

        //Metodo utilizado para la edicion de uno de los atributos, la cual realiza validaciones para asegurar integridad referencial.
        private void btnUpdateTupla_Click(object sender, EventArgs e)
        {
            try
            {
                int row = gridAtributos.SelectedCells[0].RowIndex;
                List<string> listaValores = new List<string>();
                string strTabla = cboTablas.SelectedItem.ToString();
                string strColumn = gridAtributos.SelectedCells[0].OwningColumn.Name.ToString();
                Atributo a = dicAtributos[strTabla].Find(x => x.Nombre == strColumn);
                using (NewDataBase NDB = new NewDataBase("Insert the value of the attribute " + strColumn + ": ", gridAtributos.SelectedCells[0].Value.ToString()))
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
                            if (a.TipoDato == 3 && txtNewName.Length > a.Size)
                            {
                                MessageBox.Show("The length of the string is bigger than the column size");
                                return;
                            }
                            if (a.TipoDato == 1 && !Int32.TryParse(txtNewName, out int num))
                            {
                                MessageBox.Show("The attribute must be a number");
                                return;
                            }
                            if (a.Key == 1)
                            {

                                if (VerificarReferenciaRow())
                                {
                                    MessageBox.Show("The row can not be modified because is being reference by another register");
                                    return;
                                }
                                else
                                {
                                    int numColumn = gridAtributos.Columns[a.Nombre].Index;
                                    bool duplica = false;
                                    DataGridViewRow r;
                                    for (int j = 0; j < gridAtributos.Rows.Count - 1; j++)
                                    {
                                        r = gridAtributos.Rows[j];
                                        if (r.Cells[numColumn].Value.ToString() == txtNewName)
                                            duplica = true;
                                    }
                                    if (duplica)
                                    {
                                        MessageBox.Show("The primary key cannot be duplicated");
                                        return;
                                    }
                                }
                            }
                            if (a.Key == 2)
                            {
                                if (!GetPKTabla(a.TablaOrigen).Contains(txtNewName))
                                {
                                    MessageBox.Show("The given Foreign Key does not exists");
                                    return;
                                }
                            }
                            gridAtributos.SelectedCells[0].Value = txtNewName;
                            foreach (DataGridViewCell c in gridAtributos.Rows[row].Cells)
                            {
                                listaValores.Add(c.Value.ToString());
                            }
                            saveTupla(listaValores, row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the row");
            }
        }

        //Metodo utilizado para encontrar si la tupla actualmente seleccionada esta siendo referenciada por alguna tupla en la misma o en otra tabla y asi, 
        //evitar que esta sea modificada o eliminada.
        private bool VerificarReferenciaRow()
        {
            try
            {
                string strTabla = cboTablas.SelectedItem.ToString();
                string strPK = dicAtributos[strTabla].Find(x => x.Key == 1).Nombre;
                int row = gridAtributos.SelectedCells[0].RowIndex;
                string numValue = gridAtributos.Rows[row].Cells[gridAtributos.Columns[strPK].Index].Value.ToString();
                Atributo a;
                foreach (string s in dicAtributos.Keys)
                {
                    if (s != strTabla)
                    {
                        a = dicAtributos[s].FirstOrDefault(x => x.Key == 2);
                        if (a != null && a.TablaOrigen == strTabla)
                        {
                            if (GetFKTabla(s).Contains(numValue))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying the reference");
            }
            return false;
        }
    }
}
