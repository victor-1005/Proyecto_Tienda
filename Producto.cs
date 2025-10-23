using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    internal class Producto
    {
        //Creamos los atributos de la clase
        private int id;
        private string nombre;
        private int cantidad;
        private double precio;
        private string categoria;
        private int codigo;
        private double costoTotal;
        //Creamos el constructor de la clase
        public  Producto() { }
        //Creamos los getters y seters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Cantidad
        {
            get { return cantidad;}
            set { cantidad = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public  string Categoria
        {
            get { return categoria; }
            set{ categoria = value; }
        }
        public int Codigo
        {
            get{ return codigo; }
            set { codigo = value; }
        }
        public double CostoTotal
        {
            get { return costoTotal; }
            set { costoTotal = value; }
        }

    }
}
