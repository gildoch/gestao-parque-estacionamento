using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeParque.Model;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace GestaoDeParque.Controller
{
    public class PrecosController
    {
        public static void gravarPrecos(Precos p)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();
                string sqlInserirP = "Insert Into Precos(Tipo_Contrato,Valor)Values(?,?)";
                cmd = new OleDbCommand(sqlInserirP, conn);
                cmd.Parameters.AddWithValue("Tipo_Contrato", p.tipoContrato);
                cmd.Parameters.AddWithValue("Valor", p.valor);
                int rsltd = cmd.ExecuteNonQuery();
                if (rsltd > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso a tabela de Preçário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao adicionar dados a tabela de Preçário" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }



        public static void actualizarPrecos(Precos p)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserirP = "Update Precos set Tipo_Contrato=?,Valor=? Where ID=?";

                cmd = new OleDbCommand(sqlInserirP, conn);
                cmd.Parameters.AddWithValue("Tipo_Contrato", p.tipoContrato);
                cmd.Parameters.AddWithValue("Valor", p.valor);
                cmd.Parameters.AddWithValue("ID", p.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados dos Preços actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados dos Preços"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarPrecos(Precos p)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserirP = "Delete From Precos where ID=?";

                cmd = new OleDbCommand(sqlInserirP,conn);
                cmd.Parameters.AddWithValue("ID", p.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados dos Preços apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar os dados dos Preços"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static List<Precos> getAll()
        {
            List<Precos> lista = new List<Precos>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Precos";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Precos prc = new Precos();
                        prc.id = int.Parse(dr["ID"].ToString());
                        prc.tipoContrato = dr["Tipo_Contrato"].ToString();
                        prc.valor = int.Parse(dr["Valor"].ToString());


                        lista.Add(prc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar seleccionar a lista das pessoas" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                conn.Close();
            }
            return lista;
        }

        public static ComboBox preencherComboBox(ComboBox combobox)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Precos";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "Tipo_Contrato";

                combobox.ValueMember = "ID";

                combobox.Enabled = true;
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
            return combobox;
        }

        public static string getById(string id)
        {
           
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            string tipo = null;
            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select Tipo_Contrato from Precos where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        tipo = ler["Tipo_Contrato"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO OBTER Tipo de Cliente :: " + ex.Message, "OBTENDO NOME DO PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conecta.Close();
                ler.Close();
            }
            return tipo;
        }

    }
}
