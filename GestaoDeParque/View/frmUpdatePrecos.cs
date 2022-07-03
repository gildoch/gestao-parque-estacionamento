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
using GestaoDeParque.View;
using GestaoDeParque.Model;

namespace GestaoDeParque.View
{
    public partial class frmUpdatePrecos : Form
    {
        public frmUpdatePrecos()
        {
            InitializeComponent();
        }

        private static frmUpdatePrecos f;
        public static frmUpdatePrecos GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmUpdatePrecos();
            }
            return f;
        }

        private void frmUpdatePrecos_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int tipoInvalido;
            double valorCerto;
            if (txtTipoC.Text == "")
            {
                erro = true;
                errprovTipo.SetError(txtTipoC, "Preencha O Tipo de Contrato");
            }
            else if (int.TryParse(txtTipoC.Text, out tipoInvalido))
            {
                erro = true;
                errprovTipo.SetError(txtTipoC, "Tipo de Contrato Invalido");
            }
            else if (txtValorC.Text == "")
            {
                erro = true;
                errProvValor.SetError(txtValorC, "Preencha O Valor");
            }
            else if (!double.TryParse(txtValorC.Text, out valorCerto))
            {
                erro = true;
                errProvValor.SetError(txtValorC, "Valor Invalido");
            }
            else
            {
                if (!erro)
                {
                    try
                    {
                        frmVisualizaPreco f = frmVisualizaPreco.GetInstance();
                        ListViewItem item = f.listViewPrecos.SelectedItems[0];
                        Precos prec = new Precos();
                        prec.id = int.Parse(item.Text);
                        prec.tipoContrato = txtTipoC.Text;
                        prec.valor = int.Parse(txtValorC.Text);
                        PrecosController.actualizarPrecos(prec);
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro De Actualizacao"+ex.Message,"Actualizar Precos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
