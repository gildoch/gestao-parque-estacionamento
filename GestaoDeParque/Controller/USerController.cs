using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeParque.Controller
{
   public class USerController
    {

       public static void gravarUsers(Users u)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();
               string sqlInserirP = "Insert Into Usuarios (UserName,Senha,ID_Funcionario,ID_perfil) Values(?,?,?,?)";
               cmd = new OleDbCommand(sqlInserirP, conn);
               cmd.Parameters.AddWithValue("UserName",u.userName);
               cmd.Parameters.AddWithValue("Senha", u.senha);
               cmd.Parameters.AddWithValue("ID_Funcionario", u.id_Funcionario);
               cmd.Parameters.AddWithValue("ID_perfil", u.id_Perfil);
               int rsltd = cmd.ExecuteNonQuery();
               if (rsltd > 0)
               {
                   MessageBox.Show("Dados adicionados com sucesso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }

           }
           catch (Exception a)
           {
               MessageBox.Show("Erro ao adicionar dados " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static void actualizarUsers(Users us)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlInserirP = "Update Usuarios set UserName=?,Senha=?,ID_perfil=? Where ID=?";

               cmd = new OleDbCommand(sqlInserirP, conn);
               
               cmd.Parameters.AddWithValue("UserName",us.userName);
               cmd.Parameters.AddWithValue("Senha",us.senha);
               //cmd.Parameters.AddWithValue("ID_Funcionario", us.id_Funcionario);
               cmd.Parameters.AddWithValue("ID_perfil", us.id_Perfil);
               cmd.Parameters.AddWithValue("ID", us.id);
               int result = cmd.ExecuteNonQuery();
               if (result > 0)
               {
                   MessageBox.Show("Dados actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception a)
           {
               MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static void apagarUsers(Users usr)
       {
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlInserirP = "Delete From Usuarios where ID=?";

               cmd = new OleDbCommand(sqlInserirP, conn);
               cmd.Parameters.AddWithValue("ID", usr.id);

               int result = cmd.ExecuteNonQuery();
               if (result > 0)
               {
                   MessageBox.Show("Dados apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception a)
           {
               MessageBox.Show("Ocorreu um erro ao tentar apagar os dados " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               conn.Close();
           }
       }

       public static List<GetFuncionario> obeterRegistoDeFuncionario()
       {

           {
               OleDbCommand cmd = null;
               OleDbConnection conecta = null;
               OleDbDataReader ler = null;
               List<GetFuncionario> f = new List<GetFuncionario>();
               try
               {
                   conecta = Conexão.Conexao.GetConnection();
                   conecta.Open();
                   //string sql = "select Perfil,Username from PerfilDeUtilizador,Usuarios where ID_Perfil= PerfilDeUtilizador.ID";
                   string sql = "select Funcionario.ID,Funcionario.Nome,Funcionario.Endereco,Funcionario.Contacto,Funcionario.Email,UserName,Senha,Turnos,Perfil from Funcionario,Usuarios,TurnosF,PerfilDeUtilizador where ID_Funcionario=Funcionario.ID and Turno=TurnosF.ID and ID_Perfil=PerfilDeUtilizador.ID";
                   cmd = new OleDbCommand(sql, conecta);
                   ler = cmd.ExecuteReader();
                   if (ler.HasRows)
                   {
                       while (ler.Read())
                       {
                           GetFuncionario pa = new GetFuncionario();
                           pa.id = ler["ID"].ToString();
                           pa.nome = ler["Nome"].ToString();
                           pa.endereco = ler["Endereco"].ToString();
                           pa.contacto = ler["Contacto"].ToString();
                           pa.turno = ler["Turnos"].ToString();
                           pa.email = ler["Email"].ToString();
                           pa.userName = ler["UserName"].ToString();
                           pa.perfil = ler["Perfil"].ToString();
                           pa.passwor = ler["Senha"].ToString();
                           f.Add(pa);
                       }
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("erro ao caregar funcionario" + ex.Message);
               }
               finally
               {
                   cmd.Dispose();
                   conecta.Close();
                   ler.Close();
               }
               return f;
           }

       }

       public static List<Users> getAll()
       {
           List<Users> lista = new List<Users>();
           OleDbConnection conn = null;
           OleDbCommand cmd = null;
           OleDbDataReader dr = null;
           try
           {
               conn = Conexão.Conexao.GetConnection();
               conn.Open();

               string sqlSelect = "Select * From Usuarios";
               cmd = new OleDbCommand(sqlSelect, conn);
               dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       Users usr = new Users();
                       usr.id = int.Parse(dr["ID"].ToString());
                       usr.userName = dr["UserName"].ToString();
                       usr.senha = dr["Senha"].ToString();
                       usr.id_Funcionario = int.Parse(dr["ID_Funcionario"].ToString());
                       usr.id_Perfil = int.Parse(dr["ID_Perfil"].ToString());


                       lista.Add(usr);
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               cmd.Dispose();
               dr.Close();
               conn.Close();
           }
           return lista;
       }

       public static int getDescription(string descricao)
       {
           Users c = new Users();
           OleDbCommand cmd = null;
           OleDbConnection conecta = null;
           OleDbDataReader ler = null;
           int perfil = 0 ;

           try
           {
               conecta = Conexão.Conexao.GetConnection();
               conecta.Open();
               string sql = "select ID_Perfil from Usuarios where UserName=?";
               cmd = new OleDbCommand(sql, conecta);
               c.userName = descricao;
               cmd.Parameters.AddWithValue("UserName", c.userName);
               ler = cmd.ExecuteReader();
               if (ler.HasRows)
               {
                   while (ler.Read())
                   {


                      // c.id_Funcionario = int.Parse(ler["ID_Funcionario"].ToString());
                       perfil = int.Parse(ler["ID_Perfil"].ToString());
                      // c.userName = ler["UserName"].ToString();
                       //c.senha = ler["Senha"].ToString();

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
           return perfil;
       }

       public static int getFunId(string descricao)
       {
           Users c = new Users();
           OleDbCommand cmd = null;
           OleDbConnection conecta = null;
           OleDbDataReader ler = null;
           int perfil = 0;

           try
           {
               conecta = Conexão.Conexao.GetConnection();
               conecta.Open();
               string sql = "select ID_Funcionario from Usuarios where UserName=?";
               cmd = new OleDbCommand(sql, conecta);
               c.userName = descricao;
               cmd.Parameters.AddWithValue("UserName", c.userName);
               ler = cmd.ExecuteReader();
               if (ler.HasRows)
               {
                   while (ler.Read())
                   {


                       perfil = int.Parse(ler["ID_Funcionario"].ToString());
                      

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
           return perfil;
       }



    }
}
