using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Producto
    {
        // underlying fields expected by DAL/BL
        public int id_productos { get; set; }
        public string nombre_producto { get; set; }
        public decimal precio_producto { get; set; }
        public int stock { get; set; }
        public int id_categoria { get; set; }
        public bool estado { get; set; }

        // PascalCase wrappers used by UI
        public int Id_Productos { get => id_productos; set => id_productos = value; }
        public string Nombre_Producto { get => nombre_producto; set => nombre_producto = value; }
        public decimal Precio_Producto { get => precio_producto; set => precio_producto = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id_Categoria { get => id_categoria; set => id_categoria = value; }

        // UI sometimes sets Estado as int (1/0), DAL expects bool — provide both views
        public int Estado { get => estado ? 1 : 0; set => estado = value != 0; }
    }

    // Alias class present in UI code
    public class Productos : Producto
    {
    }
}