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
        private ucVender ucVender;
        private string[] infoProducto;

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
            return this.controller.Login(cedula, rol, pass);

        }

        internal Boolean AgregarProducto(string nombre, string proveedor, string categoria, int precio, int cantidad)
        {
            return this.adminController.AgregarProducto(nombre,proveedor,categoria,precio,cantidad);

        }
        internal string[] BuscarProductoNumSerie(int v){
            return this.adminController.Buscar(v);
        }

        internal void VolverToInventario()
        {
            this.AbrirVistaAdmin("","");

        }

        internal Boolean EditarProducto(string [] infoProdAct){
             return this.adminController.Actualizar(infoProdAct);
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

        internal void EnviarInfoProducto(string[] infoProducto, int opcion)
        {
            switch (opcion){
                case 0:
                    this.AbrirVistaEditarProducto(infoProducto);
                    break;
                case 1:
                    this.AbrirVistaVenderProducto(infoProducto);
                    break;

                default:
                    MessageBox.Show("Han ocurrido un error, por favor revisar");
                    break;  
            }
        }

        public Boolean EliminarProducto(int numeroSerie)
        {
            return this.adminController.EliminarProducto(numeroSerie);
        }

        public void AbrirVistaAgregarProducto()
        {
            this.Controls.Clear();
            this.ucAgregarProducto = new ucAgregarProducto(this);
            this.Controls.Add(this.ucAgregarProducto);
        }

        internal void AbrirVistaVenderProducto(string [] infoProducto)
        {
            this.Controls.Clear();
            this.ucVender = new ucVender(this,infoProducto);
            this.Controls.Add(this.ucVender);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void AbrirVistaEditarProducto(string [] infoProducto)
        {
            this.Controls.Clear(); //Limpia el contenidor hijo que tiene.
            this.ucEditarProducto = new ucEditar(this, infoProducto); //Instancia el nuevo user control
            this.Controls.Add(this.ucEditarProducto); //Posicionar el hijo en el padre
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

        internal void AbrirVistaLogin()
        {
            this.Controls.Clear();
            this.ucLogin = new ucLogin(this);
            this.Controls.Add(this.ucLogin);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public List< string [] > listarProductos(){
         
            return adminController.ListarProductosTabla();
        }
    }
}
