using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoDeParque.Model
{
    public class ViaturaCliente
    {
        public int id { get; set; }
        public int id_marca { get; set; }
        public int id_modelo { get; set; }
        public int id_cor { get; set; }
        public int id_tipoViatura { get; set; }
        public int id_cliente { get; set; }
        public string matricula { get; set; }
    }
}
