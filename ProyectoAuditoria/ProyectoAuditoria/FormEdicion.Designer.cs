
namespace ProyectoAuditoria
{
    partial class FormEdicion
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
            this.cmbDetRTO = new System.Windows.Forms.ComboBox();
            this.cmbDetRPO = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtRTO = new System.Windows.Forms.TextBox();
            this.txtRPO = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbDetRTO
            // 
            this.cmbDetRTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetRTO.FormattingEnabled = true;
            this.cmbDetRTO.Items.AddRange(new object[] {
            "Sitio Caliente",
            "Sitio Tibio",
            "Sitio Frio"});
            this.cmbDetRTO.Location = new System.Drawing.Point(81, 192);
            this.cmbDetRTO.Name = "cmbDetRTO";
            this.cmbDetRTO.Size = new System.Drawing.Size(176, 21);
            this.cmbDetRTO.TabIndex = 25;
            // 
            // cmbDetRPO
            // 
            this.cmbDetRPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetRPO.FormattingEnabled = true;
            this.cmbDetRPO.Items.AddRange(new object[] {
            "Sitio Caliente",
            "Sitio Tibio",
            "Sitio Frio"});
            this.cmbDetRPO.Location = new System.Drawing.Point(82, 131);
            this.cmbDetRPO.Name = "cmbDetRPO";
            this.cmbDetRPO.Size = new System.Drawing.Size(176, 21);
            this.cmbDetRPO.TabIndex = 24;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(100, 230);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtRTO
            // 
            this.txtRTO.Location = new System.Drawing.Point(81, 163);
            this.txtRTO.Name = "txtRTO";
            this.txtRTO.Size = new System.Drawing.Size(177, 20);
            this.txtRTO.TabIndex = 22;
            this.txtRTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRTO_KeyPress);
            // 
            // txtRPO
            // 
            this.txtRPO.Location = new System.Drawing.Point(81, 101);
            this.txtRPO.Name = "txtRPO";
            this.txtRPO.Size = new System.Drawing.Size(177, 20);
            this.txtRPO.TabIndex = 21;
            this.txtRPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRPO_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(81, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Detalle RTO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Detalle RPO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "RTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "RPO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Editar aplicativo o servicio TI";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(100, 62);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 262);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbDetRTO);
            this.Controls.Add(this.cmbDetRPO);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtRTO);
            this.Controls.Add(this.txtRPO);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEdicion";
            this.Text = "FormEdicion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDetRTO;
        private System.Windows.Forms.ComboBox cmbDetRPO;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtRTO;
        private System.Windows.Forms.TextBox txtRPO;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}