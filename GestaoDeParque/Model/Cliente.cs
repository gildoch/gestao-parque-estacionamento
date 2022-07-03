using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeParque.Model
{
    public class Cliente
    {
        public int id { get; set; }
        public string bi { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string contacto {get;set;}
        public string tipoContrato { get; set; }
        public string viaturaMatricula { get; set; }
        public string tipo { get; set; }
    }
}
