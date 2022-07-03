using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestaoDeParque.Controller;

namespace GestaoDeParque.View
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private static frmLogin f;
        public static frmLogin GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmLogin();
            }
            return f;
        }


        public static string usern;
        public static string user()
        {
            return usern;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool erro = false;
            if (txtLogin.Text == "")
            {
                erro = true;
                errProvLog.SetError(txtLogin, "Digite o UserName");
            }
            else if (mtxtPass.Text == "")
            {
                erro = true;
                errProvPass.SetError(mtxtPass, "Digite a Senha");
            }
            else
            {
                if (!erro)
                {
                    string username = txtLogin.Text;
                    mtxtPass.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string pass = mtxtPass.Text;

                    List<Users> lista = USerController.getAll();
                    foreach (Users u in lista)
                    {

                        if (u.senha.Equals(pass) && u.userName.Equals(username))
                        {
                            usern = username;
                            frmMenu f =frmMenu.GetInstance();
                            if (!f.Visible)
                            {
                                
                                f.ShowDialog();
                                
                                
                            }
                            else
                                f.BringToFront();

                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Senha /UserName incorretos","Erro de Autenticacao",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
            

            }

        }
       

    }
}