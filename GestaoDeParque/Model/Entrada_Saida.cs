using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeParque.Model
{
   public class Entrada_Saida
    {
       public int id { get; set; }
       public int cor { get; set; }
       public int idCliente { get; set; }
       public int idFuncionario { get; set; }
       public int idFuncionarioS { get; set; }
       public int codigoVaga { get; set; }
       public string matricula { get; set; }
       public int modelo{ get; set; }     
       public string status {get;set; }
       public DateTime dataEntrada { get; set; }
       public DateTime dataSaida { get; set; }
       public DateTime HoraEntrada { get; set; }
       public DateTime HoraSaida { get; set; }
    }
}
