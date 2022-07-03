using GestaoDeParque.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeParque.Controller
{
    public class TurnosController
    {
        public static void gravarTurnos(TurnosF t)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();
                string sqlInserirP = "Insert Into TurnosF (Turnos) Values(?)";
                cmd = new OleDbCommand(sqlInserirP, conn);
                cmd.Parameters.AddWithValue("Turnos", t.turno);
                int rsltd = cmd.ExecuteNonQuery();
                if (rsltd > 0)
                {
                    MessageBox.Show("Dados adicionados com sucesso", "Confirmacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void apagarTurnos(TurnosF tr)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqldelete = "Delete From TurnosF where ID=?";

                cmd = new OleDbCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("ID", tr.id);

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


        public static List<TurnosF> getAll()
        {
            List<TurnosF> lista = new List<TurnosF>();
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            try
            {
                conn = Conexão.Conexao.GetConnection();
                conn.Open();

                string sqlSelect = "Select * From TurnosF";
                cmd = new OleDbCommand(sqlSelect, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TurnosF trn = new TurnosF();
                        trn.id = int.Parse(dr["ID"].ToString());
                        trn.turno = dr["Turnos"].ToString();
                       


                        lista.Add(trn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = "SELECT * FROM TurnosF";
                da = new OleDbDataAdapter(query, conn);

                DataTable dtResultado = new DataTable();

                da.Fill(dtResultado);

                combobox.DataSource = dtResultado;

                combobox.DisplayMember = "Turnos";

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




    }
}
