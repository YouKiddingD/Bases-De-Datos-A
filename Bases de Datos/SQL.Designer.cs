namespace Bases_de_Datos
{
    partial class SQL
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
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnAceptarSQL = new System.Windows.Forms.Button();
            this.btnCancelarSQL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(851, 635);
            this.txtQuery.TabIndex = 0;
            // 
            // btnAceptarSQL
            // 
            this.btnAceptarSQL.Location = new System.Drawing.Point(269, 657);
            this.btnAceptarSQL.Name = "btnAceptarSQL";
            this.btnAceptarSQL.Size = new System.Drawing.Size(126, 30);
            this.btnAceptarSQL.TabIndex = 1;
            this.btnAceptarSQL.Text = "Ejecutar";
            this.btnAceptarSQL.UseVisualStyleBackColor = true;
            this.btnAceptarSQL.Click += new System.EventHandler(this.BtnAceptarSQL_Click);
            // 
            // btnCancelarSQL
            // 
            this.btnCancelarSQL.Location = new System.Drawing.Point(457, 657);
            this.btnCancelarSQL.Name = "btnCancelarSQL";
            this.btnCancelarSQL.Size = new System.Drawing.Size(126, 30);
            this.btnCancelarSQL.TabIndex = 2;
            this.btnCancelarSQL.Text = "Cancelar";
            this.btnCancelarSQL.UseVisualStyleBackColor = true;
            this.btnCancelarSQL.Click += new System.EventHandler(this.BtnCancelarSQL_Click);
            // 
            // SQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 699);
            this.Controls.Add(this.btnCancelarSQL);
            this.Controls.Add(this.btnAceptarSQL);
            this.Controls.Add(this.txtQuery);
            this.Name = "SQL";
            this.Text = "SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnAceptarSQL;
        private System.Windows.Forms.Button btnCancelarSQL;
    }
}