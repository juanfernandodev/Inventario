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
        private string[] infoProducto;
        public ucEditar(Form1 main, string [] infoProducto)
        {
            this.main = main;
            InitializeComponent();
            this.infoProducto = infoProducto;
           
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
            this.main.AbrirVistaAdmin("","");
        }

        private void UcEditar_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = this.infoProducto[1];
            this.txtProveedor.Text = this.infoProducto[2];
            this.cmbCategoria.SelectedItem = this.infoProducto[3];
            this.txtPrecio.Text = this.infoProducto[4];
            this.txtExistencia.Text = this.infoProducto[5];

        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //boton se llama editar, en realidad
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            string cadena = "No se ha podido actualizar el producto";

            if (!this.txtNombre.Text.Equals("") && !this.txtProveedor.Text.Equals("") && this.cmbCategoria.SelectedIndex != -1
                   && !this.txtPrecio.Text.Equals("") && !this.txtExistencia.Text.Equals(""))
            {
                string[] infoProdActualizados = {this.infoProducto[0], this.txtNombre.Text, this.txtProveedor.Text, this.cmbCategoria.SelectedItem.ToString(), this.txtPrecio.Text, this.txtExistencia.Text };

                if (this.main.EditarProducto(infoProdActualizados)) {
                    cadena = "¡Producto ha sido actualizado con exito!";
                    this.main.AbrirVistaAdmin("","");
                } 
                
            }
            MessageBox.Show(cadena);
        }
    }
}
