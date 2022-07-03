using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using GestaoDeParque.Conexão;
using System.Threading;
using GestaoDeParque.Model;
using GestaoDeParque.Controller;
namespace GestaoDeParque.View
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            Thread t = new Thread(new ThreadStart(splash));
            t.Start();
            Thread.Sleep(1000);

            InitializeComponent();

            t.Abort();

        }
        private static frmMenu f;
        public static frmMenu GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmMenu();
            }
            return f;
        }

        public void splash()
        {
            Application.Run(new frmSplashScreem());
        }


        public static string permissao;
        public static string permi()
        {
            return permissao;
        }

        public static int idFun;

        private void trazerTotalPatio()
        {
            List<Entrada_Saida> lista = EntradaSaidaController.getAll();
            foreach (Entrada_Saida vi in lista)
            {
                if (vi.status.Equals("No Patio"))
                {
                    int total = lista.Count;

                    lblTotalPatio.Text = total.ToString();

                }
            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            //trazerTotalPatio();
            lblTotalPatio.Text =EntradaSaidaController.Count().ToString();
            lblUser.Text = frmLogin.user();
            int perfilId = USerController.getDescription(frmLogin.user());
            idFun = USerController.getFunId(frmLogin.user());
            lblPerfil.Text = USerController.getDescription(frmLogin.user()).ToString();
            lblPerfil.Text = PerfilController.getById(perfilId);
           permissao = lblPerfil.Text;
           lblData.Text = DateTime.Now.ToShortDateString();
           CorController.preencherComboBox(cboCor);
           ModeloController.preencherComboBoxModelo(cboModelo);
           
          
            OleDbConnection conn = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();
                //MessageBox.Show("Bem vindo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar com a base de dados"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem certeza k deseja sair da app?", "Closing app confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteCadastro f = frmClienteCadastro.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        
        private void viaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastraModelo f = frmCadastraModelo.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void corToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastroCor f = frmCadastroCor.GetInstance();

            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastraMarca f = frmCadastraMarca.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void definicoesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viaturaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmVisualizarDetalhesDeViaturas f = frmVisualizarDetalhesDeViaturas.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void precosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizaPreco f = frmVisualizaPreco.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }

   }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionario f = frmCadastroFuncionario.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void segurancaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void turnosDoFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizaTurnoFun f = frmVisualizaTurnoFun.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void cadastrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bloqueioDeViaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroBloqueioViaturas f = frmCadastroBloqueioViaturas.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss"); 
        }

        private void btnSairSistema_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Saindo do Sistema?", "Confirmar Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dr==DialogResult.Yes)
            Application.Exit();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVisualizarUsers f = frmVisualizarUsers.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmVisualizaFuncionario f = frmVisualizaFuncionario.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmVisualizarDetalhesDeViaturas f = frmVisualizarDetalhesDeViaturas.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmVisualizaPreco f = frmVisualizaPreco.GetInstance();
            if (!f.Visible)
            {
                f.Show();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmAjuda f = frmAjuda.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjuda f = frmAjuda.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            lblText.Text ="Entrada De viatura Cancelada";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            lblText.Text ="Saida De viatura Cancelada";
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmVisualizarCliente f = frmVisualizarCliente.GetInstance();
            if (!f.Visible)
                f.ShowDialog();
            else
                f.BringToFront();
        }

        private void viaturasDosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<ViaturaCliente> lista = ViaturaClienteController.getAll();
            foreach (ViaturaCliente via in lista)
            {
                if (txtMatriculaEntrada.Text.Equals(via.matricula))
                {

                }
                else
                {
                    try
                    {
                        bool erro = false;
                        if (!erro)
                        {


                            int ids = idFun;
                            Entrada_Saida vi = new Entrada_Saida();
                            vi.matricula = txtMatriculaEntrada.Text;
                            vi.cor = int.Parse(cboCor.SelectedValue.ToString());
                            vi.modelo = int.Parse(cboModelo.SelectedValue.ToString());
                            vi.dataEntrada = DateTime.Parse(DateTime.Now.ToShortDateString());
                            vi.HoraEntrada = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));
                            vi.dataSaida = DateTime.Parse(DateTime.Now.ToShortDateString());
                            vi.HoraSaida = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));
                            vi.idFuncionario = idFun;
                            vi.idFuncionarioS = idFun;

                            vi.status = "No Patio";

                            //vi.id_cliente = int.Parse(txtProprietario.Text.ToString());
                            EntradaSaidaController.gravarEntradaSaida(vi);
                            // trazerTotalPatio();
                            panel1.Visible = false;
                            lblText.Text = "Entrada Efectuada com Sucesso";
                            lblTotalPatio.Text = EntradaSaidaController.Count().ToString();
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao grvar viatura:" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }


            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void btnVerPatio_Click(object sender, EventArgs e)
        {
            frmVisualizarViaturasNoPatio f = frmVisualizarViaturasNoPatio.GetInstance();
            if (!f.Visible)
            {
                f.ShowDialog();
            }
            else
            {
                f.BringToFront();
            }
        }

        private void btnConfirmarSaida_Click(object sender, EventArgs e)
        {

            
            if (txtBilhete.Text == "")
            {
            }
            else
            {
                List<Entrada_Saida> lista = EntradaSaidaController.getAll();
                
                    int id = int.Parse(txtBilhete.Text);
                      try
                        {
                            bool erro = false;
                            if (!erro)
                            {

                                
                                Entrada_Saida vi = new Entrada_Saida();
                                vi.id = id;
                                vi.dataSaida = DateTime.Parse(DateTime.Now.ToShortDateString());
                                vi.HoraSaida = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));
                                vi.idFuncionarioS =idFun;
                                vi.status = "Retirado";                           
                                EntradaSaidaController.gravarSaida(vi);
                                panel2.Visible = false;
                                lblText.Text = "Saida Efectuada com Sucesso";
                                lblTotalPatio.Text = EntradaSaidaController.Count().ToString();

                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Erro ao Gravar Dadoss" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                    
                    
                }

            


           
        }
    }
}
