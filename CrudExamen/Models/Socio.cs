using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudExamen.Models
{
    public class Socio
    {
        public int Cedula      { get; set; }
        public string Nombre   { get; set; }
        public string Apellido { get; set; }
        public string Direccion{ get; set; }
        public int Estado      { get; set; }
    }
}
