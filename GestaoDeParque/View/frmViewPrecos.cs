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
    public partial class frmVisualizaPreco : Form
    {
        public frmVisualizaPreco()
        {
            InitializeComponent();
        }

        private static frmVisualizaPreco f;
        public static frmVisualizaPreco GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizaPreco();
            }
            return f;
        }
        private void popularPreco(List<Precos> lista)
        {
            listViewPrecos.Items.Clear();

            foreach (Precos prc in lista)
            {
                if (prc != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = prc.id.ToString();
                    item.SubItems.Add(prc.tipoContrato);
                    item.SubItems.Add(prc.valor.ToString());

                    listViewPrecos.Items.Add(item);
                    
                }
            }
        }

        private void popularPrecoR(List<PrecosRotativos> lista)
        {
            listViewPrecos.Items.Clear();

            foreach (PrecosRotativos prc in lista)
            {
                if (prc != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = prc.id.ToString();
                    item.SubItems.Add(PrecosRotativosController.getByIdTipoViatura(prc.tipoViatura));
                    item.SubItems.Add(prc.valor.ToString());

                    listViewPrecos.Items.Add(item);

                }
            }
        }


        private void frmViewPrecos_Load(object sender, EventArgs e)
        {

            popularPreco(PrecosController.getAll());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroDePrecos f = frmCadastroDePrecos.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (listViewPrecos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione Na Lista", "Escolha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    ListViewItem item = lstVPrecos.SelectedItems[0];
                    Precos pr = new Precos();

                    pr.id = int.Parse(item.Text);
                    PrecosController.apagarPrecos(pr);
                    popularPreco(PrecosController.getAll());
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao Excluir"+ex.Message,"Erro Na Remocao",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listViewPrecos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione Na Lista", "Escolha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    ListViewItem item = listViewPrecos.SelectedItems[0];
                    frmUpdatePrecos f = frmUpdatePrecos.GetInstance();
                    f.txtTipoC.Text = item.SubItems[1].Text;
                    f.txtValorC.Text = item.SubItems[2].Text;

                    if (!f.Visible)
                    {
                        f.Show();
                    }
                    else
                    {
                        f.BringToFront();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro"+ex.Message);
                }
            }
            

        }

        private void btnRefreshR_Click(object sender, EventArgs e)
        {
            popularPreco(PrecosController.getAll());
        }

        private void rdoRotativo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRotativo.Checked)
                popularPrecoR(PrecosRotativosController.getAll());
            if(rdoMensal.Checked)
                popularPreco(PrecosController.getAll());
        }

        private void rdoMensal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRotativo.Checked)
                popularPrecoR(PrecosRotativosController.getAll());
            if (rdoMensal.Checked)
                popularPreco(PrecosController.getAll());
        }
    }
}
