using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmCadastroBloqueioViaturas : Form
    {
        public frmCadastroBloqueioViaturas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVisualizaViatura f = frmVisualizaViatura.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private static frmCadastroBloqueioViaturas f;
        public static frmCadastroBloqueioViaturas GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastroBloqueioViaturas();
            }
            return f;
        }

        private void frmCadastroBloqueioViaturas_Load(object sender, EventArgs e)
        {
            dtpBloqueio.Text = "";
            cboNegacao.Items.Add("Entrada");
            cboNegacao.Items.Add("Saida");
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ckbBloqueado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBloqueado.Checked)
                lblBloqueio.Text = "Data De Bloqueio";
            else
                lblBloqueio.Text = "Data De Desbloqueio ";
        }
    }
}
