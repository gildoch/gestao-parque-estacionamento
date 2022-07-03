using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeParque.Model
{
    public class Users
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string senha { get; set; }
        public int id_Perfil { get; set; }
        public int id_Funcionario { get; set; }

    }
}
