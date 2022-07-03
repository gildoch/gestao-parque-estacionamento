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
    public partial class frmViewCliente : Form
    {
        public frmViewCliente()
        {
            InitializeComponent();
        }

        private static frmViewCliente f;
        public static frmViewCliente GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmViewCliente();
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

                    item.Text = c.id.ToString();
                    item.SubItems.Add(c.nome);
                    item.SubItems.Add(c.bi);
                    item.SubItems.Add(c.contacto);
                    item.SubItems.Add(c.endereco);
                    item.SubItems.Add(c.tipoContrato);
                    item.SubItems.Add(ClienteController.getById(c.tipo));
                    lstCliente.Items.Add(item);
                }
            }
        }


        private void frmViewCliente_Load(object sender, EventArgs e)
        {
            popularCliente(ClienteController.getAll());
        }

       
        private void btnsevect_Click(object sender, EventArgs e)
        {
           
            if (lstCliente.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleciona na lista:", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    ListViewItem item = lstCliente.SelectedItems[0];
                    frmClienteCadastro f = frmClienteCadastro.GetInstance();
                    f.txtIdClienteContrat.Text = item.Text;
                    f.txtClienteContrato.Text = item.SubItems[1].Text;
                    f.txtProprietario.Text = item.Text;
                    f.txtPropNome.Text = item.SubItems[1].Text;


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

                    MessageBox.Show("Erro na gravacao:"+ex.Message, "Erro" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}