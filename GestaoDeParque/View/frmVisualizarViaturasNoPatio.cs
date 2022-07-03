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
    public partial class frmVisualizarViaturasNoPatio : Form
    {
        public frmVisualizarViaturasNoPatio()
        {
            InitializeComponent();
        }

        private static frmVisualizarViaturasNoPatio f;
        public static frmVisualizarViaturasNoPatio GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizarViaturasNoPatio();
            }
            return f;
        }



        private void popularViaturasPatio(List<Entrada_Saida> lista)
        {
            lstViaturaPatio.Items.Clear();

            foreach (Entrada_Saida c in lista)
            {
                if (c != null)
                {
                   if(c.status.Equals("No Patio"))
                   {
                       ListViewItem item = new ListViewItem();
                       item.Text = c.id.ToString();
                       item.SubItems.Add(c.matricula);
                       item.SubItems.Add(ModeloController.getById(c.modelo));
                       //item.SubItems.Add(c.modelo.ToString());
                       item.SubItems.Add(CorController.getById(c.cor));
                       item.SubItems.Add(c.dataEntrada.ToShortDateString());
                       item.SubItems.Add(c.HoraEntrada.ToLongTimeString());
                       item.SubItems.Add(c.idFuncionario.ToString());
                       item.SubItems.Add(c.status);
                       lstViaturaPatio.Items.Add(item);
                   }

                }
            }
        }


        private void popularViaturasPatioSaida(List<Entrada_Saida> lista)
        {
            lstViaturaPatio.Items.Clear();

            foreach (Entrada_Saida c in lista)
            {
                if (c != null)
                {
                    if (c.status.Equals("Retirado"))
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = c.id.ToString();
                        item.SubItems.Add(c.matricula);
                        item.SubItems.Add(ModeloController.getById(c.modelo));
                        item.SubItems.Add(CorController.getById(c.cor));
                        item.SubItems.Add(c.dataEntrada.ToShortDateString());
                        item.SubItems.Add(c.HoraEntrada.ToLongTimeString());
                        item.SubItems.Add(c.idFuncionario.ToString());
                        item.SubItems.Add(c.status);
                        item.SubItems.Add(c.dataSaida.ToShortDateString());
                        item.SubItems.Add(c.HoraSaida.ToLongTimeString());
                        item.SubItems.Add(c.idFuncionarioS.ToString());
                        lstViaturaPatio.Items.Add(item);
                    }

                }
            }
        }


        private void frmVisualizarViaturasNoPatio_Load(object sender, EventArgs e)
        {
            popularViaturasPatio(EntradaSaidaController.getAll());
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.Text.Equals("Retirados"))
            {
                popularViaturasPatioSaida(EntradaSaidaController.getAllSaida());
            }
            if (cboStatus.Text.Equals("Estacionados"))
            {
                popularViaturasPatio(EntradaSaidaController.getAll());
            }
            if (cboStatus.Text.Equals("Tudo"))
            {
                //popularViaturasPatio(EntradaSaidaController.getAll())+
                //popularViaturasPatioSaida(EntradaSaidaController.getAllSaida());
            }
        }

        private void lstViaturaPatio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
