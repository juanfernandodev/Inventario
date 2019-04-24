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
    public partial class ucVender : UserControl
    {
        private Form1 main;
        private string[] infoproducto;
        public ucVender(Form1 main, string[] infoproducto)
        {
            this.main = main;
            InitializeComponent();
            this.infoproducto = infoproducto;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.main.AbrirVistaCajero("","");
        }

        private void BtnVender_Click(object sender, EventArgs e)
        {
            string cadena = "No se puede vender este producto";
            if ((int.Parse(this.infoproducto[5])!=0) || int.Parse(this.txtCantidad.Text)>0){
                if (int.Parse(this.txtCantidad.Text) <= int.Parse(this.infoproducto[5])){
                    if (this.txtCedula.Text != "" && this.txtNombreCliente.Text != "" && txtApellidos.Text != ""){
                        this.infoproducto[5] = (int.Parse(this.infoproducto[5]) - int.Parse(txtCantidad.Text)).ToString();
                        if (this.main.EditarProducto(this.infoproducto)){
                            cadena = "¡Producto vendido con exito!";
                           
                            this.main.AbrirVistaCajero("", "");
                        }
                    }else{
                        cadena = "Ingresa los datos del cliente por favor";
                    }
                }else{
                    cadena = "La cantidad en existencia es menor a la digitada";
                }
            }else{
                cadena = "No hay existencias de ese producto, o has elegido inferior o igual a 0";
            }
            MessageBox.Show(cadena);
        }

        private void UcVender_Load(object sender, EventArgs e)
        {
            this.txtNumSerie.Text = this.infoproducto[0];
            this.txtNombre.Text = this.infoproducto[1];
            this.txtCategoria.Text = this.infoproducto[3];
            this.txtPrecio.Text = this.infoproducto[4];
            this.txtCantidad.Text = this.infoproducto[5];
            this.txtTotalPagar.Text = (int.Parse(this.infoproducto[4])*int.Parse(this.infoproducto[5])).ToString();
        }

        private void limpiarCampos()
        {
            this.txtCedula.Clear();
            this.txtNombreCliente.Clear();
            this.txtApellidos.Clear();

        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotalPagar.Text = (int.Parse(this.infoproducto[4]) * int.Parse(this.txtCantidad.Text)).ToString();
            }catch(Exception ex)
            {
                this.txtTotalPagar.Text = "0";
            }
            
        }
    }
}
