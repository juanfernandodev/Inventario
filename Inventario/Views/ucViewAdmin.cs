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
            
            
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UcViewAdmin_Load(object sender, EventArgs e){
             List<string [] > productos =  main.listarProductos(); // Carga los productos al DataGridView una lista de objetos
            //MessageBox.Show(productos[0][0]);
            this.dgvProductos.DataSource = productos;
            //creo que se debe hacer un datatable, y luego eso se asigna ejemplo: http://gastontcet.blogspot.com/2013/12/c-cargar-datagridview-partir-de-un.html


            /*foreach(string[] producto in productos)
            {
                //Console.WriteLine(producto[1]);
               // this.dgvProductos.DataSource = producto;
                //this.dgvProductos.Rows.Insert(Convert.ToInt32(producto[0]), producto[1], producto[2], producto[3], producto[4], producto[5]);
               
            }*/
        }

        private void BtnEliminar_Click(object sender, EventArgs e){
            //dataGridView1.SelectedRows[i].Index.ToString()
        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e){
            Console.WriteLine("Entra");//No entra al metodo
            string valor="Valor de fila: ";
                valor = dgvProductos.CurrentCell.Value.ToString();
                //+= dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[e.RowIndex].Value.ToString();  //Me da la fila seleccionada
                Console.WriteLine(valor);
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

        private void BtnVender_Click(object sender, EventArgs e)
        {
            this.main.AbrirVistaVenderProducto();
        }
    }
}
