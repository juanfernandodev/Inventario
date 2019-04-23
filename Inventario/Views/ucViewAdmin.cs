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
        /*Boton buscar
         */
        private void Button1_Click(object sender, EventArgs e){
            string cadena = "Prodcuto no ha sido encontrado";
            if (int.Parse(txtBusqueda.Text)>0){
                string[] producto = this.main.BuscarProductoNumSerie(int.Parse(txtBusqueda.Text));
                if (producto.Any()){
                    cadena = "El producto ha sido encontrado";
                    this.dgvProductos.Rows.Clear();
                    this.dgvProductos.Refresh();
                    this.dgvProductos.Rows.Add(producto);
                }else{
                    cadena = "No existe un producto con ese número de serie";
                }
            }
            else{
                cadena = "Ingresa valores que sean validos, por favor";
            }

            MessageBox.Show(cadena);
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

        //Boton editar producto
        private void Button1_Click_1(object sender, EventArgs e)
        {


            if (this.infoProducto.Any()) {
                this.main.EnviarInfoProducto(this.infoProducto,0); 
            }
            else
            {
                MessageBox.Show("¡Seleccione un producto para editar!");
            }
        }

        private void DgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnVender_Click(object sender, EventArgs e)
        {
            if (this.infoProducto.Any())
            {
                this.main.EnviarInfoProducto(this.infoProducto, 1);
            }
            else
            {
                MessageBox.Show("¡Seleccione un producto para Vender!");
            }
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.infoProducto.Any())
            {
                if (this.main.EliminarProducto(Convert.ToInt32(this.infoProducto[0])))
                {
                    MessageBox.Show("Producto Eliminado con Éxito!");
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el producto");
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione un producto para Eliminar!");
            }
        }
    }
    }

