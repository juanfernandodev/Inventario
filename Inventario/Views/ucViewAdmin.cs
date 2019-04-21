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
            dgvProductos.DataSource = main.listarProductos(); // Carga los productos al DataGridView una lista de objetos
        }

        private void BtnEliminar_Click(object sender, EventArgs e){
            //dataGridView1.SelectedRows[i].Index.ToString()
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e){
            if (!(e.RowIndex > -1)){
                dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[e.RowIndex].Value.ToString();  //Me da la fila seleccionada
            }
        }

        private void BtnAgrearProducto_Click(object sender, EventArgs e)
        {
          
            this.main.AbrirVistaAgregarProducto();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
       
            this.main.AbrirVistaEditarProducto();
        }

        private void DgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
