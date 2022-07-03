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
    public partial class frmVisualizaMarca : Form
    {
        public frmVisualizaMarca()
        {
            InitializeComponent();
        }

        private static frmVisualizaMarca f;
        public static frmVisualizaMarca GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizaMarca();
            }
            return f;
        }


        private void frmVisualizaMarca_Load(object sender, EventArgs e)
        {
            popularMarca(MarcaController.getAll());
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

        private void btnNovo_Click(object sender, EventArgs e)
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

    }
}
