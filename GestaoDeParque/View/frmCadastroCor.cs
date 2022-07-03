using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoDeParque.Model;
using GestaoDeParque.Controller;

namespace GestaoDeParque.View
{
    public partial class frmCadastroCor : Form
    {
        public frmCadastroCor()
        {
            InitializeComponent();
        }

        private static frmCadastroCor f;
        public static frmCadastroCor GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastroCor();
            }
            return f;
        }

        private bool existe(List <Cores> lista, String cor)
        {
            for (int i = 0; i < lista.Count; i++)
                if (lista[i].ToString().ToUpper().Equals(cor.ToUpper()))
                    return true;
            return false;

        }

        public void apagar()
        {
            txtNCor.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int corInvalida;

            List<Cores> listaa=CorController.getAll();

            if (txtNCor.Text == "")
            {
                erro = true;
                erroProvCor.SetError(btnViewCor,"Preencha a Caixa Vazia");
            }
            else if(int.TryParse(txtNCor.Text,out corInvalida))
            {
                erro = true;
                erroProvCor.SetError(btnViewCor, "Cor Invalida");
            }
            else
            {
                try
                {
                    if (!erro)
                    {
                        Cores cor = new Cores();

                        cor.nomeCor = txtNCor.Text;
                        CorController.gravarCor(cor);
                        apagar();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void frmCadastroCor_Load(object sender, EventArgs e)
        {
            //ColorDialog color = new ColorDialog();
            //cboTipoCliente.Items.Add(color.ShowDialog());
        }

        private void txtNCor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnViewCor_Click(object sender, EventArgs e)
        {
            frmVisualizarCor f = frmVisualizarCor.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
