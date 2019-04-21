using Inventario.Models.Dao;
using Inventario.Models.DTO;
using Inventario.Models.iDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Models.DAO
{
    class DAOProducto : iDAOProducto
    {
        private BdContext database;
        private MySqlConnection conexionbd;
        private string declaracion;
        private MySqlDataReader reader;
        private List<DTOProducto> productos;

        public DAOProducto()
        {
            this.database = null;
            this.conexionbd = null;
            this.reader = null;
            this.declaracion = "";
            this.productos = null;
        }


        /* Metodos implementados de iDAOProducto */
        
        /* Patron de diseño SINGLETON */
        public BdContext ConectarBD()
        {
            if (database == null)
            {
                database = new BdContext();
            }
            return database;
        }

        /* Actualiza la List local de los productos con la informacion de la BD*/
        private List<DTOProducto> actualizarProductosLocalmente()
        {
            this.productos = new List<DTOProducto>();
            this.conexionbd = this.ConectarBD().ConexionBd;
            declaracion = "Select * FROM Producto";
            this.reader = this.database.consultar(declaracion);
            
            while (this.reader.Read())
            {
                productos.Add(new DTOProducto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5)));
            }

            return productos;
        }

        /* Metodo que busca en la lista de productos si se 
           encuentra un producto con el nombre pasado en parametro */
        public DTOProducto BuscarProductoNombre(string nombre)
        {
            foreach (DTOProducto producto in productos)
            {
                if (producto.NombreProducto.Equals("nombre"))
                {
                    return producto;
                }
            }
            return null;
        }
        
        /* Devuelve la lista de productos local */
        public List<DTOProducto> darProductos(){
            if (!productos.Any()){
                productos = actualizarProductosLocalmente();
            }
            return productos;
        }

        /* Crea producto nuevo */
        public void CrearProducto(DTOProducto producto)
        {
            this.conexionbd = this.ConectarBD().ConexionBd;
            declaracion = "INSERT INTO Producto(num_serie, nombreproducto, proveedor, categoria, preciounidad, cantidadexistente) VALUES" +
                "("+producto.NumSerie+","+producto.NombreProducto+","+producto.Proveedor+","+producto.Categoria+","+producto.PrecioUnidad+","+producto.CantidadExistente+");";
            this.database.alterar(declaracion); //Inserta el producto en la BD
            this.productos.Add(producto); //Crea el producto local
        }

        /* Elimina un producto */
        public void EliminarProducto(int numserie)
        {
            this.conexionbd = this.ConectarBD().ConexionBd;
            declaracion = "DELETE FROM Producto WHERE num_serie = " + numserie;
            this.database.alterar(declaracion); //Elimina de la BD
            this.actualizarProductosLocalmente(); //Actualiza la lista local
        }

        /* Actualizar producto */
        public void ActualizarProducto(int numeroserie, string nombreproducto, string proveedor, string categoria, int preciounidad, int cantidadexistente)
        {
            this.conexionbd = this.ConectarBD().ConexionBd;
            declaracion = "UPDATE Producto SET nombreproducto=" + nombreproducto + ", proveedor=" + proveedor + ", categoria=" + categoria + ", " +
                "preciounidad=" + preciounidad + ", cantidadexistente" + cantidadexistente + ";";
            this.database.alterar(declaracion); //Actualiza la DB
            this.actualizarProductosLocalmente(); //Actualiza localmente
        }
    }
}
