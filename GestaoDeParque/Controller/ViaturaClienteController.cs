using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoDeParque.Model;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GestaoDeParque.Controller
{
    public class ViaturaClienteController
    {
        public static void gravarViaturaCliente(ViaturaCliente vi)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserir = "Insert Into CadastroViatura (ID_Modelo,ID_Cor,ID_Cliente,Matricula)Values(?,?,?,?)";
                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("ID_Modelo", vi.id_modelo);
                cmd.Parameters.AddWithValue("ID_Cor", vi.id_cor);
                //cmd.Parameters.AddWithValue("ID_Marca", vi.id_marca);
                //cmd.Parameters.AddWithValue("ID_Tipo_Viatura", vi.id_tipoViatura);
                cmd.Parameters.AddWithValue("ID_Cliente", vi.id_cliente);
                cmd.Parameters.AddWithValue("Matricula", vi.matricula);

                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados a tabela cadastro de viatura" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        public static void updateCliente(ViaturaCliente v)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlupdate = "Update CadastroViatura set ID_Modelo=?,ID_Cor=?,ID_Marca=?,ID_Tipo_Viatura=?,ID_Cliente=?,Matricula=? Where ID=?";

                cmd = new OleDbCommand(sqlupdate, conn);
                cmd.Parameters.AddWithValue("ID_Modelo", v.id_modelo);
                cmd.Parameters.AddWithValue("ID_Cor", v.id_cor);
                cmd.Parameters.AddWithValue("ID_Marca", v.id_marca);
                cmd.Parameters.AddWithValue("ID_Tipo_Viatura", v.id_tipoViatura);
                cmd.Parameters.AddWithValue("ID_Cliente", v.id_cliente);
                cmd.Parameters.AddWithValue("Matricula", v.matricula);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados da viatura actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados da viatura"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarCliente(ViaturaCliente v)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From CadastroViatura where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                // cmd.Parameters.AddWithValue("BI", p.bi);
                // cmd.Parameters.AddWithValue("Nome", p.nome);
                // cmd.Parameters.AddWithValue("Idade", p.idade);
                cmd.Parameters.AddWithValue("ID", v.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados da viatura apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar os dados da viatura"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static List<ViaturaCliente> getAll()
        {
            List<ViaturaCliente> lista = new List<ViaturaCliente>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From CadastroViatura";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViaturaCliente v = new ViaturaCliente();
                        v.id = int.Parse(dr["ID"].ToString());
                        v.id_modelo = int.Parse(dr["ID_Modelo"].ToString());
                        v.id_cor = int.Parse(dr["ID_Cor"].ToString());
                        //v.id_marca = int.Parse(dr["ID_Marca"].ToString());
                        //v.id_tipoViatura = int.Parse(dr["ID_Tipo_Viatura"].ToString());
                        v.id_cliente = int.Parse(dr["ID_Cliente"].ToString());
                        v.matricula = dr["Matricula"].ToString();
                        lista.Add(v);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("", "Erro" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
