using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestaoDeParque.Controller;
using GestaoDeParque.Model;

namespace GestaoDeParque.View
{
    public partial class frmUpdateFuncionario : Form
    {
        public frmUpdateFuncionario()
        {
            InitializeComponent();
        }


        private static frmUpdateFuncionario f;
        public static frmUpdateFuncionario GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmUpdateFuncionario();
            }
            return f;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            int nomeInvalido,enderecoInvalido,ContactoCerto;
            
            if (txtNome.Text == "")
            {
                erro = true;
                erroProvNome.SetError(txtNome, "Preencha o Nome");
            }
            else if (int.TryParse(txtNome.Text, out nomeInvalido))
            {
                erro = true;
                erroProvNome.SetError(txtNome, "Nome Invalido");
            }
            else if (txtEndereco.Text == "")
            {
                erro = true;
                erroProvEndereco.SetError(txtEndereco, "Preencha o endereco");
            }
            else if (int.TryParse(txtEndereco.Text, out enderecoInvalido))
            {
                erro = true;
                erroProvEndereco.SetError(txtEndereco, "Endereco Invalido");
            }
            else if (txtContacto.Text == "")
            {
                erro = true;
                erroProvContacto.SetError(txtContacto, "Preencha o Cantacto");
            }
            else if (!int.TryParse(txtContacto.Text, out ContactoCerto))
            {
                erro = true;
                erroProvContacto.SetError(txtContacto, "Contacto Invalido");
            }
            else if (txtEmail.Text == "")
            {
                erro = true;
                erroProvEmail.SetError(txtEmail, "Preencha o Email");
            }
            else
            {

                if (!erro)
                {
                    try
                    {
                        frmVisualizaFuncionario f = frmVisualizaFuncionario.GetInstance();
                        ListViewItem item = f.lstFuncionario.SelectedItems[0];
                        Funcionario fun = new Funcionario();

                        fun.id = item.Text;
                        fun.nome = txtNome.Text;
                        fun.contacto = txtContacto.Text;
                        fun.endereco = txtEndereco.Text;
                        fun.email = txtEmail.Text;
                        fun.turno = cboTurno.SelectedValue.ToString();
                        FuncionarioController.ActualizarFuncionario(fun);
                        limpaDados();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao actualizar dados" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void limpaDados()
        {
            txtNome.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";          
            cboTurno.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void frmUpdateFuncionario_Load(object sender, EventArgs e)
        {
            TurnosController.preencherComboBox(cboTurno);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
