using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta= MessageBox.Show("¿Seguro de querer salir?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes) 
                {
                    Close();
                }
                
            }
            catch (Exception errorCancelar)
            {
                MessageBox.Show($"ERROR {errorCancelar}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //Para activar los texbox
        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNombre.Checked)
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled=false;
                txtNombre.Clear();
            }
        }

        private void chkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCodigo.Checked)
            {
                txtCodigo.Enabled = true;
            }
            else
            {
                txtCodigo.Enabled = false;
            }
        }

        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.Checked)
            {
                cbxCategoria.Enabled = true;
            }
            else
            {
                cbxCategoria.Enabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Recuperamos el nombre del textbox
                //string nombretxt=txtNombre.Text;
                //Creamos las variables a usar
                int cantidad = 0, codigo = 0;
                double precio = 0;
                string categoria = "",nombre="";
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    //MessageBox.Show("Por Favor llene la informacion del nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
                    dgvBusqueda_Datos.Rows.Clear();
                }
                else
                {
                    dgvBusqueda_Datos.Rows.Clear();
                    //Creamos la cadena de conexion de la BD
                    string conexionString = "server=DESKTOP-AHJV5N6; DataBase=Tienda; Trusted_Connection=True;";
                    //Creamos una conexion
                    using (SqlConnection conexion =new SqlConnection(conexionString))
                    {
                        //Abrimos la BD
                        conexion.Open();
                        //Creamos la Query
                        string query_BuscarNombre = "SELECT Producto.nombreProducto,Producto.cantidad, Producto.precio,Producto.codigo,Producto.categoria" +
                            " FROM Stock INNER JOIN Producto on Producto.idProducto=Stock.idProducto  Where nombreProducto like @Nombre ORDER BY codigo asc";
                        //Creamos un comando
                        using (SqlCommand comando_BuscarNombre=new SqlCommand(query_BuscarNombre, conexion))
                        {
                            //Añadimos los parametros en este caso "%"+nombre+"%" porque el sql lo lo reconoce asi '%@Nombre%' entonces se le agrega al parametro
                            comando_BuscarNombre.Parameters.AddWithValue("@Nombre", "%"+txtNombre.Text+"%");
                            //Creamos un lector
                            using(SqlDataReader lector= comando_BuscarNombre.ExecuteReader())
                            {
                                dgvBusqueda_Datos.Rows.Clear();
                                while (lector.Read()) 
                                {
                                    
                                    //Obtenemos la informacion
                                    nombre = lector["nombreProducto"] != DBNull.Value ? lector["nombreProducto"].ToString() : string.Empty;
                                    cantidad = lector["cantidad"] != DBNull.Value ? Convert.ToInt32(lector["cantidad"]) : 0;
                                    precio = lector["precio"] != DBNull.Value ? Convert.ToDouble(lector["precio"]) : 0;
                                    codigo = lector["codigo"] != DBNull.Value ? Convert.ToInt32(lector["codigo"]) : 0;
                                    categoria = lector["categoria"]!=DBNull.Value? lector["categoria"].ToString(): string.Empty;
                                    dgvBusqueda_Datos.Rows.Add(nombre, cantidad, precio, codigo, categoria);
                                }
                            }//FinCreacion lector
                        }//Fin COmando buscarNombre
                    }//FIn conexion BD
                }//Fin validador txt
            }
            catch (Exception errorBuscarNombre)
            {
                MessageBox.Show($"ERROR: {errorBuscarNombre}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
