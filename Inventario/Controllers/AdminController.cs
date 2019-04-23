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

        public AdminController(){
            
            productos = new List<DTOProducto>();
            daoProducto = new DAOProducto();
        }

        public Boolean agregarProducto(string nombre,string proveedor,string categoria,int precioUnidad, int cantidadExistente){
            return daoProducto.CrearProducto(nombre, proveedor, categoria, precioUnidad, cantidadExistente);
        }

        public Boolean EliminarProducto(int numeroserie){
           return this.daoProducto.EliminarProducto(numeroserie);

        }

        public List<string []> ListarProductosTabla(){
            productos = daoProducto.darProductos();   
            List<string[]> listaProductos = new List<string[]>();
            foreach (DTOProducto producto in productos){
                listaProductos.Add(new string[] { Convert.ToString(producto.NumSerie), producto.NombreProducto, producto.Proveedor, producto.Categoria,
                                                    Convert.ToString(producto.PrecioUnidad), Convert.ToString(producto.CantidadExistente)});
            }
            return listaProductos;
        }
        public Boolean actualizar(string [] infoProdAct){
            return this.daoProducto.ActualizarProducto(Convert.ToInt32(infoProdAct[0]), infoProdAct[1], infoProdAct[2], infoProdAct[3], Convert.ToInt32(infoProdAct[4]), Convert.ToInt32(infoProdAct[5]));
        }

        public string[] buscar(int nombre){
            string[] producto = new string[6];
            DTOProducto product = this.daoProducto.BuscarProductoNumSerie(nombre);
            producto[0] = product.NumSerie.ToString();
            producto[1] = product.NombreProducto;
            producto[2] = product.Proveedor;
            producto[3] = product.Categoria;
            producto[4] = product.PrecioUnidad.ToString();
            producto[5] = product.CantidadExistente.ToString();
            return producto;
        }


    }
}
