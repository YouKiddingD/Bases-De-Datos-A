namespace Bases_de_Datos
{
    partial class EditAtributo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbFK = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAncho = new System.Windows.Forms.NumericUpDown();
            this.cbTipoDato = new System.Windows.Forms.ComboBox();
            this.lblTipoDato = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbNameAtributo = new System.Windows.Forms.Label();
            this.cboAtributosEdit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(220, 128);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(85, 128);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(117, 23);
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // cbFK
            // 
            this.cbFK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFK.FormattingEnabled = true;
            this.cbFK.Items.AddRange(new object[] {
            "int",
            "float",
            "string"});
            this.cbFK.Location = new System.Drawing.Point(271, 91);
            this.cbFK.Name = "cbFK";
            this.cbFK.Size = new System.Drawing.Size(121, 21);
            this.cbFK.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "FK:";
            // 
            // cbKey
            // 
            this.cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Items.AddRange(new object[] {
            "PK",
            "FK",
            "None"});
            this.cbKey.Location = new System.Drawing.Point(166, 91);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(52, 21);
            this.cbKey.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Llave:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tamaño:";
            // 
            // txtAncho
            // 
            this.txtAncho.Enabled = false;
            this.txtAncho.Location = new System.Drawing.Point(70, 91);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(39, 20);
            this.txtAncho.TabIndex = 18;
            // 
            // cbTipoDato
            // 
            this.cbTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDato.FormattingEnabled = true;
            this.cbTipoDato.Items.AddRange(new object[] {
            "int",
            "float",
            "string"});
            this.cbTipoDato.Location = new System.Drawing.Point(271, 55);
            this.cbTipoDato.Name = "cbTipoDato";
            this.cbTipoDato.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDato.TabIndex = 17;
            // 
            // lblTipoDato
            // 
            this.lblTipoDato.AutoSize = true;
            this.lblTipoDato.Location = new System.Drawing.Point(195, 58);
            this.lblTipoDato.Name = "lblTipoDato";
            this.lblTipoDato.Size = new System.Drawing.Size(70, 13);
            this.lblTipoDato.TabIndex = 16;
            this.lblTipoDato.Text = "Tipo de dato:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(68, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // lbNameAtributo
            // 
            this.lbNameAtributo.AutoSize = true;
            this.lbNameAtributo.Location = new System.Drawing.Point(15, 58);
            this.lbNameAtributo.Name = "lbNameAtributo";
            this.lbNameAtributo.Size = new System.Drawing.Size(47, 13);
            this.lbNameAtributo.TabIndex = 14;
            this.lbNameAtributo.Text = "Nombre:";
            // 
            // cboAtributosEdit
            // 
            this.cboAtributosEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAtributosEdit.FormattingEnabled = true;
            this.cboAtributosEdit.Items.AddRange(new object[] {
            "int",
            "float",
            "string"});
            this.cboAtributosEdit.Location = new System.Drawing.Point(183, 12);
            this.cboAtributosEdit.Name = "cboAtributosEdit";
            this.cboAtributosEdit.Size = new System.Drawing.Size(121, 21);
            this.cboAtributosEdit.TabIndex = 27;
            this.cboAtributosEdit.SelectedIndexChanged += new System.EventHandler(this.cboAtributosEdit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Atributo:";
            // 
            // EditAtributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 167);
            this.Controls.Add(this.cboAtributosEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbFK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAncho);
            this.Controls.Add(this.cbTipoDato);
            this.Controls.Add(this.lblTipoDato);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbNameAtributo);
            this.Name = "EditAtributo";
            this.Text = "EditAtributo";
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbFK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtAncho;
        private System.Windows.Forms.ComboBox cbTipoDato;
        private System.Windows.Forms.Label lblTipoDato;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbNameAtributo;
        private System.Windows.Forms.ComboBox cboAtributosEdit;
        private System.Windows.Forms.Label label4;
    }
}