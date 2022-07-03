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
using GestaoDeParque.Model;

namespace GestaoDeParque.View
{
    public partial class frmVisualizarCor : Form
    {
        public frmVisualizarCor()
        {
            InitializeComponent();
        }

        private static frmVisualizarCor f;
        public static frmVisualizarCor GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarCor();
            }
            return f;
        }

        private void popularCor(List<Cores> lista)
        {
            lstVCor.Items.Clear();

            foreach (Cores cor in lista)
            {
                if (cor!= null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = cor.id.ToString();
                    item.SubItems.Add(cor.nomeCor);  
                    lstVCor.Items.Add(item);
                }
            }
        }


        private void frmVisualizarCor_Load(object sender, EventArgs e)
        {
            popularCor(CorController.getAll());
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroCor f = new frmCadastroCor();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }
    }
}
