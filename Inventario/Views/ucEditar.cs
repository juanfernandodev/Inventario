using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Views
{
    public partial class ucEditar : UserControl
    {
        private Form1 main;
        private string nombre;
        public ucEditar(Form1 main,string nombre)
        {
            this.main = main;
            this.nombre = nombre;
            InitializeComponent();
           
            this.cmbCategoria.Items.Add("Bebidas");
            this.cmbCategoria.Items.Add("Carnes");
            this.cmbCategoria.Items.Add("Frutas");
            this.cmbCategoria.Items.Add("Granos");
            this.cmbCategoria.Items.Add("Lacteos");
            this.cmbCategoria.Items.Add("Verduras");
            this.cmbCategoria.Items.Add("Ropa");
            this.cmbCategoria.Items.Add("Otros");



        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.main.VolverToInventario();
        }

        private void UcEditar_Load(object sender, EventArgs e)
        {

        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            string cadena = "No se ha podido actualizar el producto";
            if (this.nombre!=""){
                string[] producto = this.main.EditarProducto(this.nombre); //Revisar
                if (producto.Length == 0){
                    txtNombre.Text = producto[1];
                    txtProveedor.Text = producto[2];
                    txtPrecio.Text = producto[4];
                    txtExistencia.Text = producto[5];
                    cadena = "¡Producto ha sido actualizado con exito!";
                }
            }
            MessageBox.Show(cadena);
        }
    }
}
