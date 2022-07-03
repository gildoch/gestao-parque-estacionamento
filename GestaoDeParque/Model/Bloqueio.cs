using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoDeParque.Model
{
    public class Bloqueio
    {
        public int id { get; set; }
        public string status { get; set; }
        public DateTime databloqueio { get; set; }
        public DateTime datadesbloqueio { get; set; }
        public string motivo { get; set; }
        public string negacao { get; set; }
    }
}
