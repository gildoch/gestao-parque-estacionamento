namespace GestaoDeParque.View
{
    partial class frmVisualizaPreco
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
            this.lstVPrecos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.listViewPrecos = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSair = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshR = new System.Windows.Forms.Button();
            this.rdoMensal = new System.Windows.Forms.RadioButton();
            this.rdoRotativo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lstVPrecos
            // 
            this.lstVPrecos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstVPrecos.Location = new System.Drawing.Point(12, 60);
            this.lstVPrecos.Name = "lstVPrecos";
            this.lstVPrecos.Size = new System.Drawing.Size(692, 302);
            this.lstVPrecos.TabIndex = 0;
            this.lstVPrecos.UseCompatibleStateImageBehavior = false;
            this.lstVPrecos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Codigo";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor";
            this.columnHeader3.Width = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabela De Precos";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(199, 433);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(101, 43);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Alterar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(19, 433);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(101, 43);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(384, 433);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(101, 43);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listViewPrecos
            // 
            this.listViewPrecos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewPrecos.FullRowSelect = true;
            this.listViewPrecos.Location = new System.Drawing.Point(19, 94);
            this.listViewPrecos.Name = "listViewPrecos";
            this.listViewPrecos.Size = new System.Drawing.Size(673, 316);
            this.listViewPrecos.TabIndex = 5;
            this.listViewPrecos.UseCompatibleStateImageBehavior = false;
            this.listViewPrecos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Codigo";
            this.columnHeader4.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tipo";
            this.columnHeader5.Width = 237;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Valor";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(554, 433);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(101, 43);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-7, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(723, 50);
            this.label4.TabIndex = 9;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Red;
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 735;
            this.lineShape1.Y1 = 57;
            this.lineShape1.Y2 = 57;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(716, 506);
            this.shapeContainer1.TabIndex = 10;
            this.shapeContainer1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tabela De Precos";
            // 
            // btnRefreshR
            // 
            this.btnRefreshR.Image = global::GestaoDeParque.Properties.Resources.arrow_refresh;
            this.btnRefreshR.Location = new System.Drawing.Point(659, 65);
            this.btnRefreshR.Name = "btnRefreshR";
            this.btnRefreshR.Size = new System.Drawing.Size(33, 23);
            this.btnRefreshR.TabIndex = 12;
            this.btnRefreshR.UseVisualStyleBackColor = true;
            this.btnRefreshR.Click += new System.EventHandler(this.btnRefreshR_Click);
            // 
            // rdoMensal
            // 
            this.rdoMensal.AutoSize = true;
            this.rdoMensal.Location = new System.Drawing.Point(19, 65);
            this.rdoMensal.Name = "rdoMensal";
            this.rdoMensal.Size = new System.Drawing.Size(59, 17);
            this.rdoMensal.TabIndex = 13;
            this.rdoMensal.TabStop = true;
            this.rdoMensal.Text = "Mensal";
            this.rdoMensal.UseVisualStyleBackColor = true;
            this.rdoMensal.CheckedChanged += new System.EventHandler(this.rdoMensal_CheckedChanged);
            // 
            // rdoRotativo
            // 
            this.rdoRotativo.AutoSize = true;
            this.rdoRotativo.Location = new System.Drawing.Point(111, 65);
            this.rdoRotativo.Name = "rdoRotativo";
            this.rdoRotativo.Size = new System.Drawing.Size(70, 17);
            this.rdoRotativo.TabIndex = 14;
            this.rdoRotativo.TabStop = true;
            this.rdoRotativo.Text = "Rotativos";
            this.rdoRotativo.UseVisualStyleBackColor = true;
            this.rdoRotativo.CheckedChanged += new System.EventHandler(this.rdoRotativo_CheckedChanged);
            // 
            // frmVisualizaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 506);
            this.Controls.Add(this.rdoRotativo);
            this.Controls.Add(this.rdoMensal);
            this.Controls.Add(this.btnRefreshR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.listViewPrecos);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "frmVisualizaPreco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabela De Precos";
            this.Load += new System.EventHandler(this.frmViewPrecos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstVPrecos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.ListView listViewPrecos;
        private System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshR;
        private System.Windows.Forms.RadioButton rdoMensal;
        private System.Windows.Forms.RadioButton rdoRotativo;
    }
}