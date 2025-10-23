using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Libreria para usar SQL
using System.Data.SqlClient;

namespace Ejemplos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MostrarResultados();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venta nuevo= new Venta();
            nuevo.ShowDialog();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra nuevo = new Compra();
            nuevo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos la url de la bd
                string conexionString = "server=DESKTOP-AHJV5N6; Database=Tienda; trusted_Connection=true;";
                //Creamos la cadena de conexion
                SqlConnection conexion=new SqlConnection(conexionString);
                //Abrimos la bd
                conexion.Open();
                MessageBox.Show("Conexion correcta");
            }
            catch (Exception errorBD)
            {

                MessageBox.Show($"ERROR {errorBD}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refrescarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarResultados();
        }
        //Metodo para mostrar los valores inciales
        public void MostrarResultados()
        {
            try
            {
                dgvDatos.Rows.Clear();
                //Creamos la url de la bd
                string conexionString = "server=DESKTOP-AHJV5N6; Database=Tienda; trusted_Connection=true;";
                //Creamos la cadena de conexion
                using (SqlConnection conexion= new SqlConnection(conexionString))//FORMA OPTIMIZADA
                {
                    //Abrimos la bd
                    conexion.Open();
                    //Creamos la QUERY
                    string QueryListarDatos = @"SELECT Producto.idProducto, Producto.nombreProducto,Producto.cantidad, Producto.precio,Producto.codigo,Producto.categoria" +
                        " FROM Stock " +
                        "INNER JOIN Producto on Producto.idProducto= Stock.idProducto";
                    //Creamos un comando
                    using (SqlCommand comando= new SqlCommand(QueryListarDatos, conexion))
                    {
                        //Creamos un lector
                        using (SqlDataReader lector= comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                //Usamos metodos de tipados para el lector y ver si hay valores nulos
                                /*Aca devolvemos los string, ya que el lector devuelve objetos genericos
                                entonces los declaramos como STRING, 
                                Obtenemos los valores de la columna idProducto, ponemos condicion que no se null, si no esta nulo, asigna lo que tiene y se convierte en string,
                                si esta vacio se pone una string vacia*/
                                string idProducto = lector["idProducto"] != DBNull.Value ? lector["idProducto"].ToString():string.Empty;
                                string nombreProducto = lector["nombreProducto"]!=DBNull.Value ? lector["nombreProducto"].ToString() :string.Empty;
                                /*Aca lo mismo, recuperamos la info de la BD, condicion, si esta lleno que asigne, si esta vacion la variable es 0*/
                                int cantidad = lector["cantidad"] != DBNull.Value ? Convert.ToInt32(lector["cantidad"]) : 0;
                                decimal precio = lector["precio"] != DBNull.Value ? Convert.ToDecimal(lector["precio"]) : 0.0m;
                                string codigo = lector["codigo"] != DBNull.Value ? lector["codigo"].ToString() : string.Empty;
                                string categoria = lector["categoria"] != DBNull.Value ? lector["categoria"].ToString() : string.Empty;

                                //Ahora lo agregamos a la gridview
                                dgvDatos.Rows.Add(idProducto, nombreProducto, cantidad, precio, codigo, categoria);
                            }
                        }
                    }
                }
                ////Creamos la Query
                //string QueryListarDatos = "SELECT Producto.idProducto, Producto.nombreProducto,Producto.cantidad, Producto.precio,Producto.codigo,Producto.categoria " +
                //    "FROM Stock " +
                //    " INNER JOIN Producto on Producto.idProducto = Stock.idProducto";

                ////Creamos un comando
                //SqlCommand comando = new SqlCommand(QueryListarDatos,conexion);

                ////Creamos un lector de la bd
                //SqlDataReader lector= comando.ExecuteReader();

                ////Creamos un bucle para leer la BD y 
                //while (lector.Read())
                //{
                //    //una variable entera para la cantidad
                //    int cantidad = Convert.ToInt32(lector["cantidad"]);

                //    dgvDatos.Rows.Add(lector["idProducto"].ToString(), lector["nombreProducto"].ToString(),
                //       cantidad,lector["precio"], lector["codigo"].ToString(), lector["categoria"].ToString());
                //}

                ////Cerramos las conexiones a la bd y el lector
                //conexion.Close();
                //lector.Close();
            }
            catch(SqlException errorBD)
            {
                // Manejar excepciones específicas de SQL
                MessageBox.Show($"Ocurrió un error en la base de datos. Por favor, inténtelo de nuevo. Detalles: {errorBD.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error)
            {

                MessageBox.Show($"ERROR {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
