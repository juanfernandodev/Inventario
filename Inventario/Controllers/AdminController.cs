using Inventario.Models.DAO;
using Inventario.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Controllers
{
    class AdminController{
        
        private List<DTOProducto> productos;
        private DAOProducto daoProducto;
        private List<object> products;

        public AdminController(){
            
            productos = new List<DTOProducto>();
            daoProducto = new DAOProducto();
            products = new List<object>();
        }

        public void agregarProducto(string nombre,string proveedor,string categoria,int precioUnidad, int cantidadExistente){
            daoProducto.CrearProducto(nombre, proveedor, categoria, precioUnidad, cantidadExistente);
        }

        public void eliminarProducto(){

        }

        public List<string []> ListarProductosTabla(){
            productos = daoProducto.darProductos();
            
            List<string[]> listaProductos = new List<string[]>();
            string [] productosVector = new string[6];
            foreach (DTOProducto producto in productos){
                productosVector[0] = Convert.ToString(producto.NumSerie);
                productosVector[1] = producto.NombreProducto;
                Console.WriteLine(productosVector[1]);
                productosVector[2] = producto.Proveedor;
                productosVector[3] = producto.Categoria;
                productosVector[4] = Convert.ToString(producto.PrecioUnidad);
                productosVector[5] = Convert.ToString(producto.CantidadExistente);
                listaProductos.Add(productosVector);
                
            }
            return listaProductos;
        }
        public void actualizar()
        {
            //para saber cual es la fila que voy a actualizar puedo simplemente consultar con el update
        }

        public void buscar(){

        }


    }
}
