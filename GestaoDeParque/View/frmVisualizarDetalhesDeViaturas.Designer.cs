namespace GestaoDeParque.View
{
    partial class frmVisualizarDetalhesDeViaturas
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpViatura = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lstViatura = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.marca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpFabricante = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExclui = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovoFabricante = new System.Windows.Forms.Button();
            this.lstVMarca = new System.Windows.Forms.ListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lstVCor = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExcliuCor = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnNovoCor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpViatura.SuspendLayout();
            this.tbpFabricante.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpViatura);
            this.tabControl1.Controls.Add(this.tbpFabricante);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 512);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpViatura
            // 
            this.tbpViatura.BackColor = System.Drawing.Color.Silver;
            this.tbpViatura.Controls.Add(this.btnRefresh);
            this.tbpViatura.Controls.Add(this.label1);
            this.tbpViatura.Controls.Add(this.btnExcluir);
            this.tbpViatura.Controls.Add(this.btnAlterar);
            this.tbpViatura.Controls.Add(this.btnNovo);
            this.tbpViatura.Controls.Add(this.lstViatura);
            this.tbpViatura.Location = new System.Drawing.Point(4, 22);
            this.tbpViatura.Name = "tbpViatura";
            this.tbpViatura.Padding = new System.Windows.Forms.Padding(3);
            this.tbpViatura.Size = new System.Drawing.Size(852, 486);
            this.tbpViatura.TabIndex = 0;
            this.tbpViatura.Text = "Modelos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Detalhes Do Modelo";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(615, 413);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(122, 41);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir Item";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(370, 413);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(122, 41);
            this.btnAlterar.TabIndex = 6;
            this.btnAlterar.Text = "Alterar Item";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(97, 413);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(122, 41);
            this.btnNovo.TabIndex = 5;
            this.btnNovo.Text = "Novo Item";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lstViatura
            // 
            this.lstViatura.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.tipo,
            this.modelo,
            this.marca});
            this.lstViatura.FullRowSelect = true;
            this.lstViatura.GridLines = true;
            this.lstViatura.Location = new System.Drawing.Point(17, 68);
            this.lstViatura.Name = "lstViatura";
            this.lstViatura.Size = new System.Drawing.Size(816, 339);
            this.lstViatura.TabIndex = 4;
            this.lstViatura.UseCompatibleStateImageBehavior = false;
            this.lstViatura.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Codigo";
            this.id.Width = 122;
            // 
            // tipo
            // 
            this.tipo.Text = "Tipo";
            this.tipo.Width = 187;
            // 
            // modelo
            // 
            this.modelo.Text = "Modelo";
            this.modelo.Width = 180;
            // 
            // marca
            // 
            this.marca.Text = "Marca";
            // 
            // tbpFabricante
            // 
            this.tbpFabricante.BackColor = System.Drawing.Color.Silver;
            this.tbpFabricante.Controls.Add(this.button1);
            this.tbpFabricante.Controls.Add(this.label2);
            this.tbpFabricante.Controls.Add(this.btnExclui);
            this.tbpFabricante.Controls.Add(this.btnSair);
            this.tbpFabricante.Controls.Add(this.btnNovoFabricante);
            this.tbpFabricante.Controls.Add(this.lstVMarca);
            this.tbpFabricante.Location = new System.Drawing.Point(4, 22);
            this.tbpFabricante.Name = "tbpFabricante";
            this.tbpFabricante.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFabricante.Size = new System.Drawing.Size(852, 486);
            this.tbpFabricante.TabIndex = 1;
            this.tbpFabricante.Text = "Fabricante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Marca";
            // 
            // btnExclui
            // 
            this.btnExclui.Location = new System.Drawing.Point(342, 420);
            this.btnExclui.Name = "btnExclui";
            this.btnExclui.Size = new System.Drawing.Size(124, 36);
            this.btnExclui.TabIndex = 10;
            this.btnExclui.Text = "Exclui";
            this.btnExclui.UseVisualStyleBackColor = true;
            this.btnExclui.Click += new System.EventHandler(this.btnExclui_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(565, 420);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(124, 36);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovoFabricante
            // 
            this.btnNovoFabricante.Location = new System.Drawing.Point(137, 420);
            this.btnNovoFabricante.Name = "btnNovoFabricante";
            this.btnNovoFabricante.Size = new System.Drawing.Size(124, 36);
            this.btnNovoFabricante.TabIndex = 8;
            this.btnNovoFabricante.Text = "Novo";
            this.btnNovoFabricante.UseVisualStyleBackColor = true;
            this.btnNovoFabricante.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstVMarca
            // 
            this.lstVMarca.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.columnHeader1});
            this.lstVMarca.FullRowSelect = true;
            this.lstVMarca.GridLines = true;
            this.lstVMarca.Location = new System.Drawing.Point(64, 51);
            this.lstVMarca.Name = "lstVMarca";
            this.lstVMarca.Size = new System.Drawing.Size(710, 350);
            this.lstVMarca.TabIndex = 7;
            this.lstVMarca.UseCompatibleStateImageBehavior = false;
            this.lstVMarca.View = System.Windows.Forms.View.Details;
            // 
            // Codigo
            // 
            this.Codigo.Text = "Codigo";
            this.Codigo.Width = 172;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Marca";
            this.columnHeader1.Width = 207;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lstVCor);
            this.tabPage1.Controls.Add(this.btnExcliuCor);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btnNovoCor);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(852, 486);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Cor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cor";
            // 
            // lstVCor
            // 
            this.lstVCor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstVCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstVCor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.Cor});
            this.lstVCor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstVCor.FullRowSelect = true;
            this.lstVCor.GridLines = true;
            this.lstVCor.Location = new System.Drawing.Point(84, 47);
            this.lstVCor.Name = "lstVCor";
            this.lstVCor.Size = new System.Drawing.Size(691, 355);
            this.lstVCor.TabIndex = 4;
            this.lstVCor.UseCompatibleStateImageBehavior = false;
            this.lstVCor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Codigo";
            this.columnHeader2.Width = 165;
            // 
            // Cor
            // 
            this.Cor.Text = "Cor";
            this.Cor.Width = 212;
            // 
            // btnExcliuCor
            // 
            this.btnExcliuCor.Location = new System.Drawing.Point(365, 419);
            this.btnExcliuCor.Name = "btnExcliuCor";
            this.btnExcliuCor.Size = new System.Drawing.Size(101, 37);
            this.btnExcliuCor.TabIndex = 7;
            this.btnExcliuCor.Text = "Exclui";
            this.btnExcliuCor.UseVisualStyleBackColor = true;
            this.btnExcliuCor.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(565, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNovoCor
            // 
            this.btnNovoCor.Location = new System.Drawing.Point(158, 419);
            this.btnNovoCor.Name = "btnNovoCor";
            this.btnNovoCor.Size = new System.Drawing.Size(101, 37);
            this.btnNovoCor.TabIndex = 5;
            this.btnNovoCor.Text = "Novo";
            this.btnNovoCor.UseVisualStyleBackColor = true;
            this.btnNovoCor.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Detalhes De Viaturas";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(863, 44);
            this.label5.TabIndex = 13;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Red;
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -2;
            this.lineShape1.X2 = 858;
            this.lineShape1.Y1 = 44;
            this.lineShape1.Y2 = 44;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(863, 585);
            this.shapeContainer2.TabIndex = 14;
            this.shapeContainer2.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::GestaoDeParque.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(805, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 23);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Image = global::GestaoDeParque.Properties.Resources.arrow_refresh;
            this.button1.Location = new System.Drawing.Point(746, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 38;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button3
            // 
            this.button3.Image = global::GestaoDeParque.Properties.Resources.arrow_refresh;
            this.button3.Location = new System.Drawing.Point(747, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 23);
            this.button3.TabIndex = 38;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // frmVisualizarDetalhesDeViaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shapeContainer2);
            this.Name = "frmVisualizarDetalhesDeViaturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Visualizar Detalhes de Viaturas";
            this.Load += new System.EventHandler(this.frmVisualizarViatura_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpViatura.ResumeLayout(false);
            this.tbpViatura.PerformLayout();
            this.tbpFabricante.ResumeLayout(false);
            this.tbpFabricante.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpViatura;
        private System.Windows.Forms.TabPage tbpFabricante;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader tipo;
        private System.Windows.Forms.ColumnHeader modelo;
        private System.Windows.Forms.ColumnHeader marca;
        private System.Windows.Forms.Button btnExclui;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovoFabricante;
        private System.Windows.Forms.ListView lstVMarca;
        private System.Windows.Forms.ColumnHeader Codigo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Cor;
        private System.Windows.Forms.Button btnExcliuCor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnNovoCor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstVCor;
        public System.Windows.Forms.ListView lstViatura;
        private System.Windows.Forms.Label label5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;




    }
}