using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudExamen.Models
{
    public class Cuenta
    {
        public int Numero       { get; set; }
        public int SaldoTotal   { get; set; }
        public int CodigoSocio  { get; set; }
        public int Estado       { get; set; }
    }
}
