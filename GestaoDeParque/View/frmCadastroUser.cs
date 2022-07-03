using GestaoDeParque.Controller;
using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmCadastroUser : Form
    {
        public frmCadastroUser()
        {
            InitializeComponent();
        }

        private void frmCadastroUser_Load(object sender, EventArgs e)
        {

            PerfilController.preencherComboBox(cboPerfil);
            cboPerfil.Text = "";
            
        }

        private static frmCadastroUser f;
        public static frmCadastroUser GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastroUser();
            }
            return f;
        }


        private void apagar()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtUsername.Text = "";
            txtSenha.Text = "";
            txtConSenha.Text = ""; 
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool erro = false; int userInvalido;
            if (txtId.Text == "")
            {
                erro = true;
                erroProvId.SetError(btnSFun, "Escolha Um Funcionario");
            }
            else if (txtUsername.Text == "")
            {
                erro = true;
                erroProvUser.SetError(txtUsername, "Preencha o UserName");
            }
            else if (int.TryParse(txtUsername.Text, out userInvalido))
            {
                erro = true;
                erroProvUser.SetError(txtUsername, "UserName Invalido");
            }
            else if (cboPerfil.Text == "")
            {
                erro = true;
                erroProvPerfil.SetError(cboPerfil, "Escolha Um Perfil");
            }
            else if (txtSenha.Text == "")
            {
                erro = true;
                erroProvSenha.SetError(txtSenha, "Preencha a senha");
            }
            else if (txtConSenha.Text == "")
            {
                erro = true;
                erroProvCSenha.SetError(txtConSenha, "Confirme a senha");
            }

            else
            {
                try
                {

                    if (!erro)
                    {
                        Users users = new Users();
                        users.userName = txtUsername.Text;
                        users.id_Funcionario = int.Parse(txtId.Text);
                        users.id_Perfil = int.Parse(cboPerfil.SelectedValue.ToString());

                        if (txtSenha.Text == txtConSenha.Text)
                        {
                            users.senha = txtSenha.Text;
                            USerController.gravarUsers(users);
                            apagar();
                        }
                        else
                        {
                            MessageBox.Show("Senhas diferentes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSFun_Click(object sender, EventArgs e)
        {
            frmViewFuncionario f = frmViewFuncionario.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }
    }
}
