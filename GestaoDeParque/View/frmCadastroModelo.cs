using System;
using System.Data;
using System.Windows.Forms;
using GestaoDeParque.Model;
using GestaoDeParque.Controller;
using System.Data.OleDb;

namespace GestaoDeParque.View
{
    public partial class frmCadastraModelo : Form
    {
        public frmCadastraModelo()
        {
            InitializeComponent();
        }

        private static frmCadastraModelo f;
        public static frmCadastraModelo GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmCadastraModelo();
            }
            return f;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void apagar()
        {
            cboMarca.Text="";
            cboTipoViatura.Text="";
            txtModelo.Text="";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
                bool erro = false; int modeloInvalido;
                if (txtModelo.Text == "")
                {
                    erro = true;
                    errProvModelo.SetError(btnViewViatura, "Preencha o Modelo");
                }
                else if(int.TryParse(txtModelo.Text, out modeloInvalido))
                {
                    erro = true;
                    errProvModelo.SetError(btnViewViatura, "Modelo Invalido");

                }
                else if (cboMarca.Text == "")
                {
                    erro = true;
                    errProvMarca.SetError(cboMarca, "Seleccionar uma Marca");
                }
                else if (cboTipoV.Text == "")
                {
                    erro = true;
                    errProvTipo.SetError(cboTipoV, "Seleccionar o Tipo de Viatura");
                }
                else
                {

                    try
                    {
                        if (!erro)
                        {

                            Viatura v = new Viatura();
                            v.id_marca = int.Parse(cboMarca.SelectedValue.ToString());
                            v.modelo = txtModelo.Text;
                            v.id_tipoViatura = int.Parse(cboTipoV.SelectedValue.ToString());
                            ModeloController.gravarViatura(v);
                            apagar();
                        }
                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

   
        private void frmCadastroViatura_Load(object sender, EventArgs e)
        {
            MarcaController.preencherComboBox(cboMarca);
            cboMarca.Text = ""; ;
            ModeloController.preencherComboBox(cboTipoV);
            cboTipoV.Text = "";
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
     
       }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewViatura_Click(object sender, EventArgs e)
        {
            frmViewModelo f = frmViewModelo.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }
        }
    }

