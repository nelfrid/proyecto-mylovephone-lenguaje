using MyLoveStore.Clases;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Inventario1
{
    /// <summary>
    /// Formulario de Inventario del sistema
    /// Permite la gestión de productos: agregar, eliminar y visualizar inventario
    /// </summary>
    public partial class Inventario : Form
    {
        // VARIABLES DE INSTANCIA
        /// <summary>Referencia al administrador conectado</summary>
        private Gerente adminIngresado;

        /// <summary>Referencia a la interfaz principal</summary>
        InterfazPrincipal formInterfazPrincipal;

        // VARIABLES DE ESTADO - Flujo de agregar producto
        /// <summary>Contador de pasos en el flujo de agregar: 0=inactivo, 1=nombre, 2=ID, 3=precio, 4=cantidad</summary>
        private int agregarStep = 0;

        /// <summary>Almacena el nombre del nuevo producto</summary>
        private string nuevoNombre = string.Empty;

        /// <summary>Almacena el ID del nuevo producto</summary>
        private int nuevoId = 0;

        /// <summary>Almacena el precio del nuevo producto</summary>
        private decimal nuevoPrecio = 0;

        /// <summary>Almacena la cantidad del nuevo producto</summary>
        private int nuevaCantidad = 0;

        /// <summary>
        /// Constructor del formulario de Inventario
        /// </summary>
        /// <param name="admin_que_viene">Instancia del gerente autenticado</param>
        public Inventario(Gerente admin_que_viene)
        {
            InitializeComponent();
            this.adminIngresado = admin_que_viene;
        }

        /// <summary>
        /// Evento Load del formulario
        /// Se ejecuta al cargar el formulario por primera vez
        /// </summary>
        private void Inventario_Load(object sender, EventArgs e)
        {
            // BLOQUE 1: Posicionamiento de botones en la parte superior
            // Los botones se ubican uno al lado del otro en la esquina superior derecha
            btnAgregar.Location = new Point(760, 40);
            btnEliminar.Location = new Point(880, 40);

            // BLOQUE 2: Preparación e inicialización
            PrepararTabla();
            CargarProductos();
        }

        /// <summary>
        /// Método que configura las columnas del DataGridView
        /// Define la estructura de la tabla de inventario
        /// </summary>
        private void PrepararTabla()
        {
            // BLOQUE 1: Limpieza de columnas existentes
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // BLOQUE 2: Creación de columnas
            dataGridView1.Columns.Add("CODIGO", "CODIGO");
            dataGridView1.Columns.Add("NOMBRE", "NOMBRE DEL PRODUCTO");
            dataGridView1.Columns.Add("PRECIO", "PRECIO");
            dataGridView1.Columns.Add("CANTIDAD", "CANTIDAD");

            // BLOQUE 3: Configuración de redimensionamiento
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Método que carga todos los productos de la base de datos
        /// Obtiene los datos y los visualiza en el DataGridView
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                // BLOQUE 1: Limpieza de la tabla
                dataGridView1.Rows.Clear();

                // BLOQUE 2: Conexión a la base de datos y consulta
                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    // BLOQUE 3: Consulta SQL para obtener productos
                    string consulta = @"SELECT IdProducto, NombreProducto, PrecioProducto, CantidadProducto 
                                        FROM Productos";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    using (OleDbDataReader lector = comando.ExecuteReader())
                    {
                        // BLOQUE 4: Iteración y llenado de la tabla
                        while (lector.Read())
                        {
                            dataGridView1.Rows.Add(
                                lector["IdProducto"].ToString(),
                                lector["NombreProducto"].ToString(),
                                "B/. " + (lector["PrecioProducto"] == DBNull.Value ? "0.00" : Convert.ToDecimal(lector["PrecioProducto"]).ToString("0.00")),
                                lector["CantidadProducto"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // BLOQUE 5: Manejo de errores
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento del botón Eliminar
        /// Permite eliminar productos por ID o nombre
        /// Utiliza un flujo de dos pasos: seleccionar criterio y luego ingresar valor
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int leftX = 760;

            // BLOQUE 1: Primer paso - Mostrar opciones de eliminación
            if (btnEliminar.Text == "ELIMINAR")
            {
                // Ocultar botón de agregar y textbox anterior
                btnAgregar.Visible = false;
                tbSeleccion.Visible = false;

                // Mostrar elementos de eliminación
                cbTipoSeleccionEliminacion.Visible = true;
                lblIndicacion.Visible = true;
                btnVolver.Visible = true;
                textoError.Visible = false;

                // Posicionamiento de controles en la pantalla
                cbTipoSeleccionEliminacion.Left = leftX;
                cbTipoSeleccionEliminacion.Top = 230;
                lblIndicacion.Left = leftX;
                lblIndicacion.Top = cbTipoSeleccionEliminacion.Top - lblIndicacion.Height - 15;
                lblIndicacion2.Left = leftX;
                tbSeleccion.Left = leftX;
                tbSeleccion.Width = cbTipoSeleccionEliminacion.Width;

                // Cambiar el texto del botón para el siguiente paso
                btnEliminar.Text = "Siguiente";
                return;
            }

            // BLOQUE 2: Validación de la opción seleccionada
            string opcion = (cbTipoSeleccionEliminacion.Text ?? "").Trim();

            if (string.IsNullOrEmpty(opcion))
            {
                // Mostrar mensaje de error si no hay opción seleccionada
                textoError.Text = "Inténtelo de nuevo. Se debe elegir una opción.";
                textoError.Left = leftX;
                textoError.Top = cbTipoSeleccionEliminacion.Bottom + 10;
                textoError.Width = cbTipoSeleccionEliminacion.Width;
                textoError.ForeColor = Color.Red;
                textoError.Visible = true;
                return;
            }

            // Convertir opción a mayúsculas para comparación
            opcion = opcion.ToUpperInvariant();

            // BLOQUE 3: Segundo paso - Mostrar campo de entrada según criterio
            try
            {
                lblIndicacion2.Visible = true;
                tbSeleccion.Visible = true;
                textoError.Visible = false;

                // Posicionamiento de los elementos del segundo paso
                cbTipoSeleccionEliminacion.Left = leftX;
                lblIndicacion2.Left = leftX;
                lblIndicacion2.Top = cbTipoSeleccionEliminacion.Bottom + 30;
                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion2.Bottom + 15;
                tbSeleccion.Width = cbTipoSeleccionEliminacion.Width;

                // BLOQUE 4: Conexión a la base de datos y ejecución de eliminación
                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta;

                    // BLOQUE 4.1: Eliminación por ID
                    if (opcion == "ID")
                    {
                        if (!int.TryParse(tbSeleccion.Text.Trim(), out int idProducto))
                        {
                            textoError.Text = "El ID debe ser un número válido.";
                            textoError.Left = leftX;
                            textoError.Top = tbSeleccion.Bottom + 20;
                            textoError.Width = cbTipoSeleccionEliminacion.Width;
                            textoError.ForeColor = Color.Red;
                            textoError.Visible = true;
                            return;
                        }

                        consulta = "DELETE FROM Productos WHERE IdProducto = ?";

                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", idProducto);
                            comando.ExecuteNonQuery();
                        }
                    }
                    // BLOQUE 4.2: Eliminación por Nombre
                    else if (opcion == "NOMBRE")
                    {
                        string nombre = tbSeleccion.Text.Trim();

                        if (string.IsNullOrEmpty(nombre))
                        {
                            textoError.Text = "Ingrese el nombre del producto.";
                            textoError.Left = leftX;
                            textoError.Top = tbSeleccion.Bottom + 20;
                            textoError.Width = cbTipoSeleccionEliminacion.Width;
                            textoError.ForeColor = Color.Red;
                            textoError.Visible = true;
                            return;
                        }

                        consulta = "DELETE FROM Productos WHERE NombreProducto = ?";

                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", nombre);
                            comando.ExecuteNonQuery();
                        }
                    }
                    // BLOQUE 4.3: Opción inválida
                    else
                    {
                        textoError.Text = "Opción no válida.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 20;
                        textoError.Width = cbTipoSeleccionEliminacion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }
                }

                // BLOQUE 5: Mensaje de éxito y reseteo del formulario
                textoError.Text = "Producto eliminado correctamente.";
                textoError.Left = leftX;
                textoError.Top = tbSeleccion.Bottom + 20;
                textoError.Width = cbTipoSeleccionEliminacion.Width;
                textoError.ForeColor = Color.Green;
                textoError.Visible = true;

                // Recargar la tabla de productos
                CargarProductos();

                // BLOQUE 6: Reseteo de controles y botones
                btnEliminar.Text = "ELIMINAR";
                btnVolver.Visible = false;
                cbTipoSeleccionEliminacion.Visible = false;
                lblIndicacion.Visible = false;
                lblIndicacion2.Visible = false;
                tbSeleccion.Visible = false;
                btnAgregar.Visible = true;
                btnAgregar.Location = new Point(760, 40);
                btnEliminar.Location = new Point(880, 40);
            }
            catch (Exception ex)
            {
                // BLOQUE 7: Manejo de errores
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento del botón Agregar
        /// Permite agregar nuevos productos a través de un flujo de pasos
        /// Solicita: Nombre → ID → Precio → Cantidad
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int leftX = 760;

            // BLOQUE 1: Primer paso - Solicitar nombre del producto
            if (btnAgregar.Text == "AGREGAR")
            {
                agregarStep = 1;
                textoError.Visible = false;

                // Configurar label de indicación
                lblIndicacion.Text = "Ingrese el NOMBRE del producto:";
                lblIndicacion.Left = leftX + 5;
                lblIndicacion.Top = btnAgregar.Bottom + 50;
                lblIndicacion.Visible = true;

                // Configurar textbox para entrada
                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion.Bottom + 20;
                tbSeleccion.Width = 225;
                tbSeleccion.Text = "";
                tbSeleccion.Visible = true;
                tbSeleccion.Focus();

                btnAgregar.Text = "Siguiente";
                return;
            }

            // BLOQUE 2: Validación y pasos sucesivos (ID, Precio, Cantidad)
            if (btnAgregar.Text == "Siguiente")
            {
                // BLOQUE 2.1: Paso 1 - Validación del nombre
                if (agregarStep == 1)
                {
                    nuevoNombre = tbSeleccion.Text.Trim();

                    if (string.IsNullOrEmpty(nuevoNombre))
                    {
                        textoError.Text = "Ingrese el nombre del producto.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    // Avanzar al paso 2 - Solicitar ID
                    agregarStep = 2;
                    lblIndicacion.Text = "Ingrese el ID del producto:";
                    lblIndicacion.Top = btnAgregar.Bottom + 50;
                    tbSeleccion.Text = "";
                    tbSeleccion.Top = lblIndicacion.Bottom + 20;
                    tbSeleccion.Focus();
                    return;
                }

                // BLOQUE 2.2: Paso 2 - Validación y solicitud del ID
                if (agregarStep == 2)
                {
                    if (!int.TryParse(tbSeleccion.Text.Trim(), out nuevoId))
                    {
                        textoError.Text = "El ID debe ser un número válido.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    // Avanzar al paso 3 - Solicitar Precio
                    agregarStep = 3;
                    lblIndicacion.Text = "Ingrese el PRECIO del producto:";
                    lblIndicacion.Top = btnAgregar.Bottom + 50;
                    tbSeleccion.Text = "";
                    tbSeleccion.Top = lblIndicacion.Bottom + 20;
                    tbSeleccion.Focus();
                    return;
                }

                // BLOQUE 2.3: Paso 3 - Validación y solicitud del Precio
                if (agregarStep == 3)
                {
                    if (!decimal.TryParse(tbSeleccion.Text.Trim(), out nuevoPrecio))
                    {
                        textoError.Text = "El precio debe ser válido. Ejemplo: 1200";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    // Avanzar al paso 4 - Solicitar Cantidad
                    agregarStep = 4;
                    lblIndicacion.Text = "Ingrese la CANTIDAD del producto:";
                    lblIndicacion.Top = btnAgregar.Bottom + 50;
                    tbSeleccion.Text = "";
                    tbSeleccion.Top = lblIndicacion.Bottom + 20;
                    tbSeleccion.Focus();
                    return;
                }

                // BLOQUE 2.4: Paso 4 - Validación y inserción en base de datos
                if (agregarStep == 4)
                {
                    // Validar que la cantidad sea un número
                    if (!int.TryParse(tbSeleccion.Text.Trim(), out nuevaCantidad))
                    {
                        textoError.Text = "La cantidad debe ser un número válido.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    // BLOQUE 2.4.1: Inserción del producto en la base de datos
                    try
                    {
                        using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                        {
                            conexion.Open();

                            // Consulta SQL de inserción
                            string consulta = @"INSERT INTO Productos 
                            (IdProducto, NombreProducto, PrecioProducto, CantidadProducto, EstadoProducto)
                            VALUES (?, ?, ?, ?, ?)";

                            using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                            {
                                // Agregar parámetros a la consulta
                                comando.Parameters.AddWithValue("?", nuevoId);
                                comando.Parameters.AddWithValue("?", nuevoNombre);
                                comando.Parameters.AddWithValue("?", nuevoPrecio);
                                comando.Parameters.AddWithValue("?", nuevaCantidad);
                                comando.Parameters.AddWithValue("?", "Activo");

                                // Ejecutar la inserción
                                comando.ExecuteNonQuery();
                            }
                        }

                        // BLOQUE 2.4.2: Mensaje de éxito y reseteo
                        textoError.Text = "Producto agregado correctamente.";
                        textoError.ForeColor = Color.Green;
                        textoError.Visible = true;

                        // Resetear variables de estado
                        agregarStep = 0;
                        btnAgregar.Text = "AGREGAR";
                        tbSeleccion.Visible = false;
                        lblIndicacion.Visible = false;

                        // Recargar la tabla con el nuevo producto
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        // BLOQUE 2.4.3: Manejo de errores en la inserción
                        textoError.Text = "Error al agregar producto: " + ex.Message;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Evento del botón Modificar
        /// Está pendiente de implementación para modificar cantidades de productos
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // BLOQUE 1: Placeholder para funcionalidad futura
            MessageBox.Show("Después hacemos modificar cantidad.");
        }

        /// <summary>
        /// Evento del botón Reset
        /// Recarga la tabla de productos desde la base de datos
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // BLOQUE 1: Recarga de productos
            CargarProductos();
        }

        /// <summary>
        /// Evento del botón Volver
        /// Cancela la operación actual y vuelve al estado inicial
        /// Oculta todos los controles temporales y resetea el estado
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // BLOQUE 1: Ocultamiento de controles temporales
            cbTipoSeleccionEliminacion.Visible = false;
            lblIndicacion.Visible = false;
            lblIndicacion2.Visible = false;
            tbSeleccion.Visible = false;
            textoError.Visible = false;
            btnVolver.Visible = false;

            // BLOQUE 2: Restauración del estado inicial
            btnAgregar.Visible = true;
            btnAgregar.Location = new Point(760, 40);
            btnEliminar.Location = new Point(880, 40);
            btnAgregar.Text = "AGREGAR";
            btnEliminar.Text = "ELIMINAR";
            agregarStep = 0;
        }

        /// <summary>
        /// Evento del DataGridView al hacer click en una celda
        /// Actualmente no implementado

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // BLOQUE 1: Sin implementación actual
        }

        /// <summary>
        /// Evento del botón Volver a Interfaz Principal
        /// Cierra el formulario de inventario y regresa a la interfaz principal
        /// </summary>
        private void btnVolverInterfazPrincipal_Click(object sender, EventArgs e)
        {
            // BLOQUE 1: Creación y apertura de la interfaz principal
            InterfazPrincipal formInterfazPrincipal = new InterfazPrincipal(adminIngresado);
            formInterfazPrincipal.Show();

            // BLOQUE 2: Ocultamiento del formulario actual
            this.Hide();
        }
    }
}