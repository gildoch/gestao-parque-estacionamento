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
using GestaoDeParque.Controller;

namespace GestaoDeParque.View
{
    public partial class frmViewFuncionario : Form
    {
        public frmViewFuncionario()
        {
            InitializeComponent();
        }

        private static frmViewFuncionario f;
        public static frmViewFuncionario GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmViewFuncionario();
            }
            return f;
        }

        private void popularFun(List<Funcionario> lista)
        {
            lstFuncionario.Items.Clear();

            foreach (Funcionario via in lista)
            {
                if (via != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = via.id.ToString();
                    item.SubItems.Add(via.nome);
                    item.SubItems.Add(via.endereco);
                    item.SubItems.Add(via.contacto);
                    item.SubItems.Add(via.turno);
                    //item.SubItems.Add(via.userName);
                    item.SubItems.Add(via.email);
                    lstFuncionario.Items.Add(item);

                }
            }
        }


        private void frmViewFuncionario_Load(object sender, EventArgs e)
        {
            popularFun(FuncionarioController.getAll());
        }

        private void lstFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstFuncionario.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione Na Lista", "Escolha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmCadastroUser f = frmCadastroUser.GetInstance();
                ListViewItem item = lstFuncionario.SelectedItems[0];
                f.txtId.Text = item.Text;
                f.txtNome.Text = item.SubItems[1].Text;
                this.Close();
                if (!f.Visible)
                    f.ShowDialog();
                else
                    f.BringToFront();
            }
            }
            
    }
}
