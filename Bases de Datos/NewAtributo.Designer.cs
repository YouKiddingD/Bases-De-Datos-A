namespace Bases_de_Datos
{
    partial class NewAtributo
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
            this.lbNameAtributo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipoDato = new System.Windows.Forms.Label();
            this.cbTipoDato = new System.Windows.Forms.ComboBox();
            this.txtAncho = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFK = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNameAtributo
            // 
            this.lbNameAtributo.AutoSize = true;
            this.lbNameAtributo.Location = new System.Drawing.Point(12, 20);
            this.lbNameAtributo.Name = "lbNameAtributo";
            this.lbNameAtributo.Size = new System.Drawing.Size(47, 13);
            this.lbNameAtributo.TabIndex = 0;
            this.lbNameAtributo.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(65, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblTipoDato
            // 
            this.lblTipoDato.AutoSize = true;
            this.lblTipoDato.Location = new System.Drawing.Point(192, 20);
            this.lblTipoDato.Name = "lblTipoDato";
            this.lblTipoDato.Size = new System.Drawing.Size(70, 13);
            this.lblTipoDato.TabIndex = 2;
            this.lblTipoDato.Text = "Tipo de dato:";
            // 
            // cbTipoDato
            // 
            this.cbTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDato.FormattingEnabled = true;
            this.cbTipoDato.Items.AddRange(new object[] {
            "int",
            "float",
            "string"});
            this.cbTipoDato.Location = new System.Drawing.Point(268, 17);
            this.cbTipoDato.Name = "cbTipoDato";
            this.cbTipoDato.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDato.TabIndex = 3;
            this.cbTipoDato.SelectedIndexChanged += new System.EventHandler(this.cbTipoDato_SelectedIndexChanged);
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(67, 53);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(39, 20);
            this.txtAncho.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tamaño:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Llave:";
            // 
            // cbKey
            // 
            this.cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Items.AddRange(new object[] {
            "PK",
            "FK",
            "None"});
            this.cbKey.Location = new System.Drawing.Point(163, 53);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(52, 21);
            this.cbKey.TabIndex = 9;
            this.cbKey.SelectedIndexChanged += new System.EventHandler(this.cbKey_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "FK:";
            // 
            // cbFK
            // 
            this.cbFK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFK.FormattingEnabled = true;
            this.cbFK.Items.AddRange(new object[] {
            "int",
            "float",
            "string"});
            this.cbFK.Location = new System.Drawing.Point(268, 53);
            this.cbFK.Name = "cbFK";
            this.cbFK.Size = new System.Drawing.Size(121, 21);
            this.cbFK.TabIndex = 11;
            this.cbFK.SelectedIndexChanged += new System.EventHandler(this.cbFK_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(82, 90);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(117, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // NewAtributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 125);
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
            this.Name = "NewAtributo";
            this.Text = "NewAtributo";
            ((System.ComponentModel.ISupportInitialize)(this.txtAncho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameAtributo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipoDato;
        private System.Windows.Forms.ComboBox cbTipoDato;
        private System.Windows.Forms.NumericUpDown txtAncho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFK;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}