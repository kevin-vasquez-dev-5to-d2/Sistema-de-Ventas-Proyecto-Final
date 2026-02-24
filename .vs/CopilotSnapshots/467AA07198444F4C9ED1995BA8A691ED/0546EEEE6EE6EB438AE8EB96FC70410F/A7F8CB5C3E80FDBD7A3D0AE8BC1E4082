using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormFacturacion : Form
    {
        public FormFacturacion()
        {
            InitializeComponent();
            
            reportViewer1.Visible = false;
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDetalleVentaEnGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.reportViewer1.RefreshReport();
        }

        private DataTable ObtenerDetalleVentaDesdeBD()
        {
            string connStr = ConfigurationManager.ConnectionStrings["cn"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(connStr))
                throw new InvalidOperationException("No se encontró la cadena de conexión 'cn' en App.config.");

            var dt = new DataTable();
            // Selecciona los campos que quieres mostrar y usar en el informe
            string sql = @"
                SELECT 
                    dv.id_detalle AS Id_Detalle,
                    dv.id_venta   AS Id_Venta,
                    dv.id_productos AS Id_Productos,
                    p.Nombre_Producto AS NombreProducto,
                    dv.cant AS Cant,
                    dv.precio AS PrecioUnitario,
                    (dv.cant * dv.precio) AS Subtotal
                FROM Detalle_venta dv
                LEFT JOIN Productos p ON dv.id_productos = p.Id_Productos
                ORDER BY dv.id_detalle;
            ";

            using (var conn = new SqlConnection(connStr))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }

            return dt;
        }

        private void CargarDetalleVentaEnGrid()
        {
            var dt = ObtenerDetalleVentaDesdeBD();
            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("Id_Detalle")) dataGridView1.Columns["Id_Detalle"].Visible = false;
            if (dataGridView1.Columns.Contains("Id_Venta")) dataGridView1.Columns["Id_Venta"].Visible = false;
            if (dataGridView1.Columns.Contains("Id_Productos")) dataGridView1.Columns["Id_Productos"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                if (dataGridView1.DataSource is DataTable)
                    dt = (DataTable)dataGridView1.DataSource;
                else
                    dt = ObtenerDetalleVentaDesdeBD();

                reportViewer1.LocalReport.DataSources.Clear();

                var rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
