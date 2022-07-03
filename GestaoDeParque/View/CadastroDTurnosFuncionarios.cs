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
using GestaoDeParque.Model;
using GestaoDeParque.Controller;
namespace GestaoDeParque.View
{
    public partial class CadastroDTurnosFuncionarios : Form
    {
        public CadastroDTurnosFuncionarios()
        {
            InitializeComponent();
        }

        private static CadastroDTurnosFuncionarios f;
        public static CadastroDTurnosFuncionarios GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new CadastroDTurnosFuncionarios();
            }
            return f;
        }

        private void CadastroDTurnosFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void btnLookTurnos_Click(object sender, EventArgs e)
        {
            frmVTurnoFun f = frmVTurnoFun.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void apagar()
        {
            txtTurnoF.Text = "";
        }

        private void btnConfiirmar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int TurnoInvalido;
            if (txtTurnoF.Text == "")
            {
                erro = true;
                erroProvTurno.SetError(btnLookTurnos, "Preencha o Turno");
            }
            else if (int.TryParse(txtTurnoF.Text, out TurnoInvalido))
            {
                erro = true;
                erroProvTurno.SetError(btnLookTurnos, "Turno Invalido");
            }
            else
            {
                try
                {

                    if (!erro)
                    {
                        TurnosF trn = new TurnosF();

                        trn.turno = txtTurnoF.Text;
                        TurnosController.gravarTurnos(trn);
                        apagar();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         
        }
    }
}
