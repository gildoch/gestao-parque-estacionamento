using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoDeParque.Controller;
using GestaoDeParque.Model;

namespace GestaoDeParque.View
{
    public partial class frmUpDateUser : Form
    {
        public frmUpDateUser()
        {
            InitializeComponent();
        }

        private static frmUpDateUser f;
        public static frmUpDateUser GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmUpDateUser();
            }
            return f;
        }


        private void frmUpDateUser_Load(object sender, EventArgs e)
        {
            PerfilController.preencherComboBox(cboPerfil);
            cboPerfil.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           bool erro = false; int userinvalido;
            
            if (txtUsername.Text == "")
            {
                erro = true;
                errProvUserName.SetError(txtUsername, "Preencha o userName");
            }
            else if(int.TryParse(txtUsername.Text,out userinvalido))
            {
                erro = true;
                errProvUserName.SetError(txtUsername, "UserName Invalido");
            }
            else if (cboPerfil.SelectedIndex == -1)
            {
                erro = true;
                errProvPerfil.SetError(cboPerfil, "Escolha Um Perfil");
            }
            else if (mtxtSenha.Text == "")
            {
                erro = true;
                errProvSenha.SetError(mtxtSenha, "Degite a Senha");
            }
            else if (mtxtConSenha.Text == "")
            {
                erro = true;
                errProvSenhaCon.SetError(mtxtConSenha, "Degite a Senha");
            }
            else
            {
                if (!erro)
                {
                    if (mtxtConSenha.Text.Equals(mtxtSenha.Text))
                    {
                        try
                        {
                            frmVisualizarUsers f = frmVisualizarUsers.GetInstance();                           
                            ListViewItem item = f.lstUsers.SelectedItems[0];
                            Users u = new Users();
                            u.id = int.Parse(item.Text);
                            u.id_Perfil = int.Parse(cboPerfil.SelectedValue.ToString());
                            u.senha = mtxtSenha.Text;
                            u.userName = txtUsername.Text;
                            USerController.actualizarUsers(u);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Erro ao Actualizar dados" + ex.Message, "Confirmar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Senhas nao Compativeis", "Confirmar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
