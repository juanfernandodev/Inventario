using Inventario.Controllers;
using Inventario.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form1 : Form
    {
        private Controllers.LoginController controller;
        private ucLogin ucLogin;
        private ucViewAdmin ucViewAdmin;
        private List<string []> productos;
        private AdminController adminController;
         private ucAgregarProducto ucAgregarProducto;
        private ucEditar ucEditarProducto;

        public Form1()
        {
            InitializeComponent();
            this.ucLogin = new ucLogin(this);
            this.Controls.Add(ucLogin);
            controller = new Controllers.LoginController(this);
            adminController = new AdminController();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public bool logear(string cedula, string rol, string pass)
        {
            return this.controller.login(cedula, rol, pass);

        }

        internal void VolverToInventario()
        {
            this.Controls.Clear();
            this.Controls.Add(this.ucViewAdmin);
        }

        public void AbrirVistaAdmin(string nombre, string apellido)
        {
            
            this.Controls.Clear();
            this.ucViewAdmin = new ucViewAdmin(this);
            this.ucViewAdmin.BtnVenderProducto.Hide();
            this.Controls.Add(this.ucViewAdmin);
            
        }

        public void AbrirVistaCajero(string nombre, string apellido)
        {
            this.Controls.Clear();
            this.ucViewAdmin = new ucViewAdmin(this);
            this.ucViewAdmin.BtnAgrearProducto.Hide();
            this.ucViewAdmin.BtnEditarProducto.Hide();
            this.ucViewAdmin.BtnEliminar.Hide();
            this.Controls.Add(this.ucViewAdmin);
        }

        public void AbrirVistaAgregarProducto()
        {
            this.Controls.Clear();
            this.ucAgregarProducto = new ucAgregarProducto(this);
            this.Controls.Add(this.ucAgregarProducto);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void AbrirVistaEditarProducto()
        {
            this.Controls.Clear();
            this.ucEditarProducto = new ucEditar(this);
            this.Controls.Add(this.ucEditarProducto);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public List< string [] > listarProductos(){
            productos = adminController.ListarProductosTabla();

            return productos;

        }
    }
}
