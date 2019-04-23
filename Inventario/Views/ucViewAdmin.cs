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
        private string[] infoProducto = new string [6];
        public ucViewAdmin(Form1 main)
        {
            this.main = main;
            InitializeComponent();
            
            
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UcViewAdmin_Load(object sender, EventArgs e){
            List<string [] > productos =  main.listarProductos(); // Carga los productos al DataGridView una lista de objetos
            foreach (string[] p in productos)
            {
                this.dgvProductos.Rows.Add(p);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e){
            //dataGridView1.SelectedRows[i].Index.ToString()
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e){
            this.infoProducto[0] = this.dgvProductos.Rows[e.RowIndex].Cells["Numero_Serie"].Value.ToString();
            this.infoProducto[1] = this.dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            this.infoProducto[2] = this.dgvProductos.Rows[e.RowIndex].Cells["Proveedor"].Value.ToString();
            this.infoProducto[3] = this.dgvProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
            this.infoProducto[4] = this.dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            this.infoProducto[5] = this.dgvProductos.Rows[e.RowIndex].Cells["CantidadExistencia"].Value.ToString();
             
        }

        private void BtnAgrearProducto_Click(object sender, EventArgs e)
        {
            this.main.AbrirVistaAgregarProducto();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {


            if (this.infoProducto.Any()) {
                this.main.EnviarInfoProducto(this.infoProducto);
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar!");
            }
               
            
            
        }

        private void DgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnVender_Click(object sender, EventArgs e)
        {
            this.main.AbrirVistaVenderProducto();
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

