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

        public ucAgregarProducto(){
            adminController = new AdminController();
            InitializeComponent();
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
