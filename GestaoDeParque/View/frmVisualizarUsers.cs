using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using GestaoDeParque.Controller;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmVisualizarUsers : Form
    {
        public frmVisualizarUsers()
        {
            InitializeComponent();
        }

        private static frmVisualizarUsers f;
        public static frmVisualizarUsers GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarUsers();
            }
            return f;
        }

        private void popularUsuarios(List<Users> lista)
        {
            lstUsers.Items.Clear();

            foreach (Users ur in lista)
            {
                if (ur != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ur.id.ToString();
                    item.SubItems.Add(ur.userName);
                    lstUsers.Items.Add(item);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                frmCadastroUser f = frmCadastroUser.GetInstance();
                if (!f.Visible)
                    f.ShowDialog();
                else
                    f.BringToFront();
            }
            else
            {
                MessageBox.Show("Sem permissao para Adicionar", "Adicionar User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }

        private void frmVisualizarUsers_Load(object sender, EventArgs e)
        {
            popularUsuarios(USerController.getAll());
        }


        private void brnEXcluir_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione na Lista", "Escolha Um User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Users ur = new Users();
                List<Users> lista = USerController.getAll();
                frmUpDateUser f = frmUpDateUser.GetInstance();
                ListViewItem item = lstUsers.SelectedItems[0];
                int id = int.Parse(item.Text);
                f.txtUsername.Text=item.SubItems[1].Text;
                foreach (Users user in lista)
                {
                    if (id == user.id)
                    {
                        f.mtxtSenha.Text = user.senha;
                    }
                    
                }
                if (!f.Visible)
                    f.ShowDialog();
                else
                    f.BringToFront();
            
                      
            }
        

            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            popularUsuarios(USerController.getAll());
        }


        private void btnSair_Click(object sender, EventArgs e)
        {

            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstUsers.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione Na Lista", "Seleccao Na Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ListViewItem item = lstUsers.SelectedItems[0];
                    Users us = new Users();
                    us.id = int.Parse(item.Text);
                    USerController.apagarUsers(us);
                    popularUsuarios(USerController.getAll());
                }
            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


    }
}