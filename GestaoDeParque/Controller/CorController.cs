using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using GestaoDeParque.Model;
using System.Windows.Forms;
using GestaoDeParque.Controller;
using System.Data;

namespace GestaoDeParque.Controller
{
    public class CorController
    {
        

        public static void gravarCor(Cores cor )
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInsert = "Insert into Cores(Nomes) Values(?)";

                cmd = new OleDbCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("Cor", cor.nomeCor);
                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao adicionar dados a tabela cliente" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void updateCor(Cores cor)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlupdate = "Update Cores set Nomes=? Where ID=?";

                cmd = new OleDbCommand(sqlupdate, conn);
                cmd.Parameters.AddWithValue("ID", cor.id);
                cmd.Parameters.AddWithValue("Nomes",cor.nomeCor);
                
                

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarCor(Cores cor)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From Cores where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("ID",cor.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar os dados"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static ComboBox preencherComboBox(ComboBox combobox)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Cores";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "Nomes";

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

        public static string getById(int id)
        {
            Perfil c = new Perfil();
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            string tipo = null;
            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select * from Cores where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        tipo = ler["Nomes"].ToString();

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


        public static List<Cores> getAll()
        {
            List<Cores> lista = new List<Cores>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Cores";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cores c = new Cores();
                        c.id = dr["ID"].ToString();
                        c.nomeCor = dr["Nomes"].ToString();
                        lista.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar Cores" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                dr.Close();
                conn.Close();
            }
            return lista;
        }

    }


}
