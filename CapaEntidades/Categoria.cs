using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Categoria
    {
        // original fields used by DAL/BL
        public int id_categoria { get; set; }
        public string nombre_categoria { get; set; }
        public bool estado { get; set; }

        // additional property used by UI
        public string descripcion { get; set; }

        // PascalCase wrappers for UI compatibility
        public int Id_Categoria { get => id_categoria; set => id_categoria = value; }
        public string Nombre_Categoria { get => nombre_categoria; set => nombre_categoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }

    // Alias class expected in some forms
    public class Categorias : Categoria
    {
    }
}