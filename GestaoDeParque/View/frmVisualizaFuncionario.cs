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
    public partial class frmVisualizaFuncionario : Form
    {
        public frmVisualizaFuncionario()
        {
            InitializeComponent();
        }

        private static frmVisualizaFuncionario f;
        public static frmVisualizaFuncionario GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizaFuncionario();
            }
            return f;
        }

        private void frmVisualizaFuncionario_Load(object sender, EventArgs e)
        {
            popularFun(FuncionarioController.getAll());
        }

        private void popularFun(List<Funcionario> lista)
        {
            List<Perfil> listaP = PerfilController.getAll();
            List<Users> listaU = USerController.getAll();
            List<TurnosF> listaT= TurnosController.getAll();  
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
                    
                    foreach (TurnosF tr in listaT)
                    {
                        if(via.turno==tr.id.ToString())
                        item.SubItems.Add(tr.turno);
                    }
                    item.SubItems.Add(via.email);
                    foreach (Users u in listaU)
                    {

                        if (via.id.Equals(u.id_Funcionario.ToString()))
                            item.SubItems.Add(u.userName);
                                                                      
                    }

                    
                    lstFuncionario.Items.Add(item);
                    
                }
            }
        }

        private void lstFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (frmMenu.permissao.Equals("Administrador"))
            {
                frmCadastroFuncionario f = frmCadastroFuncionario.GetInstance();
                if (!f.Visible)
                    f.ShowDialog();
                else
                    f.BringToFront();
            }
            else
            {
                MessageBox.Show("Sem permissao para Adicionar Funcionario", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                frmUpdateFuncionario f = frmUpdateFuncionario.GetInstance();
                if (lstFuncionario.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione Na Lista", "Escolha", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ListViewItem item = lstFuncionario.SelectedItems[0];
                    int id = int.Parse(item.Text);
                    f.txtNome.Text = item.SubItems[1].Text;
                    f.txtEndereco.Text = item.SubItems[2].Text;
                    f.txtContacto.Text = item.SubItems[3].Text;
                    f.txtEmail.Text = item.SubItems[5].Text;
                    if (!f.Visible)
                        f.ShowDialog();
                    else
                        f.BringToFront();


                }
            }
            else
            {
                MessageBox.Show("Sem permissao para Alterar Funcionario", "Alterar Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstFuncionario.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione Na Lista", "Escolha", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ListViewItem item = lstFuncionario.SelectedItems[0];
                    Funcionario f = new Funcionario();

                    f.id = item.Text;
                    FuncionarioController.apagarFuncionario(f);
                    popularFun(FuncionarioController.getAll());

                }
            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            popularFun(FuncionarioController.getAll());
        }

    }
}
