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
using GestaoDeParque.View;
using System.Data.OleDb;

namespace GestaoDeParque.View
{
    public partial class frmUpdateModelo : Form
    {
        public frmUpdateModelo()
        {
            InitializeComponent();
        }

        private static frmUpdateModelo f;
        public static frmUpdateModelo GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmUpdateModelo();
            }
            return f;
        }

        private void preencherCboMarca()
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Marcas";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                cboMarca.DataSource = dtResultado;

                cboMarca.DisplayMember = "DescricaoM";

                cboMarca.ValueMember = "ID";

                cboMarca.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                da.Dispose();
                conn.Close();
            }

        }


        private void preencherCboTipo()
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Tipo_Viatura";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                cboTipoV.DataSource = dtResultado;

                cboTipoV.DisplayMember = "Tipo";

                cboTipoV.ValueMember = "ID";

                cboTipoV.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                da.Dispose();
                conn.Close();
            }

        }

        private void frmUpdateModelo_Load(object sender, EventArgs e)
        {
            preencherCboMarca();
            cboMarca.Text = "";
            preencherCboTipo();
            cboTipoV.Text = "";
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apagar()
        {
            cboMarca.Text = "";
            cboTipoV.Text = "";
            txtModelo.Text = "";
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
               
                bool erro = false; int modeloInvalido;
                if (txtModelo.Text == "")
                {
                    erro = true;
                    errProvModelo.SetError(txtModelo, "Preencha o Modelo");
                }
                else if(int.TryParse(txtModelo.Text, out modeloInvalido))
                {
                    erro = true;
                    errProvModelo.SetError(txtModelo, "Modelo Invalido");

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
                            frmVisualizarDetalhesDeViaturas f = frmVisualizarDetalhesDeViaturas.GetInstance();
                            ListViewItem item = f.lstViatura.SelectedItems[0];
                            Viatura v = new Viatura();
                            int id = int.Parse(item.Text);
                            v.id = id;
                            v.id_marca = int.Parse(cboMarca.SelectedValue.ToString());
                            v.modelo = txtModelo.Text;
                            v.id_tipoViatura = int.Parse(cboTipoV.SelectedValue.ToString());
                            ModeloController.updateViatura(v);
                            apagar();
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha no evento click do butao" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
}
