using Inventario.Controllers;
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
    public partial class Form1 : Form{
        Controllers.LoginController controller;
        Controllers.AdminController adminController;
        private List<object> products;

        public Form1()
        {
            InitializeComponent();
            controller = new Controllers.LoginController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (chkAdministrador.Checked){
                controller.login(txtCedula.Text, "Administrador", txtPassword.Text);
            }else{
                controller.login(txtCedula.Text, "Cajero",txtPassword.Text);
            }
            
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<object> listaProductos(){
            products = adminController.listarPorducto();
            return products;
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
    }
}
