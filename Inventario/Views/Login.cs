using Inventario.Facade;
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
        Facade.Facade facade;

        public Form1()
        {
            InitializeComponent();
            facade = new Facade.Facade();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (chkAdministrador.Checked){
                facade.logear(txtCedula.Text, txtPassword.Text, "Administrador");
            }
            else{
                facade.logear(txtCedula.Text, txtPassword.Text, "Cajero");
            }
            
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
