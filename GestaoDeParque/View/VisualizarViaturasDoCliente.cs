using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestaoDeParque.Model;
using GestaoDeParque.View;
using GestaoDeParque.Controller;

namespace GestaoDeParque.View
{
    public partial class frmVisualizarViaturasDoCliente : Form
    {
        public frmVisualizarViaturasDoCliente()
        {
            InitializeComponent();
        }

        private static frmVisualizarViaturasDoCliente f;
        public static frmVisualizarViaturasDoCliente GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarViaturasDoCliente();
            }
            return f;
        }



        private void lstVwViaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void frmVisualizarViaturasDoCliente_Load(object sender, EventArgs e)
        {

         
            frmVisualizarViaturasDoCliente f = new frmVisualizarViaturasDoCliente();

            popularViaturasCliente(ViaturaClienteController.getAll());
        }

        private void popularViaturasCliente(List<ViaturaCliente> lista)
        {
            lstVwViaturas.Items.Clear();

            foreach (ViaturaCliente c in lista)
            {
                if (c != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = c.id.ToString();
                    item.SubItems.Add(ModeloController.getById(c.id_modelo));
                    //item.SubItems.Add(c.id_cor.ToString());
                    item.SubItems.Add(CorController.getById(c.id_cor));
                    //item.SubItems.Add(c.id_marca.ToString());
                    //item.SubItems.Add(c.id_tipoViatura.ToString());
                    item.SubItems.Add(ClienteController.getByIdNomeCliente(c.id_cliente));
                    item.SubItems.Add(c.matricula.ToString());
                    lstVwViaturas.Items.Add(item);

                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            
                
        
    }

        private void btnSelecionar_Click_1(object sender, EventArgs e)
        {
            
            if (lstVwViaturas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleciona na lista:", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    ListViewItem item = lstVwViaturas.SelectedItems[0];
                    frmClienteCadastro f = frmClienteCadastro.GetInstance();
                    f.txtIdViaturaContrato.Text = item.Text;
                    //f.txtViaturaContrato.Text = item.SubItems[0].Text;


                    if (!f.Visible)
                    {
                        f.Show();
                       
                    }
                    else
                    {
                        f.BringToFront();
                    }
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro na gravacao:", "Erro" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
                
        }
}
    }
}