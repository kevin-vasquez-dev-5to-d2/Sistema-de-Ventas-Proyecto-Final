using CapaEntidades;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FormC : Form
    {
        private ClienteBL bl = new ClienteBL();
        private BindingList<Cliente> listaClientes = new BindingList<Cliente>();
        private BindingSource clientesBinding = new BindingSource();
        private int idSeleccionado = 0;
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            else if (!long.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }
            else if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("El correo no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

            return true;
        }

        public FormC()
        {
            InitializeComponent();

            // Configurar binding del DataGridView
            clientesBinding.DataSource = listaClientes;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = clientesBinding;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ocultar columnas después de que los datos estén completamente cargados
            HideSensitiveColumns();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormC_Load(object sender, EventArgs e)
        {
            CargarClientes();
            HideSensitiveColumns();
        }

        private void CargarClientes()
        {
            listaClientes.Clear();
            var clientes = bl.ListarCl();
            if (clientes != null)
            {
                foreach (var cliente in clientes)
                {
                    listaClientes.Add(cliente);
                }
            }
        }

        private void HideSensitiveColumns()
        {
            try
            {
                // Ocultar todas las variantes de ID y estado
                string[] columnasOcultas = { "id_cliente", "ID_Cliente", "IdCliente", "Id_Cliente",
                                           "estado", "ESTADO", "Estado" };

                foreach (var columnaOculta in columnasOcultas)
                {
                    if (dataGridView1.Columns.Contains(columnaOculta))
                        dataGridView1.Columns[columnaOculta].Visible = false;
                }
            }
            catch
            {
                // no interrumpir si falla al ocultar columnas
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            { 
              try
              {
                  ClienteBL clienteBL = new ClienteBL(); 
                  Cliente cliente = new Cliente { 
                      nombre = txtNombre.Text, 
                      direccion = txtDireccion.Text, 
                      telefono = txtTelefono.Text, 
                      correo = txtCorreo.Text 
                  }; 
                  clienteBL.AgregarCl(cliente); 
                  CargarClientes();
                  clientesBinding.ResetBindings(false);
                  MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  Limpiar();
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            idSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    if (dataGridView1.CurrentRow.Cells["id_cliente"].Value == null)
                    {
                        MessageBox.Show("No se pudo obtener el ID del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_cliente"].Value);

                    var confirmacion = MessageBox.Show("¿Seguro que deseas eliminar este cliente?",
                                                       "Confirmar eliminación",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        ClienteBL clienteBL = new ClienteBL();
                        Cliente cliente = new Cliente { id_cliente = idCliente };
                        clienteBL.EliminarCl(cliente);

                        CargarClientes();
                        clientesBinding.ResetBindings(false);
                        Limpiar();
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow fila = dataGridView1.CurrentRow;

                    if (fila.Cells["nombre"].Value != null)
                        txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                    else
                        txtNombre.Text = "";

                    if (fila.Cells["direccion"].Value != null)
                        txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
                    else
                        txtDireccion.Text = "";

                    if (fila.Cells["telefono"].Value != null)
                        txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                    else
                        txtTelefono.Text = "";

                    if (fila.Cells["correo"].Value != null)
                        txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                    else
                        txtCorreo.Text = "";

                    if (fila.Cells["id_cliente"].Value != null)
                        idSeleccionado = Convert.ToInt32(fila.Cells["id_cliente"].Value);
                }
                catch (Exception ex)
                {
                    // Ignorar errores al llenar los datos
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}