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
    public partial class ucViewAdmin : UserControl
    {
        private Form1 main;
        public ucViewAdmin(Form1 main)
        {
            this.main = main;
            InitializeComponent();
           // this.Dock = DockStyle.Fill;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UcViewAdmin_Load(object sender, EventArgs e){
            dgvProductos.DataSource = main.listarProductos();
        }

        private void BtnAgrearProducto_Click(object sender, EventArgs e)
        {
            this.main.Controls.Clear();
            this.main.AbrirVistaAgregarProducto();
        }
    }
}
