using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class VentaBLL
    {
        private VentaDAL ventaDAL = new VentaDAL();

        // INSERTAR
        public int Insertar(Venta venta)
        {
            if (venta.id_cliente <= 0)
                throw new Exception("Cliente inválido.");

            if (venta.total_general <= 0)
                throw new Exception("El total de la venta debe ser mayor que cero.");

            if (venta.fecha_venta > DateTime.Now)
                throw new Exception("La fecha de la venta no puede ser futura.");

            if (string.IsNullOrWhiteSpace(venta.estado_venta))
                venta.estado_venta = "Pendiente";

            return ventaDAL.Insertar(venta);
        }

        // LISTAR
        public List<Venta> Listar()
        {
            return ventaDAL.Listar();
        }

        // ACTUALIZAR
        public void Actualizar(Venta venta)
        {
            if (venta.id_venta <= 0)
                throw new Exception("ID de venta inválido.");

            if (venta.id_cliente <= 0)
                throw new Exception("Cliente inválido.");

            ventaDAL.Actualizar(venta);
        }

        // ELIMINAR
        public void Eliminar(int id_venta)
        {
            if (id_venta <= 0)
                throw new Exception("ID de venta inválido.");

            ventaDAL.Eliminar(id_venta);
        }
    }
}