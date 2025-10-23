using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//LIBRERIA PARA SQL
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos
{
    public partial class Compra : Form
    {
        //Creamos una lIst de tipo Producto
        //List<Compra> listaDeCompras;
        public Compra()
        {
            InitializeComponent();
            ConsultarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    Close();
                }

            }
            catch (Exception errorCancelar)
            {
                MessageBox.Show($"ERROR {errorCancelar}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gpbAgregar.Enabled = true;
        }
        private void btnRefrescarDatos_Click(object sender, EventArgs e)
        {
            ConsultarDatos();
        }

        private void chkProductoNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProductoNuevo.Checked) { 
                txtId.Enabled = false;
                txtId.Text = "1";
                btnSeleccionarProducto.Enabled = false;
            }
            else
            {
                txtId.Enabled=true;
                txtId.Text = "0";
                btnSeleccionarProducto.Enabled=true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos una variable de proceso
                bool esValido;
                string entrada;
                //Variables para las consultas
                int idRecuperado = 0, idCompraRecuperado=0;
                //Creamos las variables que usaremos
                string nombre="", categoria="";
                int id=0, cantidad=0, codigo=0;
                DateTime fecha;
                double costoTotal = 0, precio = 0, precioVenta=0;

                //Asginamos los valores a las variables, y validamos la información
                entrada = txtId.Text;
                esValido=int.TryParse(entrada, out id);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el id", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    entrada = "";
                    esValido = false;
                }

                 nombre = txtNombre.Text;
                if (String.IsNullOrEmpty(nombre)) 
                {
                    MessageBox.Show("Por favor Llene el nombre del producto", "Advertncia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                entrada = txtCantidad.Text;
                esValido = int.TryParse(entrada, out cantidad);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en la cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    entrada = "";
                    esValido = false;
                }

                entrada = txtPrecio.Text;
                esValido = double.TryParse(entrada, out precio);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el precio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    entrada = "";
                    esValido = false;
                }
                entrada = txtPrecioVenta.Text;
                esValido=double.TryParse(entrada,out precioVenta);
                if (!esValido) 
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el precio disponible en venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    entrada = "";
                    esValido = false;
                }
                if (cbxCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor seleccione una categoria Valida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    categoria = cbxCategoria.SelectedItem.ToString();
                }

                    entrada = txtCodigo.Text;
                esValido = int.TryParse(entrada, out codigo);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    entrada = "";
                    esValido = false;
                }
                fecha = dtpFecha.Value;
                costoTotal = Convert.ToDouble(txtCostoTotal.Text);
                //Para poder Continuar Los valores hasta que esten llenos
                if (nombre.Length == 0)
                {
                    MessageBox.Show("Por favor Llene el nombre del producto", "Advertncia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //Validaor ID
                    if (id <= 0)
                    {
                        MessageBox.Show("Por favor coloque un id del producto", "Advertncia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Validador Cantidad
                        if (cantidad <= 0)
                        {
                            MessageBox.Show("Por favor Ingrese numeros diferentes de 0 en la cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            //validador Precio
                            if (precio <= 0)
                            {
                                MessageBox.Show("Por favor Ingrese numeros diferentes de 0 en el precio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (precioVenta <= 0) 
                                {
                                    MessageBox.Show("Por favor ingrese numeros diferentes de 0 en el precio de venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    //Validador Categoria
                                    if (categoria.Length == 0)
                                    {
                                        MessageBox.Show("Por favor seleccione una de las categorias Que Ofrece", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        //Validador Codigo
                                        if (codigo <= 0)
                                        {
                                            MessageBox.Show("Por favor Ingrese numeros diferentes de 0 en el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            //Aca empezamos a crear las Query y "clasificamos" si es nuevo producto o que ya que aca iria la query Crear nuevo INSERT
                                            if (chkProductoNuevo.Checked)
                                            {
                                                using (SqlConnection conexion = new SqlConnection("server=DESKTOP-AHJV5N6; Database=Tienda; trusted_Connection=true;"))
                                                {
                                                    //Abrimos la bd
                                                    conexion.Open();

                                                    // //Creamos la Query
                                                    string queryInsertarProducto = @"INSERT INTO Producto(nombreProducto, precio, cantidad, codigo, categoria)" +
                                                      " VALUES (@nombre,@precioVenta,@cantidad,@codigo,@categoria); SELECT SCOPE_IDENTITY();";
                                                    //Creamos un comando
                                                    using (SqlCommand comandoInsertarProducto = new SqlCommand(queryInsertarProducto, conexion))
                                                    {
                                                        //Insertamos todos los valores con parametros
                                                        comandoInsertarProducto.Parameters.AddWithValue("@nombre", nombre);
                                                        comandoInsertarProducto.Parameters.AddWithValue("@precioVenta", precioVenta);
                                                        comandoInsertarProducto.Parameters.AddWithValue("@cantidad", cantidad);
                                                        comandoInsertarProducto.Parameters.AddWithValue("@codigo", codigo);
                                                        comandoInsertarProducto.Parameters.AddWithValue("@categoria", categoria);

                                                        idRecuperado = Convert.ToInt32(comandoInsertarProducto.ExecuteScalar());

                                                        //Insertamos en Stock
                                                        //Creamos la Query
                                                        string QueryInsertarStock = "INSERT INTO Stock(idProducto) VALUES (@idProductoRecuperado)";
                                                        //Creamos el comando
                                                        using (SqlCommand comandoInsertarStock = new SqlCommand(QueryInsertarStock, conexion))
                                                        {
                                                            //Insetamos los parametros
                                                            comandoInsertarStock.Parameters.AddWithValue("@idProductoRecuperado", idRecuperado);

                                                            //Mensaje de confirmacion
                                                            int filasAfectadas = comandoInsertarStock.ExecuteNonQuery();

                                                            if (filasAfectadas > 0)
                                                                MessageBox.Show("Producto y stock guardados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            else
                                                                MessageBox.Show("Error al insertar en Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            
                                                            //INsertamos en Compra
                                                            //Creamos la query
                                                            string Query_insertarCompra = "INSERT INTO Compra(idProducto,precio,cantidad,total)" +
                                                                " VALUES (@idProducto_compra,@precio_compra,@cantidad_compra,@total_compra); " +
                                                                "SELECT SCOPE_IDENTITY();";
                                                            //Creamos un comando
                                                            using (SqlCommand comandoCompra = new SqlCommand(Query_insertarCompra, conexion))
                                                            {
                                                                //Insertamos los parametros
                                                                comandoCompra.Parameters.AddWithValue("@idProducto_compra", idRecuperado);
                                                                comandoCompra.Parameters.AddWithValue("@precio_compra", precio);
                                                                comandoCompra.Parameters.AddWithValue("@cantidad_compra", cantidad);
                                                                comandoCompra.Parameters.AddWithValue("@total_compra", costoTotal);

                                                                idCompraRecuperado = Convert.ToInt32(comandoCompra.ExecuteScalar());
                                                                //Mensaje de confirmacion
                                                                //int filasAfectadas2 = comandoCompra.ExecuteNonQuery();

                                                                // if (filasAfectadas2 > 0)
                                                                //     MessageBox.Show("Producto y stock guardados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                // else
                                                                //     MessageBox.Show("Error al insertar en Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                                //AHORA INSERTAMOS EN FECHA
                                                                string query_Fecha = "INSERT INTO Fecha(idCompra, fecha) VALUES (@idCompra_Recuperado,@fecha)";
                                                                //Creamos un comando
                                                                using (SqlCommand comandoFecha= new SqlCommand(query_Fecha, conexion))
                                                                {
                                                                    comandoFecha.Parameters.AddWithValue(@"idCompra_Recuperado", idCompraRecuperado);
                                                                    comandoFecha.Parameters.AddWithValue(@"fecha", fecha);

                                                                    int filasafectadas3= comandoFecha.ExecuteNonQuery();
                                                                    if (filasafectadas3 > 0)
                                                                    {
                                                                        MessageBox.Show("Fecha Guardada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("No se Guardo la fecha", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    }
                                                                }//Fin comando insertar fecha
                                                                    
                                                            }//Fin comando Insertar en compra
                                                        }//Fin comando insertar Stock

                                                        
                                                    }//Fin comando insertar Producto 
                                                }//Fin uso del proceso
                                                MessageBox.Show("Producto Nuevo Agreagado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ConsultarDatos();
                                                limpiar();
                                            }
                                            else//QUERY UPDATE
                                            {
                                                //Variables de proceso
                                                int cantidadRecuperada = 0;
                                                int cantidadTotal = 0;
                                                //Creamos la cadena de conexion
                                                string conexionString = "server=DESKTOP-AHJV5N6; Database=Tienda; trusted_Connection=true;";
                                                //Abrimos la BD
                                                using (SqlConnection conexion = new SqlConnection(conexionString))
                                                {
                                                    conexion.Open();
                                                    //Creamos una query oara recuperar la cantidad de producto antes de poder añadir la nueva
                                                    string queryRecuperarCantidad = "SELECT cantidad FROM Producto where idProducto=@idProducto";
                                                    using (SqlCommand comandoRecuperarCantidad= new SqlCommand(queryRecuperarCantidad,conexion))
                                                    {
                                                        //Agregamos los parametros
                                                        comandoRecuperarCantidad.Parameters.AddWithValue("@idProducto", id);

                                                        //Creamos un lector
                                                        using (SqlDataReader lectorRecuperaCantidad = comandoRecuperarCantidad.ExecuteReader())
                                                        {
                                                            while (lectorRecuperaCantidad.Read()) 
                                                            {
                                                                cantidadRecuperada = lectorRecuperaCantidad["cantidad"] != DBNull.Value ? Convert.ToInt32(lectorRecuperaCantidad["cantidad"]) : 0;
                                                            }
                                                            lectorRecuperaCantidad.Close();

                                                            //Creamos la Query
                                                            string queryActualizarProducto = "UPDATE Producto SET nombreProducto=@nombreProducto, precio=@precio, cantidad=@cantidad," +
                                                                " codigo=@codigo, categoria= @categoria WHERE idProducto=@idProducto";

                                                            //Creamos un comando
                                                            using (SqlCommand comandoActualizarProducto = new SqlCommand(queryActualizarProducto, conexion))
                                                            {
                                                                //Agregamos los parametros
                                                                comandoActualizarProducto.Parameters.AddWithValue("@nombreProducto", nombre);
                                                                comandoActualizarProducto.Parameters.AddWithValue("@precio", precioVenta);
                                                                //Metodo para aumentar la cantida de producto
                                                                cantidadTotal = cantidadRecuperada + cantidad;
                                                                comandoActualizarProducto.Parameters.AddWithValue("@cantidad", cantidadTotal);//Cantidad Total = la que existia mas la del texbox
                                                                comandoActualizarProducto.Parameters.AddWithValue("@codigo", codigo);
                                                                comandoActualizarProducto.Parameters.AddWithValue("@categoria", categoria);
                                                                comandoActualizarProducto.Parameters.AddWithValue("@idProducto", id);

                                                                int filasAfectadas = comandoActualizarProducto.ExecuteNonQuery();
                                                                if (filasAfectadas > 0)
                                                                {
                                                                    MessageBox.Show("Producto Actualizado", "Transaccion Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                                    //Aca insertamos la query para agregarlo a la tabla compras
                                                                    //Creamos la query
                                                                    string Query_insertarCompra = "INSERT INTO Compra(idProducto,precio,cantidad,total)" +
                                                                        " VALUES (@idProducto_compra,@precio_compra,@cantidad_compra,@total_compra); " +
                                                                         "SELECT SCOPE_IDENTITY();";
                                                                    //Creamos un comando
                                                                    using (SqlCommand comandoCompra = new SqlCommand(Query_insertarCompra, conexion))
                                                                    {
                                                                        //Insertamos los parametros
                                                                        comandoCompra.Parameters.AddWithValue("@idProducto_compra", id);
                                                                        comandoCompra.Parameters.AddWithValue("@precio_compra", precio);
                                                                        comandoCompra.Parameters.AddWithValue("@cantidad_compra", cantidad);//Viene del textbox
                                                                        comandoCompra.Parameters.AddWithValue("@total_compra", costoTotal);

                                                                        idCompraRecuperado = Convert.ToInt32(comandoCompra.ExecuteScalar());

                                                                        //AHORA INSERTAMOS EN FECHA
                                                                        string query_Fecha = "INSERT INTO Fecha(idCompra, fecha) VALUES (@idCompra_Recuperado,@fecha)";
                                                                        //Creamos un comando
                                                                        using (SqlCommand comandoFecha = new SqlCommand(query_Fecha, conexion))
                                                                        {
                                                                            comandoFecha.Parameters.AddWithValue(@"idCompra_Recuperado", idCompraRecuperado);
                                                                            comandoFecha.Parameters.AddWithValue(@"fecha", fecha);

                                                                            int filasafectadas3 = comandoFecha.ExecuteNonQuery();
                                                                            if (filasafectadas3 > 0)
                                                                            {
                                                                                MessageBox.Show("Fecha Guardada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("No se Guardo la fecha", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                            }
                                                                        }//Fin comando insertar fecha
                                                                    }//Fin comando compra
                                                                    ConsultarDatos();
                                                                    limpiar();
                                                                }//Fin metodo filas afectadas>0
                                                                else
                                                                {
                                                                    DialogResult respuesta = MessageBox.Show("Al parecer el Producto no existe, por lo que se tiene que crear Registro Primero\nSi desea agregar el producto, seleccione \"Si\" o marque la casilla  \"Nuevo Producto\"", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                                    if (respuesta == DialogResult.Yes)
                                                                    {
                                                                        chkProductoNuevo.Checked = true;
                                                                    }
                                                                }
                                                            }//Fin comando Actualizar Proucto
                                                        }//Fin lector RecuperarCantidad
                                                    }//Fin ccomando Recuperar Cantidad
                                                }//Fin coneixon BD

                                                    //MessageBox.Show("Producto Actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }//Fin Validador codigo
                                    }//Fin Validador cbx
                                }//Fin Validador PrecioVenta<=0
                            }//Fin Validaro Precio<=0
                        }//Fin Validador Cantidad<=0
                    }//Fin Validador Id<=0
                }//Fin Validador Nombre Vacio
            }
            catch (Exception errorAgregar)
            {

                MessageBox.Show($"ERROR {errorAgregar}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para saber el precio de manera Automatica
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //int cantida = Convert.ToInt32(txtCantidad.Text);
                //txtCostoTotal.Text = cantida.ToString();
                bool esValido;
                string entrada;
                int cantidad = 0;
                entrada = txtCantidad.Text;
                esValido = int.TryParse(entrada, out cantidad);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en la cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                double precio = 0, total = 0;
                entrada = txtPrecio.Text;
                esValido = double.TryParse(entrada, out precio);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el precio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                total = precio * cantidad;
                txtCostoTotal.Text = Convert.ToString(total);
            }
            catch (Exception errorCalculoCantidad)
            {

                MessageBox.Show($"ERROR {errorCalculoCantidad}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Continuación metoto para saber el preico de manera automatica
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool esValido;
                string entrada;
                int cantidad = 0;
                entrada = txtCantidad.Text;
                esValido = int.TryParse(entrada, out cantidad);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en la cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double precio = 0, total = 0;
                entrada = txtPrecio.Text;
                esValido = double.TryParse(entrada, out precio);
                if (!esValido)
                {
                    MessageBox.Show("Por favor Ingrese numeros validos en el precio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                total = precio * cantidad;
                txtCostoTotal.Text = Convert.ToString(total);
            }
            catch (Exception errorCalculoCantidad)
            {

                MessageBox.Show($"ERROR {errorCalculoCantidad}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para consultar los productos
        public void ConsultarDatos()
        {
            //creamos un try catch
            try
            {
                dgvDatos.Rows.Clear();
                //Creamos la url de la bd
                string conexionString = "server=DESKTOP-AHJV5N6; DataBase=Tienda; Trusted_Connection=True;";
                //creamos la cadena de conexion
                using (SqlConnection conexion= new SqlConnection(conexionString))
                {
                    //Abrimos la bd
                    conexion.Open();
                    //Creamos la QUERY
                    string QueryListarDatos = @"SELECT Producto.idProducto, Producto.nombreProducto,Producto.cantidad, Producto.precio,Producto.codigo,Producto.categoria" +
                        " FROM Stock " +
                        "INNER JOIN Producto on Producto.idProducto= Stock.idProducto"+
                        " ORDER BY codigo asc";
                    //Creamos un comando
                    using (SqlCommand comando= new SqlCommand(QueryListarDatos,conexion))
                    {
                        //Creamos un lector
                        using (SqlDataReader lector= comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                //OBTENEMOS EL TIPEO DE LA BD
                                string idProducto = lector["idProducto"] != DBNull.Value ? lector["idProducto"].ToString() : string.Empty;
                                string nombreProducto = lector["nombreProducto"] != DBNull.Value ? lector["nombreProducto"].ToString() : string.Empty;
                                int cantidad = lector["cantidad"] != DBNull.Value ? Convert.ToInt32(lector["cantidad"]) : 0;
                                int codigo = lector["codigo"] != DBNull.Value ? Convert.ToInt32(lector["codigo"]) : 0;
                                string categoria = lector["categoria"] != DBNull.Value ? lector["categoria"].ToString() : string.Empty;
                                //Agreamos los datos ala gridview
                                dgvDatos.Rows.Add(idProducto,nombreProducto,cantidad,codigo,categoria);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodo para limpiar
        public void limpiar()
        {
            txtId.Text="0";
            txtNombre.Clear();
            txtCantidad.Text = "0";
            txtPrecioVenta.Clear();
            txtPrecio.Text = "0";
            cbxCategoria.SelectedIndex = -1;
            txtCodigo.Text = "0";
            txtCostoTotal.Clear();
        }

        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                gpbAgregar.Enabled = true;
                if (dgvDatos.CurrentCell != null)
                {
                    //Creamos variable a usar
                    string categoria = "";
                    double precioVenta = 0;
                    DataGridViewRow fila = dgvDatos.CurrentRow;
                    int idProducto = Convert.ToInt32(fila.Cells["idProducto"].Value.ToString());
                    txtId.Text = Convert.ToString(idProducto);
                    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                    txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();
                    //string categoria = fila.Cells["Categoria"].Value.ToString();
                    txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                    //Creamos un metodo para autoseleccionar el comboBox

                    //Creamos la url de la bd
                    string conexionString = "server=DESKTOP-AHJV5N6; DataBase=Tienda; Trusted_Connection=True;";
                    //Creamos la conexion
                    using (SqlConnection conexion = new SqlConnection(conexionString))
                    {
                        conexion.Open();
                        //Creamos un Query para recuperar el precio a venta, catgoria
                        string QueryRecuperarDatos = "SELECT precio, categoria FROM Producto  WHERE idProducto=@idProducto";
                        //Creamos un comando
                        using (SqlCommand comandoRecuperarDatos = new SqlCommand(QueryRecuperarDatos, conexion))
                        {
                            //Añadimos el parametro de lectura
                            comandoRecuperarDatos.Parameters.AddWithValue("@idProducto", idProducto);
                            //Creamos un lector
                            using (SqlDataReader lector= comandoRecuperarDatos.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    //Recuperamos los datos
                                    categoria = lector["categoria"] != DBNull.Value ? lector["categoria"].ToString() : string.Empty;
                                    precioVenta = lector["precio"] != DBNull.Value ? Convert.ToDouble(lector["precio"]) : 0;
                                }

                                //Agregamos los datos a los
                                txtPrecioVenta.Text=precioVenta.ToString();
                                //Creamos el metodo para "autoseleccionar" el comboBox
                                switch (categoria)
                                {
                                    case "Lacteos":
                                        cbxCategoria.SelectedIndex = 0;
                                        break;
                                    case "Lacteos Sin refrigeracion":
                                        cbxCategoria.SelectedIndex = 1;
                                        break;
                                    case "Jugos":
                                        cbxCategoria.SelectedIndex = 2;
                                        break;
                                    case "Agua":
                                        cbxCategoria.SelectedIndex = 3;
                                        break;

                                }
                            }//Fin Lector
                        }//FinComando
                    }//Fin conexion BD
                }
            }
            catch (Exception errorDatosColocads)
            {

                MessageBox.Show($"Error: {errorDatosColocads}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarProductoSeleccionado_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
