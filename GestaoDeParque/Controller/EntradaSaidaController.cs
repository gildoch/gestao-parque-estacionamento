using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestaoDeParque.Model;
using GestaoDeParque.Controller;

namespace GestaoDeParque.Controller
{
    public class EntradaSaidaController
    {
        public static void gravarEntradaSaida(Entrada_Saida es)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserir = "Insert Into Entrada_Saida(ID_Funcionario,Matricula_Viatura,Data_Entrada,Hora_Entrada,Data_Saida,Hora_Saida,Status,Modelo,Cor,OperadorS)Values(?,?,?,?,?,?,?,?,?,?)";
                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("ID_Funcionario", es.idFuncionario);
                
                //cmd.Parameters.AddWithValue("Codigo_Vaga", es.codigoVaga);
                cmd.Parameters.AddWithValue("Matricula_Viatura", es.matricula);
                cmd.Parameters.AddWithValue("Data_Entrada", es.dataEntrada);
                cmd.Parameters.AddWithValue("Hora_Entrada", es.HoraEntrada);
                cmd.Parameters.AddWithValue("Hora_Saida", es.HoraSaida);
                cmd.Parameters.AddWithValue("Data_Saida", es.dataSaida);
                cmd.Parameters.AddWithValue("Status", es.status);
                cmd.Parameters.AddWithValue("Modelo", es.modelo);
                cmd.Parameters.AddWithValue("Cor", es.cor);
                cmd.Parameters.AddWithValue("OperadorS", es.idFuncionarioS);
                //cmd.Parameters.AddWithValue("ID_Cliente", es.idCliente);
              

                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados "+ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }


        public static void gravarSaida(Entrada_Saida es)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlactualizar = "Update Entrada_Saida set Status=?, Data_Saida=?, Hora_Saida=?,OperadorS=? Where ID=?";

                cmd = new OleDbCommand(sqlactualizar, conn);
                cmd.Parameters.AddWithValue("Status", es.status);
                cmd.Parameters.AddWithValue("Data_Saida",es.dataSaida);
                cmd.Parameters.AddWithValue("Hora_Saida",es.HoraSaida);
                cmd.Parameters.AddWithValue("OperadorS",es.idFuncionarioS);             
                cmd.Parameters.AddWithValue("ID",es.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados Gravados Com Sucesso", "Confirmacao de actualizao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar Gravar os dadosS" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();

            }
        }

        public static List<Entrada_Saida> getAll()
        {
            List<Entrada_Saida> lista = new List<Entrada_Saida>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
           
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select ID,ID_Funcionario,Matricula_Viatura,Data_Entrada,Hora_Entrada,Cor,Modelo,Status From Entrada_Saida";
                cmd = new OleDbCommand(sqlSelect, conn);
               
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entrada_Saida es = new Entrada_Saida();
                        es.id = int.Parse(dr["ID"].ToString());
                        //es.idCliente = int.Parse(dr["ID_Cliente"].ToString());
                        es.idFuncionario = int.Parse(dr["ID_Funcionario"].ToString());
                        es.matricula = dr["Matricula_Viatura"].ToString();
                        es.dataEntrada =DateTime.Parse(dr["Data_Entrada"].ToString());                     
                        es.HoraEntrada =DateTime.Parse(dr["Hora_Entrada"].ToString());                        
                        es.cor = int.Parse(dr["Cor"].ToString());
                        es.modelo = int.Parse(dr["Modelo"].ToString());
                        es.status = dr["Status"].ToString();                      
                        lista.Add(es);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar Carregar Entradas e saidas" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                dr.Close();
            }
            return lista;
        }

        public static List<Entrada_Saida> getAllSaida()
        {
            List<Entrada_Saida> lista = new List<Entrada_Saida>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Entrada_Saida";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entrada_Saida es = new Entrada_Saida();
                        es.id = int.Parse(dr["ID"].ToString());
                        //es.idCliente = int.Parse(dr["ID_Cliente"].ToString());
                        es.idFuncionario = int.Parse(dr["ID_Funcionario"].ToString());
                        es.idFuncionarioS= int.Parse(dr["OperadorS"].ToString());
                        es.matricula = dr["Matricula_Viatura"].ToString();
                        es.dataEntrada = DateController.GetWithHour(DateTime.Parse(dr["Data_Entrada"].ToString()));
                        es.dataSaida = DateController.GetWithHour(DateTime.Parse(dr["Data_Saida"].ToString()));
                        es.HoraSaida = DateTime.Parse(dr["Hora_Saida"].ToString());
                        es.HoraEntrada = DateTime.Parse(dr["Hora_Entrada"].ToString());                      
                        es.cor = int.Parse(dr["Cor"].ToString());
                        es.modelo = int.Parse(dr["Modelo"].ToString());
                        es.status = dr["Status"].ToString();
                        lista.Add(es);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar Carregar Entradas e saidas"   + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                dr.Close();
            }
            return lista;
        }

        public static int Count()
        {
            Perfil c = new Perfil();
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            string tipo = "No Patio";
            int conta = 0;
            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select Count(*) from Entrada_Saida where Status='No Patio'";
                cmd = new OleDbCommand(sql, conecta);
                
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        conta = ler.GetInt32(0);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO OBTER CONTA PARQUEADOS :: " + ex.Message, "OBTENDO NOME DO PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conecta.Close();
                ler.Close();
            }
            return conta;
        }

    }
}
