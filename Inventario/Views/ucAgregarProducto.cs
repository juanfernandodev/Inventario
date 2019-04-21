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

        private AdminController adminController;
        private Form1 main;

        public ucAgregarProducto(Form1 main)
        {
            adminController = new AdminController();
            InitializeComponent();
            this.main = main;
        }

        private void UcAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e){
            adminController.agregarProducto(txtNombre.Text, txtProveedor.Text, cmbCategoria.SelectedItem.ToString(), int.Parse(txtPrecio.Text), int.Parse(txtExistencia.Text));
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //enviar la vista a la lista de productos
        }
    }
}
