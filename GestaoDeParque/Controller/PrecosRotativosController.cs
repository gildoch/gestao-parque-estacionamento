using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestaoDeParque.Controller
{
   public class PrecosRotativosController
    {
       public static void gravarPrecosRotativos(PrecosRotativos p)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();
               string sqlInserirP = "Insert Into PrecosRotativos(ID_Tipo_Viatura,Valor)Values(?,?)";
               cmd = new OleDbCommand(sqlInserirP, conn);
               cmd.Parameters.AddWithValue("ID_Tipo_Viatura", p.tipoViatura);
               cmd.Parameters.AddWithValue("Valor", p.valor);
               int rsltd = cmd.ExecuteNonQuery();
               if (rsltd > 0)
               {
                   MessageBox.Show("Dados adicionados com sucesso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }

           }
           catch (Exception a)
           {
               MessageBox.Show("Erro ao adicionar dados" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static void actualizarPrecosRotativos(PrecosRotativos p)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlInserirP = "Update PrecosRotativos set ID_Tipo_Viatura=?,Valor=? Where ID=?";

               cmd = new OleDbCommand(sqlInserirP, conn);
               cmd.Parameters.AddWithValue("ID_Tipo_Viatura", p.tipoViatura);
               cmd.Parameters.AddWithValue("Valor", p.valor);
               cmd.Parameters.AddWithValue("ID", p.id);

               int result = cmd.ExecuteNonQuery();
               if (result > 0)
               {
                   MessageBox.Show("Dados actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception a)
           {
               MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static void apagarPrecosRotativos(PrecosRotativos p)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlInserirP = "Delete From PrecosRotativos where ID=?";

               cmd = new OleDbCommand(sqlInserirP, conn);
               cmd.Parameters.AddWithValue("ID", p.id);

               int result = cmd.ExecuteNonQuery();
               if (result > 0)
               {
                   MessageBox.Show("Dadosapagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       public static List<PrecosRotativos> getAll()
       {
           List<PrecosRotativos> lista = new List<PrecosRotativos>();
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           OleDbDataReader dr = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlSelect = "Select * From PrecosRotativos";
               cmd = new OleDbCommand(sqlSelect, conn);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       PrecosRotativos prc = new PrecosRotativos();
                       prc.id = int.Parse(dr["ID"].ToString());
                       prc.tipoViatura = int.Parse(dr["ID_Tipo_Viatura"].ToString());
                       prc.valor = int.Parse(dr["Valor"].ToString());


                       lista.Add(prc);
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Ocorreu um erro ao carregar precos" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               dr.Close();
               conn.Close();
           }
           return lista;
       }

       public static double getById(string tipoViatura)
       {

           OleDbCommand cmd = null;
           OleDbConnection conecta = null;
           OleDbDataReader ler = null;
           double valor = 0;
           try
           {
               conecta = Conexão.Conexao.GetConnection();
               conecta.Open();
               string sql = "select Valor from PrecosRotativos where ID_Tipo_Viatura=" + tipoViatura;
               cmd = new OleDbCommand(sql, conecta);
               ler = cmd.ExecuteReader();
               if (ler.HasRows)
               {
                   while (ler.Read())
                   {
                       valor =double.Parse( ler["Valor"].ToString());

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("ERRO AO OBTER Valor :: " + ex.Message, "OBTENDO NOME DO PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conecta.Close();
               ler.Close();
           }
           return valor;
       }

       public static string getByIdTipoViatura(int id)
       {

           OleDbCommand cmd = null;
           OleDbConnection conecta = null;
           OleDbDataReader ler = null;
           string tipo = null;
           try
           {
               conecta = Conexão.Conexao.GetConnection();
               conecta.Open();
               string sql = "select Tipo from Tipo_Viatura where ID=" + id;
               cmd = new OleDbCommand(sql, conecta);
               ler = cmd.ExecuteReader();
               if (ler.HasRows)
               {
                   while (ler.Read())
                   {
                       tipo = ler["Tipo"].ToString();

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
