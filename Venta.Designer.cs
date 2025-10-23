namespace Ejemplos
{
    partial class Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBusqueda_AgregarProducto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.chkCodigo = new System.Windows.Forms.CheckBox();
            this.chkNombre = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvBusqueda_Datos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVenta_AgregarProducto = new System.Windows.Forms.Button();
            this.txtVenta_Total = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVenta_RealizarVenta = new System.Windows.Forms.Button();
            this.dgvVenta_datos = new System.Windows.Forms.DataGridView();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVenta_Cantidad = new System.Windows.Forms.TextBox();
            this.txtVenta_PrecioProducto = new System.Windows.Forms.TextBox();
            this.txtVenta_NombreProducto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda_Datos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBusqueda_AgregarProducto);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dgvBusqueda_Datos);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxCategoria);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 423);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Producto";
            // 
            // btnBusqueda_AgregarProducto
            // 
            this.btnBusqueda_AgregarProducto.Location = new System.Drawing.Point(310, 193);
            this.btnBusqueda_AgregarProducto.Name = "btnBusqueda_AgregarProducto";
            this.btnBusqueda_AgregarProducto.Size = new System.Drawing.Size(86, 52);
            this.btnBusqueda_AgregarProducto.TabIndex = 12;
            this.btnBusqueda_AgregarProducto.Text = "Agregar Producto seleciconado";
            this.btnBusqueda_AgregarProducto.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCategoria);
            this.groupBox2.Controls.Add(this.chkCodigo);
            this.groupBox2.Controls.Add(this.chkNombre);
            this.groupBox2.Location = new System.Drawing.Point(215, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 126);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Location = new System.Drawing.Point(12, 97);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(125, 17);
            this.chkCategoria.TabIndex = 10;
            this.chkCategoria.Text = "Buscar por Categoria";
            this.chkCategoria.UseVisualStyleBackColor = true;
            this.chkCategoria.CheckedChanged += new System.EventHandler(this.chkCategoria_CheckedChanged);
            // 
            // chkCodigo
            // 
            this.chkCodigo.AutoSize = true;
            this.chkCodigo.Location = new System.Drawing.Point(12, 58);
            this.chkCodigo.Name = "chkCodigo";
            this.chkCodigo.Size = new System.Drawing.Size(114, 17);
            this.chkCodigo.TabIndex = 9;
            this.chkCodigo.Text = "Buscar Por Codigo";
            this.chkCodigo.UseVisualStyleBackColor = true;
            this.chkCodigo.CheckedChanged += new System.EventHandler(this.chkCodigo_CheckedChanged);
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Location = new System.Drawing.Point(12, 21);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(118, 17);
            this.chkNombre.TabIndex = 8;
            this.chkNombre.Text = "Buscar Por Nombre";
            this.chkNombre.UseVisualStyleBackColor = true;
            this.chkNombre.CheckedChanged += new System.EventHandler(this.chkNombre_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(18, 192);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvBusqueda_Datos
            // 
            this.dgvBusqueda_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda_Datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cantidad,
            this.Precio,
            this.Codigo,
            this.Categoria});
            this.dgvBusqueda_Datos.Location = new System.Drawing.Point(0, 251);
            this.dgvBusqueda_Datos.Name = "dgvBusqueda_Datos";
            this.dgvBusqueda_Datos.Size = new System.Drawing.Size(396, 150);
            this.dgvBusqueda_Datos.TabIndex = 6;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(102, 84);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(102, 47);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.Text = "s";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.Enabled = false;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(102, 118);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(100, 21);
            this.cbxCategoria.TabIndex = 0;
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.Location = new System.Drawing.Point(126, 448);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(75, 34);
            this.btnCancelarVenta.TabIndex = 1;
            this.btnCancelarVenta.Text = "Cancelar Venta";
            this.btnCancelarVenta.UseVisualStyleBackColor = true;
            this.btnCancelarVenta.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnVenta_AgregarProducto);
            this.groupBox3.Controls.Add(this.txtVenta_Total);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnVenta_RealizarVenta);
            this.groupBox3.Controls.Add(this.dgvVenta_datos);
            this.groupBox3.Controls.Add(this.txtVenta_Cantidad);
            this.groupBox3.Controls.Add(this.txtVenta_PrecioProducto);
            this.groupBox3.Controls.Add(this.txtVenta_NombreProducto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(440, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 397);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Esta Venta";
            // 
            // btnVenta_AgregarProducto
            // 
            this.btnVenta_AgregarProducto.Location = new System.Drawing.Point(27, 138);
            this.btnVenta_AgregarProducto.Name = "btnVenta_AgregarProducto";
            this.btnVenta_AgregarProducto.Size = new System.Drawing.Size(146, 23);
            this.btnVenta_AgregarProducto.TabIndex = 10;
            this.btnVenta_AgregarProducto.Text = "Agregar Producto";
            this.btnVenta_AgregarProducto.UseVisualStyleBackColor = true;
            // 
            // txtVenta_Total
            // 
            this.txtVenta_Total.Enabled = false;
            this.txtVenta_Total.Location = new System.Drawing.Point(168, 331);
            this.txtVenta_Total.Name = "txtVenta_Total";
            this.txtVenta_Total.Size = new System.Drawing.Size(100, 20);
            this.txtVenta_Total.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(131, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Total";
            // 
            // btnVenta_RealizarVenta
            // 
            this.btnVenta_RealizarVenta.Location = new System.Drawing.Point(27, 340);
            this.btnVenta_RealizarVenta.Name = "btnVenta_RealizarVenta";
            this.btnVenta_RealizarVenta.Size = new System.Drawing.Size(72, 37);
            this.btnVenta_RealizarVenta.TabIndex = 7;
            this.btnVenta_RealizarVenta.Text = "Realizar Venta";
            this.btnVenta_RealizarVenta.UseVisualStyleBackColor = true;
            // 
            // dgvVenta_datos
            // 
            this.dgvVenta_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProducto,
            this.CantidadProducto,
            this.PrecioUnitario,
            this.Total});
            this.dgvVenta_datos.Location = new System.Drawing.Point(6, 167);
            this.dgvVenta_datos.Name = "dgvVenta_datos";
            this.dgvVenta_datos.Size = new System.Drawing.Size(460, 150);
            this.dgvVenta_datos.TabIndex = 6;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre Del Producto";
            this.NombreProducto.Name = "NombreProducto";
            // 
            // CantidadProducto
            // 
            this.CantidadProducto.HeaderText = "Cantidad ";
            this.CantidadProducto.Name = "CantidadProducto";
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // txtVenta_Cantidad
            // 
            this.txtVenta_Cantidad.Location = new System.Drawing.Point(164, 106);
            this.txtVenta_Cantidad.Name = "txtVenta_Cantidad";
            this.txtVenta_Cantidad.Size = new System.Drawing.Size(100, 20);
            this.txtVenta_Cantidad.TabIndex = 5;
            // 
            // txtVenta_PrecioProducto
            // 
            this.txtVenta_PrecioProducto.Enabled = false;
            this.txtVenta_PrecioProducto.Location = new System.Drawing.Point(164, 72);
            this.txtVenta_PrecioProducto.Name = "txtVenta_PrecioProducto";
            this.txtVenta_PrecioProducto.Size = new System.Drawing.Size(100, 20);
            this.txtVenta_PrecioProducto.TabIndex = 4;
            // 
            // txtVenta_NombreProducto
            // 
            this.txtVenta_NombreProducto.Enabled = false;
            this.txtVenta_NombreProducto.Location = new System.Drawing.Point(164, 38);
            this.txtVenta_NombreProducto.Name = "txtVenta_NombreProducto";
            this.txtVenta_NombreProducto.Size = new System.Drawing.Size(100, 20);
            this.txtVenta_NombreProducto.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Precio Del Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre Del producto";
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.groupBox1);
            this.Name = "Venta";
            this.Text = "Venta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda_Datos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCodigo;
        private System.Windows.Forms.CheckBox chkNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvBusqueda_Datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkCategoria;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBusqueda_AgregarProducto;
        private System.Windows.Forms.TextBox txtVenta_Total;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVenta_RealizarVenta;
        private System.Windows.Forms.DataGridView dgvVenta_datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtVenta_Cantidad;
        private System.Windows.Forms.TextBox txtVenta_PrecioProducto;
        private System.Windows.Forms.TextBox txtVenta_NombreProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVenta_AgregarProducto;
    }
}