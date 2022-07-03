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
    public partial class frmCadastroDePrecos : Form
    {
        public frmCadastroDePrecos()
        {
            InitializeComponent();
        }


        private static frmCadastroDePrecos f;
        public static frmCadastroDePrecos GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastroDePrecos();
            }
            return f;
        }

        private void apagar()
        {
            txtTipoC.Text = "";
            txtValorC.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroDePrecos_Load(object sender, EventArgs e)
        {
            ModeloController.preencherComboBox(cboTipoViatura);
        }

        private void btnLookPrecos_Click(object sender, EventArgs e)
        {
            frmVPrecos f = frmVPrecos.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            bool erro = false; int tipoInvalido; double valorCerto;
            if (txtTipoC.Text == "")
            {
                erro = true;
                errProvTipo.SetError(btnLookPrecos, "Preencha o Tipo de Contrato");
            }
            else if (int.TryParse(txtTipoC.Text, out tipoInvalido))
            {
                erro = true;
                errProvTipo.SetError(btnLookPrecos, "Tipo de Contrato Invalido");
            }
            else if (txtValorC.Text == "")
            {
                erro = true;
                errProvValor.SetError(txtValorC, "Preencha o Valor do contrato");
            }
            else if (!double.TryParse(txtValorC.Text, out valorCerto))
            {
                erro = true;
                errProvValor.SetError(txtValorC, "Valor Invalido");
            }
            else
            {
                try
                {

                    if (!erro)
                    {
                        Precos precos = new Precos();

                        precos.tipoContrato = txtTipoC.Text;
                        precos.valor = int.Parse(txtValorC.Text);
                        PrecosController.gravarPrecos(precos);
                        apagar();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void apagarR()
        {
            cboTipoViatura.SelectedIndex = -1;
            txtValorR.Text ="";
        }
        private void btnConfirmarRotativos_Click(object sender, EventArgs e)
        {
            bool erro = false;
            double valorCerto;
            if (txtValorR.Text == "")
            {
                erro = true;
                errProvValorR.SetError(txtValorR, "Preencha o Valor");
            }
            else if (!double.TryParse(txtValorR.Text, out valorCerto))
            {
                erro = true;
                errProvValorR.SetError(txtValorR, "Valor Invaliido");
            }
            else if (cboTipoViatura.SelectedIndex == -1)
            {
                erro = true;
                errProvTipoViatura.SetError(cboTipoViatura, "Escolha O Tipo De Viatura");
            }
            else
            {
                PrecosRotativos p = new PrecosRotativos();
                p.tipoViatura = int.Parse(cboTipoViatura.SelectedValue.ToString());
                p.valor = double.Parse(txtValorR.Text);
                PrecosRotativosController.gravarPrecosRotativos(p);
                apagarR();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
