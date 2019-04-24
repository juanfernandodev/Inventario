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
    public partial class ucLogin : UserControl
    {
        private Form1 main;

        public ucLogin(Form1 main)
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.main = main;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            string password = txtPassword.Text;
            if(!cedula.Equals("") && !password.Equals(""))
            {
                if (chkAdministrador.Checked && this.main.logear(cedula, "Administrador", password))
                {
                    return;
                }
                else if (this.main.logear(cedula, "Cajero", password))
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar minimo la Cedula y su Password.");
                return;
            }
   
            MessageBox.Show("Credenciales Incorrectas. Vuelva pronto");
            this.txtCedula.Clear();
            this.txtPassword.Clear();
            this.chkAdministrador.Checked = false;
      
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblCedula_Click(object sender, EventArgs e)
        {

        }

        private void TxtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChkAdministrador_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        private void ChkCajero_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LblPass_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
