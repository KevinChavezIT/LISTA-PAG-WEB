using System;
using System.Collections.Generic;

#nullable disable

namespace DatosVehiculo.Model
{
    public partial class TipoVehiculo
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoVehiculo { get; set; }
        public int Estado { get; set; }

        public virtual Vehiculo CodigoVehiculoNavigation { get; set; }
    }
}
