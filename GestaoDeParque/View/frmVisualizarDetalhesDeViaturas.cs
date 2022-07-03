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
using System.Data.OleDb;


namespace GestaoDeParque.View
{
    public partial class frmVisualizarDetalhesDeViaturas : Form
    {
        public frmVisualizarDetalhesDeViaturas()
        {
            InitializeComponent();
        }

        private static frmVisualizarDetalhesDeViaturas f;
        public static frmVisualizarDetalhesDeViaturas GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarDetalhesDeViaturas();
            }
            return f;
        }

        


        private void frmVisualizarViatura_Load(object sender, EventArgs e)
        {
            popularMarca(MarcaController.getAll());
            popularCor(CorController.getAll());
            popularViatura(ModeloController.obeterRegistoDeViatura());
            
        }

        private void popularMarca(List<Marca> lista)
        {
            lstVMarca.Items.Clear();

            foreach (Marca mar in lista)
            {
                if (mar != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mar.id.ToString();
                    item.SubItems.Add(mar.descricaoM);
                    lstVMarca.Items.Add(item);
                }
            }
        }

        private void popularCor(List<Cores> lista)
        {
            lstVCor.Items.Clear();

            foreach (Cores cor in lista)
            {
                if (cor != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = cor.id.ToString();
                    item.SubItems.Add(cor.nomeCor);
                    lstVCor.Items.Add(item);
                }
            }
        }

        private void popularViatura(List<Parametrizacao> lista)
        {
            lstViatura.Items.Clear();

            foreach (Parametrizacao via in lista)
            {
                if (via != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = via.codigo.ToString();
                    item.SubItems.Add(via.tipo.ToString());
                    item.SubItems.Add(via.modelo);
                    item.SubItems.Add(via.marca.ToString());  
                    lstViatura.Items.Add(item);
                   
                }
            }
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            frmCadastraModelo f = frmCadastraModelo.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastraModelo f = frmCadastraModelo.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadastraMarca f = frmCadastraMarca.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCadastroCor f = new frmCadastroCor();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstVCor.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione Na Lista", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cores cor = new Cores();
                    ListViewItem item = lstVCor.SelectedItems[0];
                    int id = int.Parse(item.Text);
                    cor.id = id.ToString();
                    CorController.apagarCor(cor);
                    popularCor(CorController.getAll());
                }
            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstVMarca.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione Na Lista", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Marca mar = new Marca();
                    ListViewItem item = lstVMarca.SelectedItems[0];
                    int id = int.Parse(item.Text);
                    mar.id = id.ToString();
                    MarcaController.apagarMarca(mar);
                    popularMarca(MarcaController.getAll());
                }
            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (frmMenu.permissao.Equals("Administrador"))
            {
                if (lstViatura.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione Na Lista", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Viatura via = new Viatura();
                    ListViewItem item = lstViatura.SelectedItems[0];
                    int id = int.Parse(item.Text);
                    via.id = int.Parse(id.ToString());
                    ModeloController.apagarViatura(via);
                    popularViatura(ModeloController.obeterRegistoDeViatura());
                }
            }
            else
            {
                MessageBox.Show("Sem permissao para remover", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
           
            if (lstViatura.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione Na Lista", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {

                    ListViewItem item = lstViatura.SelectedItems[0];

                    frmUpdateModelo f = frmUpdateModelo.GetInstance();


                    f.txtModelo.Text = item.SubItems[2].Text;
                    f.cboMarca.Items.Add(item.SubItems[3].Text);
                    f.cboTipoV.Items.Add(item.SubItems[1].Text);

                    if (!f.Visible)
                    {
                        f.Show();

                    }
                    else
                    {
                        f.BringToFront();

                    }

                    Viatura via = new Viatura();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            popularMarca(MarcaController.getAll());
            popularCor(CorController.getAll());
            popularViatura(ModeloController.obeterRegistoDeViatura());
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            popularMarca(MarcaController.getAll());
            popularCor(CorController.getAll());
            popularViatura(ModeloController.obeterRegistoDeViatura());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            popularMarca(MarcaController.getAll());
            popularCor(CorController.getAll());
            popularViatura(ModeloController.obeterRegistoDeViatura());
        }
    }
}
