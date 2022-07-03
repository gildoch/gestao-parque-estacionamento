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
    public partial class frmVTurnoFun : Form
    {
        public frmVTurnoFun()
        {
            InitializeComponent();
        }

        private static frmVTurnoFun f;
        public static frmVTurnoFun GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVTurnoFun();
            }
            return f;
        }

        private void popularTurno(List<TurnosF> lista)
        {
            lstVTurnoFun.Items.Clear();

            foreach (TurnosF tr in lista)
            {
                if (tr != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = tr.id.ToString();
                    item.SubItems.Add(tr.turno);
                    lstVTurnoFun.Items.Add(item);
                }
            }
        }

        private void frmVTurnoFun_Load(object sender, EventArgs e)
        {
            popularTurno(TurnosController.getAll());
        }
    }
}
