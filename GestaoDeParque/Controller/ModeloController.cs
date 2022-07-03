using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using GestaoDeParque.Model;
using System.Windows.Forms;
using GestaoDeParque.View;
using System.Data;

namespace GestaoDeParque.Controller
{
    public class ModeloController
    {
        public static void gravarViatura(Viatura v)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlInsert = "Insert into Viatura(ID_Marca,Modelo,ID_Tipo_Viatura) Values(?,?,?)";

                cmd = new OleDbCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("ID_Marca", v.id_marca);
                cmd.Parameters.AddWithValue("Modelo", v.modelo);
                cmd.Parameters.AddWithValue("ID_Tipo_Viatura", v.id_tipoViatura);
                int rslt = cmd.ExecuteNonQuery();
                if (rslt > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao adicionar dados a tabela Viatura" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public static void apagarViatura(Viatura via)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From Viatura where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("ID", via.id);

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

        public static void updateViatura(Viatura viaa)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlupdate = "Update Viatura set ID_Marca=?,Modelo=?,ID_Tipo_Viatura=? Where ID=?";

                cmd = new OleDbCommand(sqlupdate, conn);
                cmd.Parameters.AddWithValue("ID_Marca=", viaa.id_marca);
                cmd.Parameters.AddWithValue("Modelo", viaa.modelo);
                cmd.Parameters.AddWithValue("ID_Tipo_Viatura", viaa.id_tipoViatura);
                cmd.Parameters.AddWithValue("ID", viaa.id);

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

        public static ComboBox preencherComboBox(ComboBox combobox)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Tipo_Viatura";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "Tipo";

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

        public static ComboBox preencherComboBoxModelo(ComboBox combobox)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Viatura";
                da = new OleDbDataAdapter(query, conn);               
                
                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "Modelo";

                combobox.ValueMember = "ID";

                combobox.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao carregar modelos" + ex.Message, "Erro na gravacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sql = "select * from Viatura where ID=" + id;
                cmd = new OleDbCommand(sql, conecta);
                ler = cmd.ExecuteReader();
                if (ler.HasRows)
                {
                    while (ler.Read())
                    {
                        tipo = ler["Modelo"].ToString();

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


        public static List<Viatura> getAll()
        {
            List<Viatura> lista = new List<Viatura>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From Viatura";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Viatura v = new Viatura();
                        v.id = int.Parse(dr["ID"].ToString());
                        v.id_marca = int.Parse(dr["ID_Marca"].ToString());
                        v.modelo = dr["Modelo"].ToString();
                        v.id_tipoViatura = int.Parse(dr["ID_Tipo_Viatura"].ToString());

                        lista.Add(v);
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


        public static List<Marca> getMarca(Marca mac)
        {
            List<Marca> lista = new List<Marca>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            try
            {

                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                //string sqlSelect = "Select DescricaoM From Marcas WHERE ID=?";
                string sqlSelect = "SELECT DescricaoM FROM Marcas  where ID=?";
                cmd = new OleDbCommand(sqlSelect, conn);
                cmd.Parameters.AddWithValue("ID", mac.descricaoM);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Marca m = new Marca();
                        m.id = dr["ID"].ToString();
                        m.descricaoM = dr["DescricaoM"].ToString();
                        lista.Add(m);
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

        public static List<Parametrizacao> obeterRegistoDeViatura()
        {

            {
                OleDbCommand cmd = null;
                OleDbConnection conecta = null;
                OleDbDataReader ler = null;
                List<Parametrizacao> p = new List<Parametrizacao>();
                try
                {
                    conecta = Conexão.Conexao.GetConnection();
                    conecta.Open();
                    string sql = "select Viatura.ID,DescricaoM,Modelo,Tipo from Viatura, Marcas,Tipo_Viatura where ID_Marca=Marcas.ID and ID_Tipo_Viatura=Tipo_Viatura.ID";
                    cmd = new OleDbCommand(sql, conecta);
                    ler = cmd.ExecuteReader();
                    if (ler.HasRows)
                    {
                        while (ler.Read())
                        {
                            Parametrizacao pa = new Parametrizacao();
                            pa.codigo = int.Parse(ler["ID"].ToString());
                            pa.tipo = ler["Tipo"].ToString();
                            pa.modelo = ler["Modelo"].ToString();
                            pa.marca = ler["DescricaoM"].ToString();
                            p.Add(pa);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erro ao caregar nossas viaturas" + ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conecta.Close();
                    ler.Close();
                }
                return p;
            }

        }


    }
}
