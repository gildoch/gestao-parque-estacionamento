using System;
using GestaoDeParque.Model;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GestaoDeParque.Controller
{
    public class FuncionarioController
    {
        public static void gravarFuncionario(Funcionario f)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();
                string sqlInsert = "Insert Into Funcionario(Nome,Endereco,Contacto,Turno,Email)Values(?,?,?,?,?)";
                cmd = new OleDbCommand(sqlInsert, conn);

                cmd.Parameters.AddWithValue("Nome", f.nome);
                cmd.Parameters.AddWithValue("Endereco", f.endereco);
                cmd.Parameters.AddWithValue("Contacto", f.contacto);
                cmd.Parameters.AddWithValue("Turno", f.turno);
                cmd.Parameters.AddWithValue("Email", f.email);
                //cmd.Parameters.AddWithValue("Id", f.id);

                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso", "Informacao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados a tabela funcionario" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally 
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        public static void ActualizarFuncionario(Funcionario f)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlactualizar = "Update Funcionario set Nome=?,Endereco=?,Contacto=?,Turno=?,Email=? Where ID=?";

                cmd = new OleDbCommand(sqlactualizar, conn);
                cmd.Parameters.AddWithValue("Nome", f.nome);
                cmd.Parameters.AddWithValue("Endereco", f.endereco);
                cmd.Parameters.AddWithValue("Contacto", f.contacto);
                cmd.Parameters.AddWithValue("Turno", f.turno);
                cmd.Parameters.AddWithValue("Email", f.email);
                cmd.Parameters.AddWithValue("ID", f.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados do funcionario actualizados com sucesso", "Confirmacao de actualizao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static void apagarFuncionario(Funcionario f)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From Funcionario Where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("ID", f.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados de Funcionario apagados com sucesso", "Confirmacao de eliminacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar funcionario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        public static string getFunNome(int id)
        {
            Users c = new Users();
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            string nome = null;

            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select Nome from Funcionario where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);

                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {


                        nome = ler["Nome"].ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO OBTER Dados de usuario :: " + ex.Message, "OBTENDO dados de usuario ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conecta.Close();
                ler.Close();
            }
            return nome;
        }

       public static List<Funcionario> getAll()
        {
            List<Funcionario> listas = new List<Funcionario>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Funcionario";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Funcionario f = new Funcionario();
                        f.id = dr["id"].ToString();
                        f.nome = dr["nome"].ToString();
                        f.endereco = dr["endereco"].ToString();
                        f.contacto = dr["contacto"].ToString();
                        f.email = dr["email"].ToString();
                        f.turno = dr["Turno"].ToString();
                        
                        listas.Add(f);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar selecionar a lista dos funcionarios" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                cmd.Dispose();
                conn.Close();
                dr.Close();
            }
            return listas;
        }
    }  
}
