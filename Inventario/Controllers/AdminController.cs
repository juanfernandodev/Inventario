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

        public AdminController()
        {
            productos = new List<DTOProducto>();
            daoProducto = new DAOProducto();
        }

        /// <summary>
        /// Comunica al DAOProducto que inserte un nuevo producto a la BD
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="proveedor"></param>
        /// <param name="categoria"></param>
        /// <param name="precioUnidad"></param>
        /// <param name="cantidadExistente"></param>
        /// <returns>Confirmacion de que se ha agregado el producto</returns>
        public bool AgregarProducto(string nombre, string proveedor, string categoria, int precioUnidad,
                                    int cantidadExistente) => daoProducto.CrearProducto(nombre, proveedor, categoria, precioUnidad, cantidadExistente);

        /// <summary>
        /// Solicita al DAOProducto que elimine una producto de la BD
        /// </summary>
        /// <param name="numeroserie"></param>
        /// <returns>Confirmacion de que ha sido eliminado el producto</returns>
        public bool EliminarProducto(int numeroserie) => this.daoProducto.EliminarProducto(numeroserie);

        /// <summary>
        /// Solicita a Dao que consulte los productos de la BD
        /// </summary>
        /// <returns>Lista de los productos en la BD</returns>
        public List<string[]> ListarProductosTabla()
        {
            productos = daoProducto.DarProductos();   
            List<string[]> listaProductos = new List<string[]>();
            foreach (DTOProducto producto in productos)
            {
                listaProductos.Add(new string[] { Convert.ToString(producto.NumSerie), producto.NombreProducto, producto.Proveedor, producto.Categoria,
                                                    Convert.ToString(producto.PrecioUnidad), Convert.ToString(producto.CantidadExistente)});
            }
            return listaProductos;
        }


        /// <summary>
        /// Solicita a DaoProducto que envie una actualizacion a la tabla producto
        /// </summary>
        /// <param name="infoProdAct"></param>
        /// <returns>Confirmacion de la actualizacion</returns>
        public bool Actualizar(string[] infoProdAct) => this.daoProducto.ActualizarProducto(Convert.ToInt32(infoProdAct[0]), infoProdAct[1], infoProdAct[2], infoProdAct[3], Convert.ToInt32(infoProdAct[4]), Convert.ToInt32(infoProdAct[5]));


        /// <summary>
        /// Solicita a DAOProducto que busque un producto por su numero de serie
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Un vector con los datos del producto</returns>
        public string[] Buscar(int numserie)
        {
            string[] producto = new string[6];
            DTOProducto product = this.daoProducto.BuscarProductoNumSerie(numserie);
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
