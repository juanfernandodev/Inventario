using Inventario.Models.Dao;
using Inventario.Models.DTO;
using Inventario.Models.iDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Models.DAO
{
    class DAOProducto : iDAOProducto
    {
        private BdContext database;
        private string declaracion;
        private MySqlDataReader reader;
        private List<DTOProducto> productos;

        public DAOProducto()
        {
            database = null;
            reader = null;
            declaracion = "";
        }

        /// <summary>
        /// Patron de diseño Singleton, que solo crea una clase de bd si no existe otra
        /// </summary>
        /// <returns>Retorna un objeto abstracto de la bd</returns>
        public BdContext ConectarBD()
        {
            if (database == null)
            {
                database = new BdContext();
            }

            return database;
        }

        /// <summary>
        /// Actualiza la List local de los productos con la informacion de la BD
        /// </summary>
        /// <returns>Retorna una lista de los DTOProductos</returns>
        private List<DTOProducto> ActualizarProductosLocalmente()
        {
            productos = new List<DTOProducto>();
            ConectarBD();
            declaracion = "Select * FROM producto";
            reader = database.Consultar(declaracion);
            productos = new List<DTOProducto>();
            while (reader.Read())
            {
                productos.Add(new DTOProducto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5)));
            }
            database.CerrarConexion();
            return productos;
        }

        /// <summary>
        /// Metodo que busca en la lista de productos si se encuentra un producto con el nombre pasado en parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Returna un DTOProducto que tiene el nombre solicitado en los parametros</returns>
        public DTOProducto BuscarProductoNombre(string nombre)
        {
            foreach (DTOProducto producto in productos)
            {
                if (producto.NombreProducto.Equals(nombre))
                {
                    return producto;
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo que busca en la lista de productos si se encuentra un producto con el numero de serie pasado en parametro
        /// </summary>
        /// <param name="numSerie"></param>
        /// <returns>Retorna un DTOProducto que coincide con el numero de serie solicitado en los parametros</returns>
        public DTOProducto BuscarProductoNumSerie(int numSerie)
        {
            foreach (DTOProducto producto in productos)
            {
                if (producto.NumSerie == numSerie)
                {
                    return producto;
                }
            }
            return null;
        }

        /// <summary>
        /// Actualiza la lista local de productos (productos de memoria cache por asi decirlo)
        /// </summary>
        /// <returns>Retorna la lista de productos locales</returns>
        public List<DTOProducto> DarProductos()
        {
            ActualizarProductosLocalmente();
            return productos;
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="nombreProducto"></param>
        /// <param name="proveedor"></param>
        /// <param name="categoria"></param>
        /// <param name="precioUnidad"></param>
        /// <param name="cantidadExistente"></param>
        /// <returns>Confirmacion de la creacion del producto: true o false</returns>
        public bool CrearProducto(string nombreProducto, string proveedor, string categoria, int precioUnidad, int cantidadExistente)
        {
            try
            {
                ConectarBD();
                declaracion = "INSERT INTO Producto(nombreproducto, proveedor, categoria, preciounidad, cantidadexistente) VALUES" +
                    "('" + nombreProducto + "','" + proveedor + "','" + categoria + "'," + precioUnidad + "," + cantidadExistente + ");";
                Console.WriteLine(declaracion);
                database.Alterar(declaracion); //Inserta el producto en la BD
                database.CerrarConexion();

                if (productos == null)
                {
                    productos = new List<DTOProducto>();
                }
                productos.Add(BuscarProductoNombre(nombreProducto)); //Crea el producto local

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }
            database.CerrarConexion();
            return false;
        }

        /// <summary>
        /// Solicita a la objeto DataBase que envie un comando de eliminacion de un producto
        /// </summary>
        /// <param name="numserie"></param>
        /// <returns>Confirmacion de eliminacion: true o false</returns>
        public bool EliminarProducto(int numserie)
        {
            ConectarBD();
            declaracion = "DELETE FROM Producto WHERE num_serie = " + numserie;
            if (database.Alterar(declaracion))
            {
                database.CerrarConexion(); //Elimina de la BD
                ActualizarProductosLocalmente(); //Actualiza la lista local
                return true;
            }

            this.database.CerrarConexion();
            return false;
        }

        /// <summary>
        /// Solicita al objeto DB que envie una solicito de actualizacion en la tabla producto
        /// </summary>
        /// <param name="numeroserie"></param>
        /// <param name="nombreproducto"></param>
        /// <param name="proveedor"></param>
        /// <param name="categoria"></param>
        /// <param name="preciounidad"></param>
        /// <param name="cantidadexistente"></param>
        /// <returns>Confirmacion de la solicitud: true || false</returns>
        public bool ActualizarProducto(int numeroserie, string nombreproducto, string proveedor, string categoria, int preciounidad, int cantidadexistente)
        {
            ConectarBD();
            declaracion = "UPDATE Producto SET nombreproducto='" + nombreproducto + "', proveedor='" + proveedor + "', categoria='" + categoria + "', " +
                "preciounidad=" + preciounidad + ", cantidadexistente=" + cantidadexistente + " WHERE num_serie = "+numeroserie+";";
            if (database.Alterar(declaracion))
            {
                database.CerrarConexion();
                ActualizarProductosLocalmente(); //Actualiza localmente
                return true;
            }
            this.database.CerrarConexion();
            return false;
        }
    }
}
