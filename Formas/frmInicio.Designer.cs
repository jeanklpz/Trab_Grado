
namespace JeanCIty.Formas
{
    partial class frminicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frminicio));
            this.btnHacerToma = new System.Windows.Forms.Button();
            this.picHuella = new System.Windows.Forms.PictureBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.groupMat = new System.Windows.Forms.GroupBox();
            this.btnEliminarTodos = new System.Windows.Forms.Button();
            this.groupVerificar = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtapellidosver = new System.Windows.Forms.TextBox();
            this.txtcedulaver = new System.Windows.Forms.TextBox();
            this.txtNombrever = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHuella)).BeginInit();
            this.groupMat.SuspendLayout();
            this.groupVerificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHacerToma
            // 
            this.btnHacerToma.ForeColor = System.Drawing.Color.White;
            this.btnHacerToma.Location = new System.Drawing.Point(61, 145);
            this.btnHacerToma.Name = "btnHacerToma";
            this.btnHacerToma.Size = new System.Drawing.Size(113, 23);
            this.btnHacerToma.TabIndex = 0;
            this.btnHacerToma.Text = "Matricular Persona";
            this.btnHacerToma.UseVisualStyleBackColor = true;
            this.btnHacerToma.Click += new System.EventHandler(this.btnHacerToma_Click);
            // 
            // picHuella
            // 
            this.picHuella.BackColor = System.Drawing.Color.Transparent;
            this.picHuella.Image = ((System.Drawing.Image)(resources.GetObject("picHuella.Image")));
            this.picHuella.Location = new System.Drawing.Point(55, 19);
            this.picHuella.Name = "picHuella";
            this.picHuella.Size = new System.Drawing.Size(122, 120);
            this.picHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHuella.TabIndex = 1;
            this.picHuella.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(241, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(136, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(241, 135);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(136, 20);
            this.txtApellidos.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cedula:";
            // 
            // txtcedula
            // 
            this.txtcedula.Location = new System.Drawing.Point(241, 44);
            this.txtcedula.Name = "txtcedula";
            this.txtcedula.Size = new System.Drawing.Size(136, 20);
            this.txtcedula.TabIndex = 6;
            // 
            // groupMat
            // 
            this.groupMat.Controls.Add(this.label7);
            this.groupMat.Controls.Add(this.txtDireccion);
            this.groupMat.Controls.Add(this.txttelefono);
            this.groupMat.Controls.Add(this.txtSexo);
            this.groupMat.Controls.Add(this.label8);
            this.groupMat.Controls.Add(this.label9);
            this.groupMat.Controls.Add(this.picHuella);
            this.groupMat.Controls.Add(this.btnHacerToma);
            this.groupMat.Controls.Add(this.label3);
            this.groupMat.Controls.Add(this.txtApellidos);
            this.groupMat.Controls.Add(this.txtcedula);
            this.groupMat.Controls.Add(this.txtNombre);
            this.groupMat.Controls.Add(this.label2);
            this.groupMat.Controls.Add(this.label1);
            this.groupMat.Location = new System.Drawing.Point(12, 25);
            this.groupMat.Name = "groupMat";
            this.groupMat.Size = new System.Drawing.Size(609, 191);
            this.groupMat.TabIndex = 8;
            this.groupMat.TabStop = false;
            this.groupMat.Text = "Matricular Persona";
            // 
            // btnEliminarTodos
            // 
            this.btnEliminarTodos.ForeColor = System.Drawing.Color.White;
            this.btnEliminarTodos.Location = new System.Drawing.Point(461, 427);
            this.btnEliminarTodos.Name = "btnEliminarTodos";
            this.btnEliminarTodos.Size = new System.Drawing.Size(160, 23);
            this.btnEliminarTodos.TabIndex = 9;
            this.btnEliminarTodos.Text = "Eliminar Todas las personas";
            this.btnEliminarTodos.UseVisualStyleBackColor = true;
            this.btnEliminarTodos.Click += new System.EventHandler(this.btnEliminarTodos_Click);
            // 
            // groupVerificar
            // 
            this.groupVerificar.Controls.Add(this.lbDatabase);
            this.groupVerificar.Controls.Add(this.pictureBox1);
            this.groupVerificar.Controls.Add(this.btnVerificar);
            this.groupVerificar.Controls.Add(this.label4);
            this.groupVerificar.Controls.Add(this.txtapellidosver);
            this.groupVerificar.Controls.Add(this.txtcedulaver);
            this.groupVerificar.Controls.Add(this.txtNombrever);
            this.groupVerificar.Controls.Add(this.label5);
            this.groupVerificar.Controls.Add(this.label6);
            this.groupVerificar.Location = new System.Drawing.Point(18, 230);
            this.groupVerificar.Name = "groupVerificar";
            this.groupVerificar.Size = new System.Drawing.Size(603, 191);
            this.groupVerificar.TabIndex = 9;
            this.groupVerificar.TabStop = false;
            this.groupVerificar.Text = "Verificar Persona";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(49, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnVerificar
            // 
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.Location = new System.Drawing.Point(55, 154);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(113, 23);
            this.btnVerificar.TabIndex = 0;
            this.btnVerificar.Text = "Verificar Persona";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cedula:";
            // 
            // txtapellidosver
            // 
            this.txtapellidosver.Enabled = false;
            this.txtapellidosver.Location = new System.Drawing.Point(220, 128);
            this.txtapellidosver.Name = "txtapellidosver";
            this.txtapellidosver.Size = new System.Drawing.Size(151, 20);
            this.txtapellidosver.TabIndex = 4;
            // 
            // txtcedulaver
            // 
            this.txtcedulaver.Enabled = false;
            this.txtcedulaver.Location = new System.Drawing.Point(220, 37);
            this.txtcedulaver.Name = "txtcedulaver";
            this.txtcedulaver.Size = new System.Drawing.Size(151, 20);
            this.txtcedulaver.TabIndex = 6;
            // 
            // txtNombrever
            // 
            this.txtNombrever.Enabled = false;
            this.txtNombrever.Location = new System.Drawing.Point(220, 81);
            this.txtNombrever.Name = "txtNombrever";
            this.txtNombrever.Size = new System.Drawing.Size(151, 20);
            this.txtNombrever.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Apellidos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nombres:";
            // 
            // lbDatabase
            // 
            this.lbDatabase.FormattingEnabled = true;
            this.lbDatabase.Location = new System.Drawing.Point(417, 28);
            this.lbDatabase.Name = "lbDatabase";
            this.lbDatabase.Size = new System.Drawing.Size(136, 121);
            this.lbDatabase.TabIndex = 8;
            this.lbDatabase.Click += new System.EventHandler(this.lbDatabase_Click);
            this.lbDatabase.SelectedIndexChanged += new System.EventHandler(this.lbDatabase_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(423, 135);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(136, 20);
            this.txtDireccion.TabIndex = 10;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(423, 44);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(136, 20);
            this.txttelefono.TabIndex = 12;
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(423, 88);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(136, 20);
            this.txtSexo.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Direccion:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(420, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "sexo:";
            // 
            // frminicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 455);
            this.Controls.Add(this.groupVerificar);
            this.Controls.Add(this.btnEliminarTodos);
            this.Controls.Add(this.groupMat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frminicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHuella)).EndInit();
            this.groupMat.ResumeLayout(false);
            this.groupMat.PerformLayout();
            this.groupVerificar.ResumeLayout(false);
            this.groupVerificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHacerToma;
        private System.Windows.Forms.PictureBox picHuella;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.GroupBox groupMat;
        private System.Windows.Forms.Button btnEliminarTodos;
        private System.Windows.Forms.GroupBox groupVerificar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtapellidosver;
        private System.Windows.Forms.TextBox txtcedulaver;
        private System.Windows.Forms.TextBox txtNombrever;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}