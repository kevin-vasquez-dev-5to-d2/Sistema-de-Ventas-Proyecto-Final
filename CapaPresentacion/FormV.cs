using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FormV : Form
    {
        // Usar BindingList para que el DataGridView observe cambios automáticamente
        private BindingList<DetalleVenta> listaDetalles = new BindingList<DetalleVenta>();
        private BindingSource ventasBinding = new BindingSource();

        public FormV()
        {
            InitializeComponent();

            // configurar binding del DataGridView
            ventasBinding.DataSource = listaDetalles;
            dvgVenta.AutoGenerateColumns = true;
            dvgVenta.DataSource = ventasBinding;
            dvgVenta.DataBindingComplete += DvgVenta_DataBindingComplete;
        }

        private void FormV_Load(object sender, EventArgs e)
        {
            ClienteBL clienteBL = new ClienteBL();
            ProductoBL productoBL = new ProductoBL();

            // ComboBox de clientes
            cbxCliente.DataSource = clienteBL.ListarCl();
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.ValueMember = "id_cliente";

            // ComboBox de productos
            cbxProducto.DataSource = productoBL.Listar();
            cbxProducto.DisplayMember = "Nombre_Producto";
            cbxProducto.ValueMember = "Id_Productos";

            HideIdColumns();
        }

        private bool ValidarCantidad()
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Obtener el producto seleccionado
            ProductoBL productoBL = new ProductoBL();
            int idProducto = Convert.ToInt32(cbxProducto.SelectedValue);
            Productos producto = productoBL.ObtenerPorId(idProducto);

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cantidad > producto.Stock)
            {
                MessageBox.Show($"La cantidad no puede ser mayor al stock disponible ({producto.Stock}).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedIndex != -1)
            {
                cbxCliente.Enabled = false; // Bloquear cliente una vez que se empieza la venta
            }
            if (ValidarCantidad())
            {
                int idProducto = Convert.ToInt32(cbxProducto.SelectedValue);
                ProductoBL productoBL = new ProductoBL();
                Productos producto = productoBL.ObtenerPorId(idProducto);

                DetalleVenta detalle = new DetalleVenta
                {
                    Id_Productos = producto.Id_Productos,
                    NombreProducto = producto.Nombre_Producto,
                    Cant = Convert.ToInt32(txtCantidad.Text),
                    PrecioUnitario = producto.Precio_Producto
                };

                // Añadir al BindingList actualiza automáticamente el DataGridView
                listaDetalles.Add(detalle);

                btnFacturar.Enabled = listaDetalles.Any();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ReiniciarFormulario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            // Validar que haya al menos un detalle y un cliente seleccionado
            if (listaDetalles.Count == 0)
            {
                MessageBox.Show("Por favor, agregue productos a la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener datos de la venta
                int idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                decimal totalGeneral = listaDetalles.Sum(d => d.Cant * d.PrecioUnitario);

                // Crear objeto Venta
                Venta venta = new Venta
                {
                    id_cliente = idCliente,
                    fecha_venta = DateTime.Now,
                    total_general = totalGeneral,
                    estado_venta = "Completada",
                    estado = true
                };

                // Guardar venta en BD
                VentaBLL ventaBLL = new VentaBLL();
                int idVentaGenerado = ventaBLL.Insertar(venta);

                // Guardar detalles de la venta
                if (idVentaGenerado > 0)
                {
                    DetalleVentaBL detalleVentaBL = new DetalleVentaBL();
                    foreach (var detalle in listaDetalles)
                    {
                        DetalleVenta detalleVenta = new DetalleVenta
                        {
                            id_venta = idVentaGenerado,
                            id_producto = detalle.Id_Productos,
                            cantidad = detalle.Cant,
                            precio = detalle.PrecioUnitario,
                            estado = true
                        };
                        detalleVentaBL.Insertar(detalleVenta);
                    }

                    MessageBox.Show("Venta facturada correctamente. Los datos se han guardado en la BD.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReiniciarFormulario();
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al facturar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
        }

        private void ReiniciarFormulario()
        {
            // limpiar datos en memoria (BindingList notifica automáticamente)
            listaDetalles.Clear();
            ventasBinding.ResetBindings(false);

            // restablecer ComboBoxes y TextBoxes
            cbxCliente.SelectedIndex = -1;
            cbxCliente.Enabled = true;
            cbxProducto.SelectedIndex = -1;
            txtCantidad.Clear();
            txtVenta.Clear();

            // desactivar botones que dependen de datos
            btnFacturar.Enabled = false;

            // recargar comboboxes para quedar como al iniciar
            try
            {
                ClienteBL clienteBL = new ClienteBL();
                ProductoBL productoBL = new ProductoBL();

                cbxCliente.DataSource = clienteBL.ListarCl();
                cbxCliente.DisplayMember = "nombre";
                cbxCliente.ValueMember = "id_cliente";

                cbxProducto.DataSource = productoBL.Listar();
                cbxProducto.DisplayMember = "Nombre_Producto";
                cbxProducto.ValueMember = "Id_Productos";
            }
            catch
            {
                // si falla la recarga, no interrumpimos el reinicio
            }

            // asegurar que las columnas de Id estén ocultas
            HideIdColumns();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                bool removed = false;

                // Si hay una fila seleccionada en el DataGridView, eliminar el elemento asociado
                if (dvgVenta.SelectedRows != null && dvgVenta.SelectedRows.Count > 0)
                {
                    var item = dvgVenta.SelectedRows[0].DataBoundItem as DetalleVenta;
                    if (item != null)
                    {
                        listaDetalles.Remove(item);
                        removed = true;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(txtVenta.Text))
                {
                    // Si no hay selección, intentar eliminar según valor en txtVenta:
                    if (int.TryParse(txtVenta.Text.Trim(), out int valor))
                    {
                        var byId = listaDetalles.FirstOrDefault(d => d.Id_Detalle == valor);
                        if (byId != null)
                        {
                            listaDetalles.Remove(byId);
                            removed = true;
                        }
                        else if (valor >= 1 && valor <= listaDetalles.Count)
                        {
                            // interpretar como posición 1-based
                            listaDetalles.RemoveAt(valor - 1);
                            removed = true;
                        }
                    }
                }

                if (removed)
                {
                    ventasBinding.ResetBindings(false);
                    btnFacturar.Enabled = listaDetalles.Any();
                    txtVenta.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontró una fila seleccionada ni un identificador válido en el campo. Seleccione una fila o ingrese el Id/posición en el campo.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Oculta columnas de Id y Estado que no debe ver el usuario
        private void HideIdColumns()
        {
            try
            {
                if (dvgVenta.Columns == null) return;

                // Ocultar todas las variantes de IDs y estado
                string[] columnasOcultas = { "Id_Detalle", "id_detalle", "ID_Detalle", "IDDetalle",
                                           "Id_Venta", "id_venta", "ID_Venta", "IDVenta",
                                           "Id_Productos", "id_productos", "ID_Productos", "IDProductos",
                                           "estado", "Estado", "ESTADO" };

                foreach (var columnaOculta in columnasOcultas)
                {
                    if (dvgVenta.Columns.Contains(columnaOculta))
                        dvgVenta.Columns[columnaOculta].Visible = false;
                }
            }
            catch
            {
                // no interrumpir por fallo al ocultar columnas
            }
        }

        private void DvgVenta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideIdColumns();
        }
    }
}