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
    public class ContratoController
    {


        public static DateTime GetWithHour(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day);
        }

        public static List<Contratos> getById(int id)
        {
            List<Contratos> lista = new List<Contratos>();
            Contratos c = new Contratos();
            OleDbCommand cmd = null;
            OleDbConnection conecta = null;
            OleDbDataReader ler = null;
            
            try
            {
                conecta = Conexão.Conexao.GetConnection();
                conecta.Open();
                string sql = "select ID,ID_Precos,Inicio_Contrato,Fim_Contrato from Contratos where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        c.id = int.Parse(ler["ID"].ToString());
                        c.idTipoContrato = ler["ID_Precos"].ToString();
                        c.inicioDeContrato = DateTime.Parse(ler["Inicio_Contrato"].ToString());
                        c.fimDeContrato = DateTime.Parse(ler["Fim_Contrato"].ToString());
                        lista.Add(c);
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
            return lista;
        }


        public static void gravarContratos(Contratos co)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();
                string sqlInserir = "Insert Into Contratos (ID_Viatura,ID_Cliente,ID_Precos,Numero_Viaturas,Inicio_Contrato,Fim_Contrato)Values(?,?,?,?,?,?)";
                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("ID_Viatura", co.idViatura);
                cmd.Parameters.AddWithValue("ID_Cliente", co.idCliente);
                cmd.Parameters.AddWithValue("ID_Precos", co.idTipoContrato);              
                cmd.Parameters.AddWithValue("Numero_Viaturas", co.numeroDeViaturas);
                cmd.Parameters.AddWithValue("Inicio_Contrato", co.inicioDeContrato);
                cmd.Parameters.AddWithValue("Fim_Contrato", co.fimDeContrato);
             
                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso aos contratos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar dados a tabela contratos" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

        }

        public static void actualizarContrato(Contratos co)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserir = "Update Contratos set ID_Viatura=?,ID_Cliente=?,ID_Precos=?,Numero_Viaturas=?,Inicio_Contrato=?,Fim_Contrato=? Where ID=?";

                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("ID_Viatura", co.idViatura);
                cmd.Parameters.AddWithValue("ID_Cliente", co.idCliente);
                cmd.Parameters.AddWithValue("ID_Precos", co.idTipoContrato);
                cmd.Parameters.AddWithValue("ID", co.id);
                cmd.Parameters.AddWithValue("Numero_Viaturas", co.numeroDeViaturas);
                cmd.Parameters.AddWithValue("Inicio_Contrato", co.inicioDeContrato);
                cmd.Parameters.AddWithValue("Fim_Contrato", co.fimDeContrato);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados do contrato actualizados com sucesso", "Confirmacao de actualizacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar actualizar os dados do contrato"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarContrato(Contratos co)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInserir = "Delete From Contratos where ID=?";

                cmd = new OleDbCommand(sqlInserir, conn);
                cmd.Parameters.AddWithValue("ID", co.id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Dados do cliente apagados com sucesso", "Confirmacao de remocao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Ocorreu um erro ao tentar apagar os dados do Cliente"+a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static List<Contratos> getAll()
        {
            List<Contratos> lista = new List<Contratos>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Contratos";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Contratos co = new Contratos();
                        co.id = int.Parse(dr["ID"].ToString());
                        co.idViatura = dr["ID_Viatura"].ToString();
                        co.idCliente = dr["ID_Cliente"].ToString();
                        co.idTipoContrato =dr["ID_Precos"].ToString();                       
                        co.numeroDeViaturas = int.Parse(dr["Numero_Viaturas"].ToString());
                        co.inicioDeContrato = ContratoController.GetWithHour(DateTime.Parse(dr["Inicio_Contrato"].ToString()));
                        co.fimDeContrato = ContratoController.GetWithHour(DateTime.Parse(dr["Fim_Contrato"].ToString()));
                        lista.Add(co);
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
