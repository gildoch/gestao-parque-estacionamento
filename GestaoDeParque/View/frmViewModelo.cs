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
using GestaoDeParque.View;
using GestaoDeParque.Controller;

namespace GestaoDeParque.View
{
    public partial class frmViewModelo : Form
    {
        public frmViewModelo()
        {
            InitializeComponent();
        }


        private static frmViewModelo f;
        public static frmViewModelo GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmViewModelo();
            }
            return f;
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


        private void frmViewViatura_Load(object sender, EventArgs e)
        {
            frmVisualizarDetalhesDeViaturas f = new frmVisualizarDetalhesDeViaturas();
            
            popularViatura(ModeloController.obeterRegistoDeViatura());
        }
    }
}
