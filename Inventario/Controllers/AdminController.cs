using Inventario.Models.DAO;
using Inventario.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<object> listarPorducto(){
            productos = daoProducto.darProductos();
            foreach (object pro in productos){
                Console.WriteLine(pro);
                products.Add(pro);
            }
            return products;
        }
        public void actualizar()
        {
            //para saber cual es la fila que voy a actualizar puedo simplemente consultar con el update
        }

        public void buscar(){

        }


    }
}
