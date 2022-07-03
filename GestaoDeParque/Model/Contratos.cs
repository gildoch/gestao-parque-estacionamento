using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeParque.Model
{
    public class Contratos
    {
        public int id { get; set; }
        public string idViatura { get; set; }
        public string idCliente { get; set; }
        public string idTipoContrato { get; set; }
        public int numeroDeViaturas { get; set; }        
        public string matriculaViatura { get; set; }
        public DateTime inicioDeContrato { get; set; }
        public DateTime fimDeContrato { get; set; }
    }
}
