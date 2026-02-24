using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteDAL
    {
      

        // INSERTAR
        public void Insertar(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@correo", cliente.correo);
                cmd.Parameters.AddWithValue("@estado", cliente.estado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // LISTAR
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarClientes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente c = new Cliente()
                    {
                        id_cliente = Convert.ToInt32(reader["id_cliente"]),
                        nombre = reader["nombre"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        correo = reader["correo"].ToString(),
                        estado = Convert.ToBoolean(reader["estado"])
                    };

                    lista.Add(c);
                }
            }

            return lista;
        }

        // ACTUALIZAR
        public void Actualizar(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@correo", cliente.correo);
                cmd.Parameters.AddWithValue("@estado", cliente.estado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR (lógico)
        public void Eliminar(int id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}