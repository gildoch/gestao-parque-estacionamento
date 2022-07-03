namespace GestaoDeParque.View
{
    partial class CadastroDTurnosFuncionarios
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTurnoF = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfiirmar = new System.Windows.Forms.Button();
            this.btnLookTurnos = new System.Windows.Forms.Button();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.erroProvTurno = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erroProvTurno)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // txtTurnoF
            // 
            this.txtTurnoF.Location = new System.Drawing.Point(102, 108);
            this.txtTurnoF.Name = "txtTurnoF";
            this.txtTurnoF.Size = new System.Drawing.Size(188, 20);
            this.txtTurnoF.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(260, 144);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 35);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfiirmar
            // 
            this.btnConfiirmar.Location = new System.Drawing.Point(102, 144);
            this.btnConfiirmar.Name = "btnConfiirmar";
            this.btnConfiirmar.Size = new System.Drawing.Size(75, 35);
            this.btnConfiirmar.TabIndex = 3;
            this.btnConfiirmar.Text = "Confirmar";
            this.btnConfiirmar.UseVisualStyleBackColor = true;
            this.btnConfiirmar.Click += new System.EventHandler(this.btnConfiirmar_Click);
            // 
            // btnLookTurnos
            // 
            this.btnLookTurnos.Location = new System.Drawing.Point(296, 106);
            this.btnLookTurnos.Name = "btnLookTurnos";
            this.btnLookTurnos.Size = new System.Drawing.Size(39, 22);
            this.btnLookTurnos.TabIndex = 4;
            this.btnLookTurnos.UseVisualStyleBackColor = true;
            this.btnLookTurnos.Click += new System.EventHandler(this.btnLookTurnos_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Red;
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 436;
            this.lineShape1.Y1 = 40;
            this.lineShape1.Y2 = 40;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(436, 232);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 39);
            this.label5.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Cadastrar Turnos De Funcionarios";
            // 
            // erroProvTurno
            // 
            this.erroProvTurno.ContainerControl = this;
            // 
            // CadastroDTurnosFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLookTurnos);
            this.Controls.Add(this.btnConfiirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtTurnoF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "CadastroDTurnosFuncionarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Turnos";
            this.Load += new System.EventHandler(this.CadastroDTurnosFuncionarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erroProvTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTurnoF;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfiirmar;
        private System.Windows.Forms.Button btnLookTurnos;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider erroProvTurno;
    }
}