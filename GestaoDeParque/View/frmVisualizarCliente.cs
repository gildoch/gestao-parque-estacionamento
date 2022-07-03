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
    public partial class frmVisualizarCliente : Form
    {
        public frmVisualizarCliente()
        {
            InitializeComponent();
        }

        private static frmVisualizarCliente f;
        public static frmVisualizarCliente GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarCliente();
            }
            return f;
        }
        private void popularCliente(List<Cliente> lista)
        {
            lstCliente.Items.Clear();
            
            foreach (Cliente c in lista)
            {
                if (c != null)
                {
                    ListViewItem item = new ListViewItem();                   
                    List<Contratos> listaCon = ContratoController.getById(c.id);
                    item.Text =c.id.ToString();                  
                    item.SubItems.Add(c.nome);
                    item.SubItems.Add(c.bi);                
                    item.SubItems.Add(c.endereco);
                    item.SubItems.Add(c.contacto);                    
                    item.SubItems.Add(ClienteController.getById(c.tipo));
                   
                    foreach (Contratos conn in listaCon)
                    {
                        if (conn != null)
                        {
                            item.SubItems.Add(conn.id.ToString());
                            //item.SubItems.Add(conn.idTipoContrato);
                            item.SubItems.Add(PrecosController.getById(conn.idTipoContrato));
                            item.SubItems.Add(conn.inicioDeContrato.ToShortDateString());
                            item.SubItems.Add(conn.inicioDeContrato.ToShortDateString());

                        }

                    }
                    lstCliente.Items.Add(item);
                }
            }
        }


        private void frmVisualizarCliente_Load(object sender, EventArgs e)
        {
            popularCliente(ClienteController.getAll());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmClienteCadastro f = frmClienteCadastro.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
                this.Close();
            }
            else
                f.BringToFront();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnViaturas_Click(object sender, EventArgs e)
        {
            frmVisualizarViaturasDoCliente f = frmVisualizarViaturasDoCliente.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
                f.btnSelecionar.Visible = false;
                
            }
            else
            {
                f.BringToFront();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstCliente.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleciona na lista:", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lstCliente.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleciona na lista:", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Todos Registos referentes ao cliente serao apagados(Cliente,viaturas,contratos)", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {

                        ListViewItem item = lstCliente.SelectedItems[0];
                        Cliente c = new Cliente();
                        ViaturaCliente v = new ViaturaCliente();
                        Contratos con = new Contratos();
                        c.id = int.Parse(item.Text);
                        v.id = int.Parse(item.Text);
                        con.id = int.Parse(item.Text);
                        ClienteController.apagarCliente(c);
                        ViaturaClienteController.apagarCliente(v);
                        ContratoController.apagarContrato(con);
                        popularCliente(ClienteController.getAll());
                    }
                    else
                    {
                    }
                }



            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            popularCliente(ClienteController.getAll());
        }
    }
}
