using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestaoDeParque.Controller
{
   public class PerfilController
    {
       public static List<Perfil> getAll()
       {
           List<Perfil> lista = new List<Perfil>();
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           OleDbDataReader dr = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlSelect = "Select * From PerfilDeUtilizador";
               cmd = new OleDbCommand(sqlSelect, conn);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       Perfil c = new Perfil();
                       c.id = int.Parse(dr["ID"].ToString());
                       c.perfil = dr["Perfil"].ToString();
                       lista.Add(c);
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Ocorreu um erro ao tentar carregar Perfil do utilizador" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

               string query = "SELECT * FROM PerfilDeUtilizador";
               da = new OleDbDataAdapter(query, conn);

               DataTable dtResultado = new DataTable();

               da.Fill(dtResultado);

               combobox.DataSource = dtResultado;

               combobox.DisplayMember = "Perfil";

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
           string perfil = null;
           try
           {
               conecta = Conexão.Conexao.GetConnection();
               conecta.Open();
               string sql = "select * from PerfilDeUtilizador where ID=" + id;
               cmd = new OleDbCommand(sql, conecta);
               ler = cmd.ExecuteReader();
               if (ler.HasRows)
               {
                   while (ler.Read())
                   {
                       perfil = ler["Perfil"].ToString();

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("ERRO AO OBTER NOME DO PACIENTE :: " + ex.Message, "OBTENDO NOME DO PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conecta.Close();
               ler.Close();
           }
           return perfil;
       }


    }
}
