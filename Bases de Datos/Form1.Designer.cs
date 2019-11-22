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
            this.gridAtributos = new System.Windows.Forms.DataGridView();
            this.lblTablas = new System.Windows.Forms.Label();
            this.cboTablas = new System.Windows.Forms.ComboBox();
            this.btnEditarAtributo = new System.Windows.Forms.Button();
            this.btnRemoveAtributo = new System.Windows.Forms.Button();
            this.btnAddAtributo = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnInsertTupla = new System.Windows.Forms.Button();
            this.btnDeleteTupla = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateTupla = new System.Windows.Forms.Button();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(33, 78);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Create";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Enabled = false;
            this.txtBaseDatos.Location = new System.Drawing.Point(151, 39);
            this.txtBaseDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(241, 22);
            this.txtBaseDatos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DataBase:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.queriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(596, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // optConnect
            // 
            this.optConnect.Name = "optConnect";
            this.optConnect.Size = new System.Drawing.Size(225, 26);
            this.optConnect.Text = "Connect to DB";
            this.optConnect.Click += new System.EventHandler(this.optConnect_Click);
            // 
            // optDisconnect
            // 
            this.optDisconnect.Name = "optDisconnect";
            this.optDisconnect.Size = new System.Drawing.Size(225, 26);
            this.optDisconnect.Text = "Disconnect from DB";
            this.optDisconnect.Click += new System.EventHandler(this.optDisconnect_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(401, 38);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 28);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Rename";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(365, 78);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Drop";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(204, 78);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gridAtributos
            // 
            this.gridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAtributos.Location = new System.Drawing.Point(16, 206);
            this.gridAtributos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridAtributos.Name = "gridAtributos";
            this.gridAtributos.RowHeadersVisible = false;
            this.gridAtributos.RowHeadersWidth = 51;
            this.gridAtributos.Size = new System.Drawing.Size(564, 386);
            this.gridAtributos.TabIndex = 11;
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Location = new System.Drawing.Point(228, 14);
            this.lblTablas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(51, 17);
            this.lblTablas.TabIndex = 12;
            this.lblTablas.Text = "Tables";
            // 
            // cboTablas
            // 
            this.cboTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTablas.Enabled = false;
            this.cboTablas.FormattingEnabled = true;
            this.cboTablas.Location = new System.Drawing.Point(175, 33);
            this.cboTablas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTablas.Name = "cboTablas";
            this.cboTablas.Size = new System.Drawing.Size(160, 24);
            this.cboTablas.TabIndex = 13;
            this.cboTablas.SelectedIndexChanged += new System.EventHandler(this.cboTablas_SelectedIndexChanged);
            // 
            // btnEditarAtributo
            // 
            this.btnEditarAtributo.Enabled = false;
            this.btnEditarAtributo.Location = new System.Drawing.Point(207, 53);
            this.btnEditarAtributo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarAtributo.Name = "btnEditarAtributo";
            this.btnEditarAtributo.Size = new System.Drawing.Size(100, 28);
            this.btnEditarAtributo.TabIndex = 16;
            this.btnEditarAtributo.Text = "Modify";
            this.btnEditarAtributo.UseVisualStyleBackColor = true;
            this.btnEditarAtributo.Click += new System.EventHandler(this.btnEditarAtributo_Click);
            // 
            // btnRemoveAtributo
            // 
            this.btnRemoveAtributo.Enabled = false;
            this.btnRemoveAtributo.Location = new System.Drawing.Point(368, 53);
            this.btnRemoveAtributo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveAtributo.Name = "btnRemoveAtributo";
            this.btnRemoveAtributo.Size = new System.Drawing.Size(100, 28);
            this.btnRemoveAtributo.TabIndex = 15;
            this.btnRemoveAtributo.Text = "Drop";
            this.btnRemoveAtributo.UseVisualStyleBackColor = true;
            this.btnRemoveAtributo.Click += new System.EventHandler(this.btnRemoveAtributo_Click);
            // 
            // btnAddAtributo
            // 
            this.btnAddAtributo.Enabled = false;
            this.btnAddAtributo.Location = new System.Drawing.Point(36, 53);
            this.btnAddAtributo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddAtributo.Name = "btnAddAtributo";
            this.btnAddAtributo.Size = new System.Drawing.Size(100, 28);
            this.btnAddAtributo.TabIndex = 14;
            this.btnAddAtributo.Text = "Add";
            this.btnAddAtributo.UseVisualStyleBackColor = true;
            this.btnAddAtributo.Click += new System.EventHandler(this.btnAddAtributo_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = global::Bases_de_Datos.Properties.Resources.remove;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Location = new System.Drawing.Point(525, 39);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(36, 28);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Bases_de_Datos.Properties.Resources.cancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Location = new System.Drawing.Point(461, 37);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(40, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.BackgroundImage = global::Bases_de_Datos.Properties.Resources.check;
            this.btnOkay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOkay.Location = new System.Drawing.Point(401, 38);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(40, 28);
            this.btnOkay.TabIndex = 5;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Visible = false;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Attributes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddAtributo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRemoveAtributo);
            this.panel1.Controls.Add(this.btnEditarAtributo);
            this.panel1.Location = new System.Drawing.Point(33, 679);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 92);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboTablas);
            this.panel2.Controls.Add(this.btnInsert);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.lblTablas);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(43, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 123);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnInsertTupla);
            this.panel3.Controls.Add(this.btnDeleteTupla);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnUpdateTupla);
            this.panel3.Location = new System.Drawing.Point(16, 588);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(563, 75);
            this.panel3.TabIndex = 19;
            // 
            // btnInsertTupla
            // 
            this.btnInsertTupla.Location = new System.Drawing.Point(49, 31);
            this.btnInsertTupla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsertTupla.Name = "btnInsertTupla";
            this.btnInsertTupla.Size = new System.Drawing.Size(100, 28);
            this.btnInsertTupla.TabIndex = 18;
            this.btnInsertTupla.Text = "Insert";
            this.btnInsertTupla.UseVisualStyleBackColor = true;
            this.btnInsertTupla.Click += new System.EventHandler(this.btnInsertTupla_Click);
            // 
            // btnDeleteTupla
            // 
            this.btnDeleteTupla.Location = new System.Drawing.Point(381, 31);
            this.btnDeleteTupla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteTupla.Name = "btnDeleteTupla";
            this.btnDeleteTupla.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTupla.TabIndex = 19;
            this.btnDeleteTupla.Text = "Delete";
            this.btnDeleteTupla.UseVisualStyleBackColor = true;
            this.btnDeleteTupla.Click += new System.EventHandler(this.BtnDeleteTupla_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Rows";
            // 
            // btnUpdateTupla
            // 
            this.btnUpdateTupla.Location = new System.Drawing.Point(220, 31);
            this.btnUpdateTupla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateTupla.Name = "btnUpdateTupla";
            this.btnUpdateTupla.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateTupla.TabIndex = 20;
            this.btnUpdateTupla.Text = "Update";
            this.btnUpdateTupla.UseVisualStyleBackColor = true;
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLToolStripMenuItem});
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sQLToolStripMenuItem.Text = "SQL";
            this.sQLToolStripMenuItem.Click += new System.EventHandler(this.SQLToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 789);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridAtributos);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "My Basedifier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnInsertTupla;
        private System.Windows.Forms.Button btnDeleteTupla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateTupla;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
    }
}

