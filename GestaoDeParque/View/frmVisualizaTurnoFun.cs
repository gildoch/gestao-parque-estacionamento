using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoDeParque.View;
using GestaoDeParque.Controller;
using GestaoDeParque.Model;

namespace GestaoDeParque.View
{
    public partial class frmVisualizaTurnoFun : Form
    {
        public frmVisualizaTurnoFun()
        {
            InitializeComponent();
        }

        private static frmVisualizaTurnoFun f;
        public static frmVisualizaTurnoFun GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizaTurnoFun();
            }
            return f;
        }


        private void popularTurno(List<TurnosF> lista)
        {
            listViewTurnoFun.Items.Clear();

            foreach (TurnosF tr in lista)
            {
                if (tr != null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = tr.id.ToString();
                    item.SubItems.Add(tr.turno);
                    listViewTurnoFun.Items.Add(item);
                }
            }
        }

        private void frmVisualizaTurnoFun_Load(object sender, EventArgs e)
        {
            popularTurno(TurnosController.getAll());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

            CadastroDTurnosFuncionarios f = CadastroDTurnosFuncionarios.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listViewTurnoFun.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione Na Lista", "Remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TurnosF tr  = new TurnosF();
                ListViewItem item = listViewTurnoFun.SelectedItems[0];
                
                tr.id =int.Parse(item.Text);
                TurnosController.apagarTurnos(tr);
                popularTurno(TurnosController.getAll());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            popularTurno(TurnosController.getAll());
        }
    }
}
