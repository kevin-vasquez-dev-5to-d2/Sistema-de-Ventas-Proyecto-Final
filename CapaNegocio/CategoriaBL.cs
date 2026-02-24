using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriaBL
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        // INSERTAR
        public void Insertar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre de la categoría no puede estar vacío.");

            categoriaDAL.Insertar(nombre);
        }

        // LISTAR
        public List<Categoria> Listar()
        {
            return categoriaDAL.Listar();
        }

        // ACTUALIZAR
        public void Actualizar(int id, string nombre, bool estado)
        {
            if (id <= 0)
                throw new Exception("ID inválido.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre no puede estar vacío.");

            categoriaDAL.Actualizar(id, nombre, estado);
        }

        // DESACTIVAR
        public void Desactivar(int id)
        {
            if (id <= 0)
                throw new Exception("ID inválido.");

            categoriaDAL.Desactivar(id);
        }

        // Compatibility helpers used by existing forms
        public void Agregar(Categorias c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            Insertar(c.Nombre_Categoria);
        }

        public void Eliminar(Categorias c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            Desactivar(c.Id_Categoria);
        }
    }
}
