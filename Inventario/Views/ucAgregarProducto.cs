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
    public partial class ucAgregarProducto : UserControl
    {
        private Form1 main;
        public ucAgregarProducto(Form1 main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void UcAgregarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
