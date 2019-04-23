using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventario.Controllers;

namespace Inventario.Views
{
    public partial class ucAgregarProducto : UserControl{

       
        private Form1 main;

        public ucAgregarProducto(Form1 main)
        {

            InitializeComponent();
            this.cmbCategoria.Items.Clear();
            this.cmbCategoria.Items.Add("Bebidas");
            this.cmbCategoria.Items.Add("Carnes");
            this.cmbCategoria.Items.Add("Frutas");
            this.cmbCategoria.Items.Add("Granos");
            this.cmbCategoria.Items.Add("Lacteos");
            this.cmbCategoria.Items.Add("Verduras");
            this.cmbCategoria.Items.Add("Ropa");
            this.cmbCategoria.Items.Add("Otros");
            this.main = main;
        }

        private void UcAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e){
            string cadena = "No se ha podido agregar el producto";
            if (this.main.AgregarProducto(txtNombre.Text, txtProveedor.Text, cmbCategoria.SelectedItem.ToString(), int.Parse(txtPrecio.Text), int.Parse(txtExistencia.Text)))
            {
                cadena = "¡Producto ha sido agregado con exito!";
                LimpiarCampos();

            }

            MessageBox.Show(cadena);

        }
        
        private void LimpiarCampos()
        {
            this.txtExistencia.Clear();
            this.txtNombre.Clear();
            this.txtProveedor.Clear();
            this.txtPrecio.Clear();
            this.cmbCategoria.SelectedItem = null;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.main.VolverToInventario();
        }
    }
}
