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
    public class ClienteController
    {
        public static void gravarCliente(Cliente c)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserir = "Insert Into Cliente (BI,Nome,Endereco,Contacto,Tipo)Values(?,?,?,?,?)";
                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("BI",c.bi);
                cmd.Parameters.AddWithValue("Nome",c.nome);
                cmd.Parameters.AddWithValue("Endereco",c.endereco);
                cmd.Parameters.AddWithValue("Contacto",c.contacto);
                //cmd.Parameters.AddWithValue("ID_Contrato",c.tipoContrato);
                cmd.Parameters.AddWithValue("Tipo",c.tipo);

                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados a tabela cliente"+ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        public static void updateCliente(Cliente c)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlupdate = "Update Cliente set BI=?,Nome=?,Endereco=?,Contacto=?,ID_Contrato=?,ID_Tipo_Cliente=? Where ID=?";

                cmd = new OleDbCommand(sqlupdate, conn);
                cmd.Parameters.AddWithValue("BI", c.bi);
                cmd.Parameters.AddWithValue("Nome", c.nome);
                cmd.Parameters.AddWithValue("Endereco", c.endereco);
                cmd.Parameters.AddWithValue("Contacto", c.contacto);
                cmd.Parameters.AddWithValue("ID_Contrato", c.tipoContrato);
                cmd.Parameters.AddWithValue("ID_Tipo_Cliente", c.tipo);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados do Cliente actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados do cliente"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarCliente(Cliente c)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From Cliente where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                // cmd.Parameters.AddWithValue("BI", p.bi);
                // cmd.Parameters.AddWithValue("Nome", p.nome);
                // cmd.Parameters.AddWithValue("Idade", p.idade);
                cmd.Parameters.AddWithValue("ID", c.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados do cliente apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar os dados do cliente"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = "SELECT * FROM RegimeDeCliente";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "TipoDeCliente";

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
            Perfil c = new Perfil();
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            string tipo = null;
            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select * from RegimeDeCliente where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        tipo = ler["TipoDeCliente"].ToString();

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

        public static string getByIdNomeCliente(int id)
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
                string sql = "select * from Cliente where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        tipo = ler["Nome"].ToString();

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


        public static List<Cliente> getAll()
        {
            List<Cliente> lista = new List<Cliente>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Cliente";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cliente p = new Cliente();
                        p.id = int.Parse(dr["ID"].ToString());
                        p.bi = dr["BI"].ToString();
                        p.nome = dr["Nome"].ToString();
                        p.endereco = dr["Endereco"].ToString();
                        p.contacto = dr["Contacto"].ToString();
                        //p.tipoContrato =dr["ID_Contrato"].ToString();
                        p.tipo =dr["Tipo"].ToString();
                        lista.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar seleccionar a lista dos clientes" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
