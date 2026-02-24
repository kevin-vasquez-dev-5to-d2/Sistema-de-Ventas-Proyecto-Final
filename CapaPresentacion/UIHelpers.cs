using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class UIHelpers
    {
        public static void HideSensitiveColumns(DataGridView dgv)
        {
            if (dgv?.Columns == null) return;
            try
            {
                string[] cols = new[] { "id", "Id", "id_cliente", "Id_Cliente", "id_clientes", "id_producto", "Id_Productos", "Id_Productos", "id_productos", "Id_Categoria", "id_categoria", "Estado", "estado" };
                foreach (var name in cols)
                {
                    if (dgv.Columns.Contains(name))
                        dgv.Columns[name].Visible = false;
                }
            }
            catch
            {
                // ignore errors hiding columns
            }
        }
    }
}
