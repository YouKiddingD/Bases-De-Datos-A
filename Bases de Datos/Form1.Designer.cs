namespace Bases_de_Datos
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.optDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.gridAtributos = new System.Windows.Forms.DataGridView();
            this.lblTablas = new System.Windows.Forms.Label();
            this.cboTablas = new System.Windows.Forms.ComboBox();
            this.btnEditarAtributo = new System.Windows.Forms.Button();
            this.btnRemoveAtributo = new System.Windows.Forms.Button();
            this.btnAddAtributo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(52, 117);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Create";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Enabled = false;
            this.txtBaseDatos.Location = new System.Drawing.Point(113, 32);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(182, 20);
            this.txtBaseDatos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DataBase:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.optConnect,
            this.optDisconnect});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // optConnect
            // 
            this.optConnect.Name = "optConnect";
            this.optConnect.Size = new System.Drawing.Size(180, 22);
            this.optConnect.Text = "Connect to DB";
            this.optConnect.Click += new System.EventHandler(this.optConnect_Click);
            // 
            // optDisconnect
            // 
            this.optDisconnect.Name = "optDisconnect";
            this.optDisconnect.Size = new System.Drawing.Size(180, 22);
            this.optDisconnect.Text = "Disconnect from DB";
            this.optDisconnect.Click += new System.EventHandler(this.optDisconnect_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(301, 31);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Rename";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(301, 117);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(180, 117);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = global::Bases_de_Datos.Properties.Resources.remove;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Location = new System.Drawing.Point(394, 32);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Bases_de_Datos.Properties.Resources.cancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Location = new System.Drawing.Point(346, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.BackgroundImage = global::Bases_de_Datos.Properties.Resources.check;
            this.btnOkay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOkay.Location = new System.Drawing.Point(301, 31);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(30, 23);
            this.btnOkay.TabIndex = 5;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Visible = false;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // gridAtributos
            // 
            this.gridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAtributos.Location = new System.Drawing.Point(12, 147);
            this.gridAtributos.Name = "gridAtributos";
            this.gridAtributos.RowHeadersVisible = false;
            this.gridAtributos.Size = new System.Drawing.Size(423, 314);
            this.gridAtributos.TabIndex = 11;
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Location = new System.Drawing.Point(198, 65);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(39, 13);
            this.lblTablas.TabIndex = 12;
            this.lblTablas.Text = "Tablas";
            // 
            // cboTablas
            // 
            this.cboTablas.Enabled = false;
            this.cboTablas.FormattingEnabled = true;
            this.cboTablas.Location = new System.Drawing.Point(158, 81);
            this.cboTablas.Name = "cboTablas";
            this.cboTablas.Size = new System.Drawing.Size(121, 21);
            this.cboTablas.TabIndex = 13;
            this.cboTablas.SelectedIndexChanged += new System.EventHandler(this.cboTablas_SelectedIndexChanged);
            // 
            // btnEditarAtributo
            // 
            this.btnEditarAtributo.Enabled = false;
            this.btnEditarAtributo.Location = new System.Drawing.Point(180, 478);
            this.btnEditarAtributo.Name = "btnEditarAtributo";
            this.btnEditarAtributo.Size = new System.Drawing.Size(75, 23);
            this.btnEditarAtributo.TabIndex = 16;
            this.btnEditarAtributo.Text = "Update";
            this.btnEditarAtributo.UseVisualStyleBackColor = true;
            this.btnEditarAtributo.Click += new System.EventHandler(this.btnEditarAtributo_Click);
            // 
            // btnRemoveAtributo
            // 
            this.btnRemoveAtributo.Enabled = false;
            this.btnRemoveAtributo.Location = new System.Drawing.Point(301, 478);
            this.btnRemoveAtributo.Name = "btnRemoveAtributo";
            this.btnRemoveAtributo.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAtributo.TabIndex = 15;
            this.btnRemoveAtributo.Text = "Delete";
            this.btnRemoveAtributo.UseVisualStyleBackColor = true;
            this.btnRemoveAtributo.Click += new System.EventHandler(this.btnRemoveAtributo_Click);
            // 
            // btnAddAtributo
            // 
            this.btnAddAtributo.Enabled = false;
            this.btnAddAtributo.Location = new System.Drawing.Point(52, 478);
            this.btnAddAtributo.Name = "btnAddAtributo";
            this.btnAddAtributo.Size = new System.Drawing.Size(75, 23);
            this.btnAddAtributo.TabIndex = 14;
            this.btnAddAtributo.Text = "Insert";
            this.btnAddAtributo.UseVisualStyleBackColor = true;
            this.btnAddAtributo.Click += new System.EventHandler(this.btnAddAtributo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 513);
            this.Controls.Add(this.btnEditarAtributo);
            this.Controls.Add(this.btnRemoveAtributo);
            this.Controls.Add(this.btnAddAtributo);
            this.Controls.Add(this.cboTablas);
            this.Controls.Add(this.lblTablas);
            this.Controls.Add(this.gridAtributos);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "My Basedifier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optConnect;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem optDisconnect;
        private System.Windows.Forms.DataGridView gridAtributos;
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.ComboBox cboTablas;
        private System.Windows.Forms.Button btnEditarAtributo;
        private System.Windows.Forms.Button btnRemoveAtributo;
        private System.Windows.Forms.Button btnAddAtributo;
    }
}

