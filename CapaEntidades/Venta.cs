using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Venta
    {
        public int id_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public int id_cliente { get; set; }
        public string nombre_cliente { get; set; } // Para mostrar en listados
        public decimal total_general { get; set; }
        public string estado_venta { get; set; }
        public bool estado { get; set; }
    }
}