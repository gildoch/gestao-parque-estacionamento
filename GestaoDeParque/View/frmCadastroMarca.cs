using GestaoDeParque.Controller;
using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmCadastraMarca : Form
    {
        public frmCadastraMarca()
        {
            InitializeComponent();
        }

        private static frmCadastraMarca f;
        public static frmCadastraMarca GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastraMarca();
            }
            return f;
        }


        public void apagar()
        {
            txtNMarca.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int marcaInvalida;

            if (txtNMarca.Text == "")
            {
                erro = true;
                errProvMarca.SetError(btnViewMarca, "Preencha a Caixa Vazia");
            }
            else if (int.TryParse(txtNMarca.Text, out marcaInvalida))
            {
                erro = true;
                errProvMarca.SetError(btnViewMarca, "Marca Invalida");
            }
            else
            {
                try
                {

                    if (!erro)
                    {
                        Marca marca = new Marca();

                        marca.descricaoM = txtNMarca.Text;
                        MarcaController.grvarMarca(marca);
                        apagar();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnViewMarca_Click(object sender, EventArgs e)
        {
            frmVisualizaMarca f = frmVisualizaMarca.GetInstance();

            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastraMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
