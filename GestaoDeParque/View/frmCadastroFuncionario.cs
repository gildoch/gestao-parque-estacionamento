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
using GestaoDeParque.View;
using System.Data.OleDb;


namespace GestaoDeParque.View
{
    public partial class frmCadastroFuncionario : Form
    {
        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }

        private static frmCadastroFuncionario f;
        public static frmCadastroFuncionario GetInstance()
        
          {
            if (f == null || f.IsDisposed)
            {
                f=new frmCadastroFuncionario();
            }
            return f;
        }

        private void frmCadastroFuncionario_Load(object sender, EventArgs e)
        {
            TurnosController.preencherComboBox(cboTurno);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaDados();
        }
        private void limpaDados() 
        {
            txtNome.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtId.Text = "";
            cboTurno.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravarFuncionario_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int nomeInvalido,enderecoInvalido,ContactoCerto;
            
            if (txtNome.Text == "")
            {
                erro = true;
                erroProvNome.SetError(txtNome, "Preencha o Nome");
            }
            else if (int.TryParse(txtNome.Text, out nomeInvalido))
            {
                erro = true;
                erroProvNome.SetError(txtNome, "Nome Invalido");
            }
            else if (txtEndereco.Text == "")
            {
                erro = true;
                erroProvEndereco.SetError(txtEndereco, "Preencha o endereco");
            }
            else if (int.TryParse(txtEndereco.Text, out enderecoInvalido))
            {
                erro = true;
                erroProvEndereco.SetError(txtEndereco, "Endereco Invalido");
            }
            else if (txtContacto.Text == "")
            {
                erro = true;
                erroProvContacto.SetError(txtContacto, "Preencha o Cantacto");
            }
            else if (!int.TryParse(txtContacto.Text, out ContactoCerto))
            {
                erro = true;
                erroProvContacto.SetError(txtContacto, "Contacto Invalido");
            }
            else if (txtEmail.Text == "")
            {
                erro = true;
                erroProvEmail.SetError(txtEmail, "Preencha o Email");
            }
            else
            {
                try
                {

                    if (!erro)
                    {
                        Funcionario func = new Funcionario();
                        func.nome = txtNome.Text;
                        // func.id = txtId.Text;
                        func.endereco = txtEndereco.Text;
                        func.contacto = txtContacto.Text;
                        func.email = txtEmail.Text;
                        func.turno = cboTurno.SelectedValue.ToString();
                        FuncionarioController.gravarFuncionario(func);
                        limpaDados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro:" + ex.Message, "Erro no Click da gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void BTNsfUN_Click(object sender, EventArgs e)
        {
    
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
