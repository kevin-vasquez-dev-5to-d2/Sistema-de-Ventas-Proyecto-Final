using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class DetalleVenta
    {
        // underlying fields used by DAL
        public int id_detalle { get; set; }
        public int id_venta { get; set; }
        public DateTime fecha_venta { get; set; } // Para mostrar al listar
        public int id_producto { get; set; }
        public string nombre_producto { get; set; } // Para mostrar en listas
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }

        // PascalCase wrappers and aliases used by UI
        public int Id_Detalle { get => id_detalle; set => id_detalle = value; }
        public int Id_Venta { get => id_venta; set => id_venta = value; }
        public int Id_Productos { get => id_producto; set => id_producto = value; }
        public string NombreProducto { get => nombre_producto; set => nombre_producto = value; }
        public int Cant { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precio; set => precio = value; }

        // computed
        public decimal Subtotal { get => Cant * PrecioUnitario; }
    }
}