using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace GestaoDeParque.Conexão
{
    public  class Conexao
    {
        public static OleDbConnection GetConnection()
        {
            OleDbConnection conn = null;
            string conexao = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=D:\\DOCS\\Projectos\\C#\\gestao-parque-estacionamento\\BDParque\\GePeSystem.accdb; Persist Security Info=false;";
            conn = new OleDbConnection(conexao);
            return conn;
        }
    }
}
