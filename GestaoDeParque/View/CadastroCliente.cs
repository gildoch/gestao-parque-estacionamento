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
using GestaoDeParque.Controller;
using GestaoDeParque.View;
using System.Data.OleDb;

namespace GestaoDeParque.View
{
    public partial class frmClienteCadastro : Form
    {
        public frmClienteCadastro()
        {
            InitializeComponent();
        }
        private static frmClienteCadastro f;
        public static frmClienteCadastro GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f=new frmClienteCadastro();
            }
            return f;
        }

  
        private void preencherCboTipoCliente()
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM RegimeDeCliente";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                cboTipoCliente.DataSource = dtResultado;

                cboTipoCliente.DisplayMember = "TipoDeCliente";

                cboTipoCliente.ValueMember = "ID";

                cboTipoCliente.Enabled = true;
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

        private void frmClienteCadastro_Load(object sender, EventArgs e)
        {
            cboNrViaturas.Items.Add("1");
            cboNrViaturas.Items.Add("2");
            cboNrViaturas.Items.Add("3");
            cboNrViaturas.Items.Add("4");
            cboNrViaturas.Items.Add("5");
            cboNrViaturas.Items.Add("6");
            cboNrViaturas.Items.Add("7");
            cboNrViaturas.Items.Add("8");
            cboNrViaturas.Items.Add("9");
            cboNrViaturas.Items.Add("10");

            PrecosController.preencherComboBox(cboRegimeDeContrato);
            ClienteController.preencherComboBox(cboTipoCliente);           
            CorController.preencherComboBox(cboCorVi);     
            ModeloController.preencherComboBoxModelo(cboModelo);        
            ModeloController.preencherComboBox(cboTipoViatura);
            
            txtIdCliente.Enabled = false;  
        }
        

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaDados();
        }
        private void limpaDados()
        {
            txtBi.Text = "";
            txtContacto.Text = "";
            txtEndereco.Text = "";
            txtIdCliente.Text = "";
            txtNomeCliente.Text = "";
            cboTipoCliente.SelectedIndex = -1;
            txtNomeCliente.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                bool erro = false;
                if (!erro)
                {
                    Cliente client = new Cliente();
                    client.bi = txtBi.Text;
                    client.nome = txtNomeCliente.Text;
                    client.endereco = txtEndereco.Text;
                    client.contacto = txtContacto.Text;
                    
                    ClienteController.gravarCliente(client);
                    limpaDados();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message, "Erro no Click da gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGravarCliente_Click_1(object sender, EventArgs e)
        {
            bool erro = false;
            
     
          try
            {
                
                if (!erro)
                {
                    
                    Cliente c = new Cliente();
                    c.bi = txtBi.Text;
                    c.nome = txtNomeCliente.Text;
                    c.endereco = txtEndereco.Text;
                    c.contacto = txtContacto.Text;
                    //c.tipoContrato = cboRegimeDeContrato.SelectedValue.ToString();
                    c.tipo = cboTipoCliente.SelectedValue.ToString();
                    ClienteController.gravarCliente(c);
                    limpaDados();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            limpaDados();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

       
        
     
      

        private void limpaDadosViatura()
        {
            txtMatriculaVi.Text = "";
            cboMarcaVi.SelectedIndex = -1;
            cboModeloVi.SelectedIndex = -1;
            cboCorVi.SelectedIndex = -1;
            cboTipoViatura.SelectedIndex = -1;
            txtProprietario.Text = "";
            txtPropNome.Text = "";
            cboMarcaVi.Focus();
        }
        private void btnGravarViatura_Click(object sender, EventArgs e)
        {
            try
            {
                bool erro = false;
                if (!erro)
                {
                    
                    ViaturaCliente vi = new ViaturaCliente();

                   
                    vi.id_cor = int.Parse(cboCorVi.SelectedValue.ToString());
                    //vi.id_marca = int.Parse(cboMarca.SelectedValue.ToString());
                    vi.id_modelo = int.Parse(cboModelo.SelectedValue.ToString());
                    vi.id_tipoViatura = int.Parse(cboTipoViatura.SelectedValue.ToString());
                    vi.id_cliente = int.Parse(txtProprietario.Text.ToString());
                    vi.matricula = txtMatriculaVi.Text;
                    ViaturaClienteController.gravarViaturaCliente(vi);
                    limpaDadosViatura();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao grvar viatura:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimparViatura_Click(object sender, EventArgs e)
        {
            limpaDadosViatura();
        }

        private void ptbProprietario_Click(object sender, EventArgs e)
        {
            frmViewCliente f = frmViewCliente.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmViewCliente f = frmViewCliente.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
            }
            else
            {
                f.BringToFront();
            }




           
        

        }
        private void preencherCboRegimeDeContrato()
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM RegimeDeContrato";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                cboRegimeDeContrato.DataSource = dtResultado;

                cboRegimeDeContrato.DisplayMember = "TipoDeContrato";

                cboRegimeDeContrato.ValueMember = "ID";

                cboRegimeDeContrato.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Erro no metodo preencher cboRegimeDeContrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                da.Dispose();
                conn.Close();
            }

        }
       
        private void btnGravarCont_Click(object sender, EventArgs e)
        {
            try
            {
                bool erro = false;
                if (!erro)
                {
                    
                    Contratos cont = new Contratos();
                    cont.idViatura = txtIdViaturaContrato.Text;
                    cont.idCliente = txtIdClienteContrat.Text;
                    cont.idTipoContrato = cboRegimeDeContrato.SelectedValue.ToString();                  
                    cont.numeroDeViaturas = int.Parse(cboNrViaturas.Text.ToString());
                    cont.inicioDeContrato = ContratoController.GetWithHour(DateTime.Parse(dtpInicio.Value.ToString()));
                    cont.fimDeContrato = ContratoController.GetWithHour(DateTime.Parse(dtpFim.Value.ToString()));
                    ContratoController.gravarContratos(cont);
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCont_Click(object sender, EventArgs e)
        {
            txtIdClienteContrat.Text = "";
            txtIdViaturaContrato.Text = "";
            txtClienteContrato.Text = "";
         
            
            cboRegimeDeContrato.SelectedIndex = -1;
            cboNrViaturas.SelectedIndex = -1;
        }

        private void btnSairContrato_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmVisualizarViaturasDoCliente f = frmVisualizarViaturasDoCliente.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
                f.btnSelecionar.Visible = true;
              
               
            }

            else
                f.BringToFront();
        }

        private void cboRegimeDeContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboMarca_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //int id = int.Parse(cboMarca.SelectedValue.ToString());
           // ModeloController.preencherComboBoxModelo(cboModelo, id);

        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
