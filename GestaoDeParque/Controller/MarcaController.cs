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
   public class MarcaController
    {
       public static void grvarMarca(Marca marca)
       {
           OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInsert = "Insert into Marcas(DescricaoM) Values(?)";

                cmd = new OleDbCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("DescricaoM",marca.descricaoM);
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

       public static void apagarMarca(Marca mar)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqldelete = "Delete From Marcas where ID=?";

               cmd = new OleDbCommand(sqldelete, conn);
               cmd.Parameters.AddWithValue("ID", mar.id);

               int result = cmd.ExecuteNonQuery();
               if (result > 0)
               {
                   MessageBox.Show("Dados apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception a)
           {
               MessageBox.Show("Ocorreu um erro ao tentar apagar os dados" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static void updateMarca(Marca marr)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlupdate = "Update Marcas set DescricaoM =? Where ID=?";

                cmd = new OleDbCommand(sqlupdate, conn);
                cmd.Parameters.AddWithValue("ID", marr.id);
                cmd.Parameters.AddWithValue("DescricaoM",marr.descricaoM);
                
                

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

       public static ComboBox preencherComboBox(ComboBox combobox)
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

               combobox.DataSource = dtResultado;

               combobox.DisplayMember = "DescricaoM";

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


       public static List<Marca> getAll()
       {
           List<Marca> lista = new List<Marca>();
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           OleDbDataReader dr = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlSelect = "Select * From Marcas";
               cmd = new OleDbCommand(sqlSelect, conn);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       Marca mar = new Marca();
                       mar.id = dr["ID"].ToString();
                       mar.descricaoM = dr["DescricaoM"].ToString();
                       lista.Add(mar);
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

       }

    }

