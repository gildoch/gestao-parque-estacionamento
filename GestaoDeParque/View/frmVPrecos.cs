using GestaoDeParque.Controller;
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

namespace GestaoDeParque.View
{
    public partial class frmVPrecos : Form
    {
        public frmVPrecos()
        {
            InitializeComponent();
        }

        private static frmVPrecos f;
        public static frmVPrecos GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVPrecos();
            }
            return f;
        }
        private void popularPreco(List<Precos> lista)
        {
            listVPrecos.Items.Clear();

            foreach (Precos prc in lista)
            {
                if (prc != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = prc.id.ToString();
                    item.SubItems.Add(prc.tipoContrato);
                    item.SubItems.Add(prc.valor.ToString());

                    listVPrecos.Items.Add(item);

                }
            }
        }

        private void frmVPrecos_Load(object sender, EventArgs e)
        {
            popularPreco(PrecosController.getAll());
        }
    }
}
